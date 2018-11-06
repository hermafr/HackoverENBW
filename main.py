import time
import numpy as np
from tkinter import *
from visualisation import visualise
from power_flow_interface import Edge
import pickle
import sys


def get_values():
    values = []
    for s in sliders:
        values.append(s.get())
    return values


def get_checks():
    values = []
    for c in check_vars:
        values.append(c.get())
    return values


def update_values():
    global current_values
    values = get_values()
    changed = np.argmax(np.abs(np.array(values) - np.array(current_values)))
    diff = np.sum(np.array(current_values) - np.array(values))  # < 0 if increase
    checkvals = get_checks()
    for i in range(n_nodes):
        if checkvals[i]:
            old_value = sliders[i].get()
            new_value = old_value + diff
            if new_value > slider_maxs[i]:
                diff = slider_maxs[i] - old_value
            elif new_value < slider_mins[i]:
                diff = slider_mins[i] - old_value
            current_values[i] = current_values[i] + diff
    current_values[changed] = current_values[changed] - diff
    set_sliders()


def write_file():
    values = current_values
    path = "/home/matze/Hackover/Case 2 Redispatching Netze/vertex.csv"
    with open(path, "w") as f:
        for i in range(n_nodes):
            if values[i] >= 0:
                generation = values[i]
                consumption = 0
            else:
                generation = 0
                consumption = -values[i]
            f.write("%i, %i, %i, %i, %i, %i, %i\n" % (i, generation, consumption, generation, consumption, 0, 0))


def update_cost():
    redispatch = np.maximum(np.array(current_values) - np.array(init), 0)
    cost = np.sum(redispatch * np.array(costs))
    cost_label_var.set("%.2f €" % cost)


def set_sliders():
    for i in range(n_nodes):
        sliders[i].set(current_values[i])


distance = np.array([[0, 4, 3, 3, 2, 3, 2, 1, 5, 4, 3, 1],
                     [0, 0, 1, 2, 3, 1, 2, 3, 1, 2, 2, 3],
                     [0, 0, 0, 1, 2, 1, 1, 2, 2, 3, 2, 2],
                     [0, 0, 0, 0, 1, 2, 1, 2, 3, 3, 2, 2],
                     [0, 0, 0, 0, 0, 3, 2, 1, 4, 4, 3, 3],
                     [0, 0, 0, 0, 0, 0, 1, 2, 1, 2, 1, 2],
                     [0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 1, 1],
                     [0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 2, 2],
                     [0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3],
                     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3],
                     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2],
                     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]])


def redispatch():
    global current_values
    with open("/home/matze/Hackover/Case 2 Redispatching Netze/edges.pkl", "rb") as f:
        edges = pickle.load(f)
    iteration = 0
    bottleneck = np.any([e.flow > 130000 for e in edges])
    while bottleneck and iteration < 30:
        for e in edges:
            if e.flow > 130000:
                if e.src in [1, 2, 5, 8, 9, 10]:
                    reduce_node = 1
                else:
                    reduce_node = 4
                remaining_cap = np.array(slider_maxs) - np.array(current_values)
                """if remaining_cap[e.dest] > 0:
                    increase_node = e.dest
                else:
                    increase_node = np.argmin([costs[node] if remaining_cap[node] > 0 else float("inf") for node in range(n_nodes)])"""
                increase_node = np.argmin(
                    [distance[min(node, e.dest), max(node, e.dest)] + costs[node] if node != reduce_node and remaining_cap[node] > 0 else float("inf") for node in range(n_nodes)])
                diffval = np.clip(e.flow - 130000, 0, current_values[reduce_node])
                diffval = np.clip(diffval, 0, slider_maxs[increase_node] - current_values[increase_node])
                current_values[reduce_node] = int(current_values[reduce_node] - diffval)
                current_values[increase_node] = int(current_values[increase_node] + diffval)
        set_sliders()
        update_cost()
        write_file()
        visualise(slider_maxs, title="scenario %i" % case, plot=False)
        with open("/home/matze/Hackover/Case 2 Redispatching Netze/edges.pkl", "rb") as f:
            edges = pickle.load(f)
        bottleneck = np.any([e.flow > 13000 for e in edges])
        iteration += 1
        print("iteration %i" % iteration)
    visualise(slider_maxs, title="scenario %i" % case, plot=True)


def update(*args):
    update_values()
    update_cost()
    write_file()
    visualise(slider_maxs, title="scenario %i" % case)


case = int(sys.argv[1])
e_mobility = False

if case == 4:
    case = 3
    e_mobility = True

n_nodes = 12

if case == 1:
    init = [-48000,
            156000,
            0,
            0,
            156000,
            0,
            0,
            -40000,
            -64000,
            -32000,
            -72000,
            -56000]
elif case == 2:
    init = [19200,
            -101300,
            10000,
            25000,
            -101300,
            30000,
            0,
            44000,
            16000,
            56000,
            19200,
            -16800]
elif case == 3:
    init = [-120000,
            270000,
            0,
            0,
            270000,
            0,
            0,
            -40000,
            -64000,
            -32000,
            -200000,
            -84000]

redispatch_cap = [0,
                  100000,
                  50000,
                  50000,
                  100000,
                  50000,
                  0,
                  0,
                  0,
                  0,
                  0,
                  0]

costs = [0,
         0.2,
         0.15,
         0.15,
         0.2,
         0.15,
         0,
         0,
         0,
         0,
         0,
         0]

if e_mobility:
    for i in range(n_nodes):
        if init[i] < 0:
            costs[i] = 0.3

master = Tk()
check_vars = []
checks = []
sliders = []
slider_mins = []
slider_maxs = []

current_values = init.copy()

Label(master, text="id").grid(row=0, column=1)
Label(master, text="min [kW]").grid(row=0, column=2)
Label(master, text="max [kW]").grid(row=0, column=4)
Label(master, text="cost [€/kW]").grid(row=0, column=5)

for i in range(n_nodes):
    row = i + 1

    # min and max range
    min_gen = min(0, init[i])
    slider_mins.append(min_gen)
    if e_mobility:
        max_gen = max(0, init[i] + redispatch_cap[i])
    else:
        max_gen = init[i] + redispatch_cap[i]
    slider_maxs.append(max_gen)

    # checkbox
    check_vars.append(IntVar())
    checks.append(Checkbutton(master, variable=check_vars[-1]))
    if max_gen > min_gen:
        checks[-1].grid(row=row, column=0)

    # node labels
    Label(master, text=str(i)).grid(row=row, column=1)
    Label(master, text=str(min_gen)).grid(row=row, column=2)
    Label(master, text=str(max_gen)).grid(row=row, column=4)
    if costs[i] > 0:
        Label(master, text="%.2f" % costs[i]).grid(row=row, column=5)

    # slider
    sliders.append(Scale(master, from_=min_gen, to=max_gen, orient=HORIZONTAL))
    sliders[-1].set(init[i])
    sliders[-1].bind("<ButtonRelease-1>", update)
    if max_gen > min_gen:
        sliders[-1].grid(row=row, column=3)

    # cost
    cost_label_var = StringVar()
    cost_label_var.set("0.00 €")
    Label(master, textvariable=cost_label_var, font=("Helvetica", 16)).grid(row=n_nodes+1, column=5)

button = Button(master, text="auto-redispatch", command=redispatch)
button.grid(row=n_nodes+2, column=5)

update()

mainloop()
