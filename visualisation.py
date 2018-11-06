import numpy as np
import matplotlib.pyplot as plt
import numpy as np
import pickle

from power_flow_interface import flows


arrows = False

blue = "#99CCFF"
red = "#FFCCCB"
green = "#AAFCA3"
yellow = "#FFFCCC"

node_colors = [red, green, blue, blue, green, yellow, "grey", red, red, red, red, red]

def visualise(max_vals, title=None, plot=True):
    lat = [
        49.0118966894,
        49.132546,
        49.1389612416,
        49.1111618613,
        49.176789783,
        49.049147859,
        49.049147859,
        49.032040548,
        49.0110413238,
        49.0110413238,
        49.0110413238,
        49.0110413238
    ]

    lon = [
        9.0532191551,
        8.562129,
        8.8854502687,
        9.1084763677,
        9.2083388001,
        8.6657529174,
        8.8921077642,
        9.1850375659,
        8.562129,
        8.6657529174,
        8.7922453318,
        8.9468989521
    ]

    n_nodes = 12
    ids = range(n_nodes)
    in_flow = [0] * n_nodes
    out_flow = [0] * n_nodes

    status, edges, flowvals = flows()
    if status:
        with open("/home/matze/Hackover/Case 2 Redispatching Netze/edges.pkl", "wb") as f:
            pickle.dump(edges, f)

        plt.clf()
        plt.figure(1)

        for edge in edges:
            src = edge.src
            dest = edge.dest

            edge.label_lon = (lon[src] + lon[dest]) / 2
            edge.label_lat = (lat[src] + lat[dest]) / 2
            usage = int(edge.flow) / 130000
            label = "%i%%" % (usage * 100)

            if usage <= 1:
                color = "grey"
            else:
                color = [1, 0, 0]

            if not arrows:
                plt.plot([lon[src], lon[dest]], [lat[src], lat[dest]], color=color, linewidth=0.1+usage*10)
            else:
                plt.arrow(lon[src], lat[src], lon[dest] - lon[src], lat[dest] - lat[src],
                          color=color, width=max(0.001, usage*0.01), length_includes_head=True, head_width=0.01)
            plt.text(edge.label_lon, edge.label_lat, label)

            out_flow[src] += edge.flow
            in_flow[dest] += edge.flow

        for i in range(12):
            generation = out_flow[i] - in_flow[i]
            if np.abs(generation) < 0.1:
                marker = "o"
            elif generation > 0:
                marker = "o"
            else:
                marker = "v"
            markersize = min(30, np.sqrt(np.abs(generation) / 130))
            if max_vals[i] > 0:
                maxmarkersize = min(30, np.sqrt(np.abs(max_vals[i]) / 130))
                markersize = maxmarkersize * generation / max_vals[i]
                plt.plot(lon[i], lat[i], marker, markersize=maxmarkersize, color="white")
                plt.plot(lon[i], lat[i], marker, markersize=maxmarkersize, color="black", fillstyle="none")
            plt.plot(lon[i], lat[i], marker, markersize=markersize, color=node_colors[i])
            if generation < 0:
                plt.plot(lon[i], lat[i], marker, markersize=markersize, color="black", fillstyle="none")
            label = str(i)

            eps = 0.0015
            plt.text(lon[i] - 2 * eps, lat[i] - eps, label)

        plt.xticks([])
        plt.yticks([])
        if title is not None:
            plt.title(title)

        if plot:
            plt.show()


if __name__ == "__main__":
    visualise([0] * 12)
