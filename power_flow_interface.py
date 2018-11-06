import re
from subprocess import Popen, PIPE, TimeoutExpired


class Edge:
    def __init__(self, src, dest, flow):
        self.src = src
        self.dest = dest
        self.flow = flow


def communicate():
    path = "/home/matze/Hackover/Case 2 Redispatching Netze/call.exe"
    p = Popen(path, stdout=PIPE)
    try:
        out, err = p.communicate(timeout=1)
        return True, out.decode()
    except TimeoutExpired:
        print("Timeout!")
        return False, ""


def flows():
    status, out = communicate()
    flows = []
    edges = []
    if status:
        lines = re.split("\n", out)
        lines = [s for s in lines if len(s) > 0]
        for line in lines:
            if line[0] != "#":
                values = line.split(";")
                edges.append(Edge(int(values[0]),
                                  int(values[1]),
                                  float(values[2].replace(",", "."))))
            else:
                values = line[1:].split(";")
                flows.append((int(values[0]), int(values[1]), float(values[2].replace(",", "."))))
    return status, edges, flows


if __name__ == "__main__":
    flow = flows()
    print(flow)
