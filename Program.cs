using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project2
{
    class Class1
    {
        public class Edge
        {
            public int src;
            public int dest;
            public double capacity;
            public double flow;

            public Edge(int src, int dest, double capacity, double flow)
            {
                this.src = src;
                this.dest = dest;
                this.capacity = capacity;
                this.flow = flow;
            }
        }

        public class Vertex
        {
            public int ID;
            public double feedTotal;
            public double consumptionTotal;
            public double feedRemaining;
            public double consumptionRemaining;
            public double leitwertRamaining;
            public double reserveCapacity;
            public double specificCostsResCapa;




            public Vertex(int ID, double feedTotal, double consumptionTotal, double feedRemaining, double consumptionRemaining, double reserveCapacity, double specificCostsResCapa)
            {
                this.ID = ID;
                this.feedTotal = feedTotal;
                this.consumptionTotal = consumptionTotal;
                this.feedRemaining = feedRemaining;
                this.consumptionRemaining = consumptionRemaining;
                this.reserveCapacity = reserveCapacity;
                this.specificCostsResCapa = specificCostsResCapa;


            }
        }

        public class Feed_Cons
        {
            public int src;
            public int dest;
            public double resistance;
            public double flow;

            public Feed_Cons(int src, int dest, double resistance, double flow)
            {
                this.src = src;
                this.dest = dest;
                this.resistance = resistance;
                this.flow = flow;
            }
        }
        public class PathGroup
        {
            public int pathGroupSrc;
            public int pathGroupdest;
            public int edgeSrc;
            public int edgeDest;
            public double flowShare;
            public double flow;


            public PathGroup(int pathGroupSrc, int pathGroupdest, int edgeSrc, int edgeDest, double flowShare, double flow)
            {
                this.pathGroupSrc = pathGroupSrc;
                this.pathGroupdest = pathGroupdest;
                this.edgeSrc = edgeSrc;
                this.edgeDest = edgeDest;
                this.flowShare = flowShare;
                this.flow = flow;
            }
        }

        public static void Main(string[] args)
        {

            int v_total = 12;
            int e_total = 36;

            // Widerstände von Feed zu Consumption aus EXCEL-Berechnung

            Feed_Cons[,] feed_cons = new Feed_Cons[v_total, v_total];


            feed_cons[0, 0] = new Feed_Cons(0, 0, 999999999, 0);
            feed_cons[1, 0] = new Feed_Cons(1, 0, 2.80516239510504, 0);
            feed_cons[2, 0] = new Feed_Cons(2, 0, 1.96737329499112, 0);
            feed_cons[3, 0] = new Feed_Cons(3, 0, 1.62531946285445, 0);
            feed_cons[4, 0] = new Feed_Cons(4, 0, 2.58845160330614, 0);
            feed_cons[5, 0] = new Feed_Cons(5, 0, 2.19635405561009, 0);
            feed_cons[6, 0] = new Feed_Cons(6, 0, 1.33761911943027, 0);
            feed_cons[7, 0] = new Feed_Cons(7, 0, 0.968801058156133, 0);
            feed_cons[8, 0] = new Feed_Cons(8, 0, 2.50486680065372, 0);
            feed_cons[9, 0] = new Feed_Cons(9, 0, 3.07252290335162, 0);
            feed_cons[10, 0] = new Feed_Cons(10, 0, 2.16810214046393, 0);
            feed_cons[11, 0] = new Feed_Cons(11, 0, 0.760249062556896, 0);
            feed_cons[0, 1] = new Feed_Cons(0, 1, 2.80516239510504, 0);
            feed_cons[1, 1] = new Feed_Cons(1, 1, 999999999, 0);
            feed_cons[2, 1] = new Feed_Cons(2, 1, 2.3128494794322, 0);
            feed_cons[3, 1] = new Feed_Cons(3, 1, 3.93722587294865, 0);
            feed_cons[4, 1] = new Feed_Cons(4, 1, 4.95867592195045, 0);
            feed_cons[5, 1] = new Feed_Cons(5, 1, 1.18766321931718, 0);
            feed_cons[6, 1] = new Feed_Cons(6, 1, 1.46754327567477, 0);
            feed_cons[7, 1] = new Feed_Cons(7, 1, 2.56757548021025, 0);
            feed_cons[8, 1] = new Feed_Cons(8, 1, 1.35234704598097, 0);
            feed_cons[9, 1] = new Feed_Cons(9, 1, 2.09325805515712, 0);
            feed_cons[10, 1] = new Feed_Cons(10, 1, 2.18659242445384, 0);
            feed_cons[11, 1] = new Feed_Cons(11, 1, 2.04491333254814, 0);
            feed_cons[0, 2] = new Feed_Cons(0, 2, 1.96737329499112, 0);
            feed_cons[1, 2] = new Feed_Cons(1, 2, 2.3128494794322, 0);
            feed_cons[2, 2] = new Feed_Cons(2, 2, 999999999, 0);
            feed_cons[3, 2] = new Feed_Cons(3, 2, 1.62437639351644, 0);
            feed_cons[4, 2] = new Feed_Cons(4, 2, 2.64582644251825, 0);
            feed_cons[5, 2] = new Feed_Cons(5, 2, 1.86192695138924, 0);
            feed_cons[6, 2] = new Feed_Cons(6, 2, 0.629754175560854, 0);
            feed_cons[7, 2] = new Feed_Cons(7, 2, 1.72978638009633, 0);
            feed_cons[8, 2] = new Feed_Cons(8, 2, 2.71564339380501, 0);
            feed_cons[9, 2] = new Feed_Cons(9, 2, 2.36465795948221, 0);
            feed_cons[10, 2] = new Feed_Cons(10, 2, 1.46023719659452, 0);
            feed_cons[11, 2] = new Feed_Cons(11, 2, 1.20712423243422, 0);
            feed_cons[0, 3] = new Feed_Cons(0, 3, 1.62531946285445, 0);
            feed_cons[1, 3] = new Feed_Cons(1, 3, 3.93722587294865, 0);
            feed_cons[2, 3] = new Feed_Cons(2, 3, 1.62437639351644, 0);
            feed_cons[3, 3] = new Feed_Cons(3, 3, 999999999, 0);
            feed_cons[4, 3] = new Feed_Cons(4, 3, 1.0214500490018, 0);
            feed_cons[5, 3] = new Feed_Cons(5, 3, 1.69636923958814, 0);
            feed_cons[6, 3] = new Feed_Cons(6, 3, 1.02960773100649, 0);
            feed_cons[7, 3] = new Feed_Cons(7, 3, 1.5576607976382, 0);
            feed_cons[8, 3] = new Feed_Cons(8, 3, 2.55008568200391, 0);
            feed_cons[9, 3] = new Feed_Cons(9, 3, 2.76451151492784, 0);
            feed_cons[10, 3] = new Feed_Cons(10, 3, 1.86009075204016, 0);
            feed_cons[11, 3] = new Feed_Cons(11, 3, 1.60697778787986, 0);
            feed_cons[0, 4] = new Feed_Cons(0, 4, 2.58845160330614, 0);
            feed_cons[1, 4] = new Feed_Cons(1, 4, 4.95867592195045, 0);
            feed_cons[2, 4] = new Feed_Cons(2, 4, 2.64582644251825, 0);
            feed_cons[3, 4] = new Feed_Cons(3, 4, 1.0214500490018, 0);
            feed_cons[4, 4] = new Feed_Cons(4, 4, 999999999, 0);
            feed_cons[5, 4] = new Feed_Cons(5, 4, 2.71781928858994, 0);
            feed_cons[6, 4] = new Feed_Cons(6, 4, 1.32244874144521, 0);
            feed_cons[7, 4] = new Feed_Cons(7, 4, 1.61965054515, 0);
            feed_cons[8, 4] = new Feed_Cons(8, 4, 3.57153573100571, 0);
            feed_cons[9, 4] = new Feed_Cons(9, 4, 3.78596156392964, 0);
            feed_cons[10, 4] = new Feed_Cons(10, 4, 2.88154080104196, 0);
            feed_cons[11, 4] = new Feed_Cons(11, 4, 1.62531946285445, 0);
            feed_cons[0, 5] = new Feed_Cons(0, 5, 2.19635405561009, 0);
            feed_cons[1, 5] = new Feed_Cons(1, 5, 1.18766321931718, 0);
            feed_cons[2, 5] = new Feed_Cons(2, 5, 1.86192695138924, 0);
            feed_cons[3, 5] = new Feed_Cons(3, 5, 1.69636923958814, 0);
            feed_cons[4, 5] = new Feed_Cons(4, 5, 2.71781928858994, 0);
            feed_cons[5, 5] = new Feed_Cons(5, 5, 999999999, 0);
            feed_cons[6, 5] = new Feed_Cons(6, 5, 1.61843715464112, 0);
            feed_cons[7, 5] = new Feed_Cons(7, 5, 1.9587671407153, 0);
            feed_cons[8, 5] = new Feed_Cons(8, 5, 0.853716442415769, 0);
            feed_cons[9, 5] = new Feed_Cons(9, 5, 0.867682590510027, 0);
            feed_cons[10, 5] = new Feed_Cons(10, 5, 0.998929205136661, 0);
            feed_cons[11, 5] = new Feed_Cons(11, 5, 1.4361049930532, 0);
            feed_cons[0, 6] = new Feed_Cons(0, 6, 1.33761911943027, 0);
            feed_cons[1, 6] = new Feed_Cons(1, 6, 1.46754327567477, 0);
            feed_cons[2, 6] = new Feed_Cons(2, 6, 0.629754175560854, 0);
            feed_cons[3, 6] = new Feed_Cons(3, 6, 1.02960773100649, 0);
            feed_cons[4, 6] = new Feed_Cons(4, 6, 1.32244874144521, 0);
            feed_cons[5, 6] = new Feed_Cons(5, 6, 1.61843715464112, 0);
            feed_cons[6, 6] = new Feed_Cons(6, 6, 999999999, 0);
            feed_cons[7, 6] = new Feed_Cons(7, 6, 1.10003220453547, 0);
            feed_cons[8, 6] = new Feed_Cons(8, 6, 1.16724768122345, 0);
            feed_cons[9, 6] = new Feed_Cons(9, 6, 1.73490378392135, 0);
            feed_cons[10, 6] = new Feed_Cons(10, 6, 0.83048302103367, 0);
            feed_cons[11, 6] = new Feed_Cons(11, 6, 0.57737005687337, 0);
            feed_cons[0, 7] = new Feed_Cons(0, 7, 0.968801058156133, 0);
            feed_cons[1, 7] = new Feed_Cons(1, 7, 2.56757548021025, 0);
            feed_cons[2, 7] = new Feed_Cons(2, 7, 1.72978638009633, 0);
            feed_cons[3, 7] = new Feed_Cons(3, 7, 1.5576607976382, 0);
            feed_cons[4, 7] = new Feed_Cons(4, 7, 1.61965054515, 0);
            feed_cons[5, 7] = new Feed_Cons(5, 7, 1.9587671407153, 0);
            feed_cons[6, 7] = new Feed_Cons(6, 7, 1.10003220453547, 0);
            feed_cons[7, 7] = new Feed_Cons(7, 7, 999999999, 0);
            feed_cons[8, 7] = new Feed_Cons(8, 7, 2.26727988575893, 0);
            feed_cons[9, 7] = new Feed_Cons(9, 7, 2.83493598845683, 0);
            feed_cons[10, 7] = new Feed_Cons(10, 7, 1.93051522556914, 0);
            feed_cons[11, 7] = new Feed_Cons(11, 7, 1.72905012071303, 0);
            feed_cons[0, 8] = new Feed_Cons(0, 8, 2.50486680065372, 0);
            feed_cons[1, 8] = new Feed_Cons(1, 8, 1.35234704598097, 0);
            feed_cons[2, 8] = new Feed_Cons(2, 8, 2.71564339380501, 0);
            feed_cons[3, 8] = new Feed_Cons(3, 8, 2.55008568200391, 0);
            feed_cons[4, 8] = new Feed_Cons(4, 8, 3.57153573100571, 0);
            feed_cons[5, 8] = new Feed_Cons(5, 8, 0.853716442415769, 0);
            feed_cons[6, 8] = new Feed_Cons(6, 8, 1.16724768122345, 0);
            feed_cons[7, 8] = new Feed_Cons(7, 8, 2.26727988575893, 0);
            feed_cons[8, 8] = new Feed_Cons(8, 8, 999999999, 0);
            feed_cons[9, 8] = new Feed_Cons(9, 8, 0.740911009176148, 0);
            feed_cons[10, 8] = new Feed_Cons(10, 8, 0.871422648185129, 0);
            feed_cons[11, 8] = new Feed_Cons(11, 8, 1.74461773809682, 0);
            feed_cons[0, 9] = new Feed_Cons(0, 9, 3.07252290335162, 0);
            feed_cons[1, 9] = new Feed_Cons(1, 9, 2.09325805515712, 0);
            feed_cons[2, 9] = new Feed_Cons(2, 9, 2.36465795948221, 0);
            feed_cons[3, 9] = new Feed_Cons(3, 9, 2.76451151492784, 0);
            feed_cons[4, 9] = new Feed_Cons(4, 9, 3.78596156392965, 0);
            feed_cons[5, 9] = new Feed_Cons(5, 9, 0.867682590510027, 0);
            feed_cons[6, 9] = new Feed_Cons(6, 9, 1.73490378392135, 0);
            feed_cons[7, 9] = new Feed_Cons(7, 9, 2.83493598845683, 0);
            feed_cons[8, 9] = new Feed_Cons(8, 9, 0.740911009176148, 0);
            feed_cons[9, 9] = new Feed_Cons(9, 9, 999999999, 0);
            feed_cons[10, 9] = new Feed_Cons(10, 9, 0.904420762887685, 0);
            feed_cons[11, 9] = new Feed_Cons(11, 9, 2.31227384079472, 0);
            feed_cons[0, 10] = new Feed_Cons(0, 10, 2.16810214046394, 0);
            feed_cons[1, 10] = new Feed_Cons(1, 10, 2.18659242445384, 0);
            feed_cons[2, 10] = new Feed_Cons(2, 10, 1.46023719659452, 0);
            feed_cons[3, 10] = new Feed_Cons(3, 10, 1.86009075204016, 0);
            feed_cons[4, 10] = new Feed_Cons(4, 10, 2.88154080104196, 0);
            feed_cons[5, 10] = new Feed_Cons(5, 10, 0.998929205136661, 0);
            feed_cons[6, 10] = new Feed_Cons(6, 10, 0.83048302103367, 0);
            feed_cons[7, 10] = new Feed_Cons(7, 10, 1.93051522556914, 0);
            feed_cons[8, 10] = new Feed_Cons(8, 10, 0.871422648185129, 0);
            feed_cons[9, 10] = new Feed_Cons(9, 10, 0.904420762887685, 0);
            feed_cons[10, 10] = new Feed_Cons(10, 10, 999999999, 0);
            feed_cons[11, 10] = new Feed_Cons(11, 10, 1.40785307790704, 0);
            feed_cons[0, 11] = new Feed_Cons(0, 11, 0.760249062556896, 0);
            feed_cons[1, 11] = new Feed_Cons(1, 11, 2.04491333254814, 0);
            feed_cons[2, 11] = new Feed_Cons(2, 11, 1.20712423243422, 0);
            feed_cons[3, 11] = new Feed_Cons(3, 11, 1.60697778787986, 0);
            feed_cons[4, 11] = new Feed_Cons(4, 11, 1.62531946285445, 0);
            feed_cons[5, 11] = new Feed_Cons(5, 11, 1.4361049930532, 0);
            feed_cons[6, 11] = new Feed_Cons(6, 11, 0.57737005687337, 0);
            feed_cons[7, 11] = new Feed_Cons(7, 11, 1.72905012071303, 0);
            feed_cons[8, 11] = new Feed_Cons(8, 11, 1.74461773809682, 0);
            feed_cons[9, 11] = new Feed_Cons(9, 11, 2.31227384079472, 0);
            feed_cons[10, 11] = new Feed_Cons(10, 11, 1.40785307790704, 0);
            feed_cons[11, 11] = new Feed_Cons(11, 11, 999999999, 0);


            Edge[,] edge = new Edge[v_total, v_total];

            edge[0, 0] = new Edge(0, 0, 130000, 0);
            edge[1, 0] = new Edge(1, 0, 130000, 0);
            edge[2, 0] = new Edge(2, 0, 130000, 0);
            edge[3, 0] = new Edge(3, 0, 130000, 0);
            edge[4, 0] = new Edge(4, 0, 130000, 0);
            edge[5, 0] = new Edge(5, 0, 130000, 0);
            edge[6, 0] = new Edge(6, 0, 130000, 0);
            edge[7, 0] = new Edge(7, 0, 130000, 0);
            edge[8, 0] = new Edge(8, 0, 130000, 0);
            edge[9, 0] = new Edge(9, 0, 130000, 0);
            edge[10, 0] = new Edge(10, 0, 130000, 0);
            edge[11, 0] = new Edge(11, 0, 130000, 0);
            edge[0, 1] = new Edge(0, 1, 130000, 0);
            edge[1, 1] = new Edge(1, 1, 130000, 0);
            edge[2, 1] = new Edge(2, 1, 130000, 0);
            edge[3, 1] = new Edge(3, 1, 130000, 0);
            edge[4, 1] = new Edge(4, 1, 130000, 0);
            edge[5, 1] = new Edge(5, 1, 130000, 0);
            edge[6, 1] = new Edge(6, 1, 130000, 0);
            edge[7, 1] = new Edge(7, 1, 130000, 0);
            edge[8, 1] = new Edge(8, 1, 130000, 0);
            edge[9, 1] = new Edge(9, 1, 130000, 0);
            edge[10, 1] = new Edge(10, 1, 130000, 0);
            edge[11, 1] = new Edge(11, 1, 130000, 0);
            edge[0, 2] = new Edge(0, 2, 130000, 0);
            edge[1, 2] = new Edge(1, 2, 130000, 0);
            edge[2, 2] = new Edge(2, 2, 130000, 0);
            edge[3, 2] = new Edge(3, 2, 130000, 0);
            edge[4, 2] = new Edge(4, 2, 130000, 0);
            edge[5, 2] = new Edge(5, 2, 130000, 0);
            edge[6, 2] = new Edge(6, 2, 130000, 0);
            edge[7, 2] = new Edge(7, 2, 130000, 0);
            edge[8, 2] = new Edge(8, 2, 130000, 0);
            edge[9, 2] = new Edge(9, 2, 130000, 0);
            edge[10, 2] = new Edge(10, 2, 130000, 0);
            edge[11, 2] = new Edge(11, 2, 130000, 0);
            edge[0, 3] = new Edge(0, 3, 130000, 0);
            edge[1, 3] = new Edge(1, 3, 130000, 0);
            edge[2, 3] = new Edge(2, 3, 130000, 0);
            edge[3, 3] = new Edge(3, 3, 130000, 0);
            edge[4, 3] = new Edge(4, 3, 130000, 0);
            edge[5, 3] = new Edge(5, 3, 130000, 0);
            edge[6, 3] = new Edge(6, 3, 130000, 0);
            edge[7, 3] = new Edge(7, 3, 130000, 0);
            edge[8, 3] = new Edge(8, 3, 130000, 0);
            edge[9, 3] = new Edge(9, 3, 130000, 0);
            edge[10, 3] = new Edge(10, 3, 130000, 0);
            edge[11, 3] = new Edge(11, 3, 130000, 0);
            edge[0, 4] = new Edge(0, 4, 130000, 0);
            edge[1, 4] = new Edge(1, 4, 130000, 0);
            edge[2, 4] = new Edge(2, 4, 130000, 0);
            edge[3, 4] = new Edge(3, 4, 130000, 0);
            edge[4, 4] = new Edge(4, 4, 130000, 0);
            edge[5, 4] = new Edge(5, 4, 130000, 0);
            edge[6, 4] = new Edge(6, 4, 130000, 0);
            edge[7, 4] = new Edge(7, 4, 130000, 0);
            edge[8, 4] = new Edge(8, 4, 130000, 0);
            edge[9, 4] = new Edge(9, 4, 130000, 0);
            edge[10, 4] = new Edge(10, 4, 130000, 0);
            edge[11, 4] = new Edge(11, 4, 130000, 0);
            edge[0, 5] = new Edge(0, 5, 130000, 0);
            edge[1, 5] = new Edge(1, 5, 130000, 0);
            edge[2, 5] = new Edge(2, 5, 130000, 0);
            edge[3, 5] = new Edge(3, 5, 130000, 0);
            edge[4, 5] = new Edge(4, 5, 130000, 0);
            edge[5, 5] = new Edge(5, 5, 130000, 0);
            edge[6, 5] = new Edge(6, 5, 130000, 0);
            edge[7, 5] = new Edge(7, 5, 130000, 0);
            edge[8, 5] = new Edge(8, 5, 130000, 0);
            edge[9, 5] = new Edge(9, 5, 130000, 0);
            edge[10, 5] = new Edge(10, 5, 130000, 0);
            edge[11, 5] = new Edge(11, 5, 130000, 0);
            edge[0, 6] = new Edge(0, 6, 130000, 0);
            edge[1, 6] = new Edge(1, 6, 130000, 0);
            edge[2, 6] = new Edge(2, 6, 130000, 0);
            edge[3, 6] = new Edge(3, 6, 130000, 0);
            edge[4, 6] = new Edge(4, 6, 130000, 0);
            edge[5, 6] = new Edge(5, 6, 130000, 0);
            edge[6, 6] = new Edge(6, 6, 130000, 0);
            edge[7, 6] = new Edge(7, 6, 130000, 0);
            edge[8, 6] = new Edge(8, 6, 130000, 0);
            edge[9, 6] = new Edge(9, 6, 130000, 0);
            edge[10, 6] = new Edge(10, 6, 130000, 0);
            edge[11, 6] = new Edge(11, 6, 130000, 0);
            edge[0, 7] = new Edge(0, 7, 130000, 0);
            edge[1, 7] = new Edge(1, 7, 130000, 0);
            edge[2, 7] = new Edge(2, 7, 130000, 0);
            edge[3, 7] = new Edge(3, 7, 130000, 0);
            edge[4, 7] = new Edge(4, 7, 130000, 0);
            edge[5, 7] = new Edge(5, 7, 130000, 0);
            edge[6, 7] = new Edge(6, 7, 130000, 0);
            edge[7, 7] = new Edge(7, 7, 130000, 0);
            edge[8, 7] = new Edge(8, 7, 130000, 0);
            edge[9, 7] = new Edge(9, 7, 130000, 0);
            edge[10, 7] = new Edge(10, 7, 130000, 0);
            edge[11, 7] = new Edge(11, 7, 130000, 0);
            edge[0, 8] = new Edge(0, 8, 130000, 0);
            edge[1, 8] = new Edge(1, 8, 130000, 0);
            edge[2, 8] = new Edge(2, 8, 130000, 0);
            edge[3, 8] = new Edge(3, 8, 130000, 0);
            edge[4, 8] = new Edge(4, 8, 130000, 0);
            edge[5, 8] = new Edge(5, 8, 130000, 0);
            edge[6, 8] = new Edge(6, 8, 130000, 0);
            edge[7, 8] = new Edge(7, 8, 130000, 0);
            edge[8, 8] = new Edge(8, 8, 130000, 0);
            edge[9, 8] = new Edge(9, 8, 130000, 0);
            edge[10, 8] = new Edge(10, 8, 130000, 0);
            edge[11, 8] = new Edge(11, 8, 130000, 0);
            edge[0, 9] = new Edge(0, 9, 130000, 0);
            edge[1, 9] = new Edge(1, 9, 130000, 0);
            edge[2, 9] = new Edge(2, 9, 130000, 0);
            edge[3, 9] = new Edge(3, 9, 130000, 0);
            edge[4, 9] = new Edge(4, 9, 130000, 0);
            edge[5, 9] = new Edge(5, 9, 130000, 0);
            edge[6, 9] = new Edge(6, 9, 130000, 0);
            edge[7, 9] = new Edge(7, 9, 130000, 0);
            edge[8, 9] = new Edge(8, 9, 130000, 0);
            edge[9, 9] = new Edge(9, 9, 130000, 0);
            edge[10, 9] = new Edge(10, 9, 130000, 0);
            edge[11, 9] = new Edge(11, 9, 130000, 0);
            edge[0, 10] = new Edge(0, 10, 130000, 0);
            edge[1, 10] = new Edge(1, 10, 130000, 0);
            edge[2, 10] = new Edge(2, 10, 130000, 0);
            edge[3, 10] = new Edge(3, 10, 130000, 0);
            edge[4, 10] = new Edge(4, 10, 130000, 0);
            edge[5, 10] = new Edge(5, 10, 130000, 0);
            edge[6, 10] = new Edge(6, 10, 130000, 0);
            edge[7, 10] = new Edge(7, 10, 130000, 0);
            edge[8, 10] = new Edge(8, 10, 130000, 0);
            edge[9, 10] = new Edge(9, 10, 130000, 0);
            edge[10, 10] = new Edge(10, 10, 130000, 0);
            edge[11, 10] = new Edge(11, 10, 130000, 0);
            edge[0, 11] = new Edge(0, 11, 130000, 0);
            edge[1, 11] = new Edge(1, 11, 130000, 0);
            edge[2, 11] = new Edge(2, 11, 130000, 0);
            edge[3, 11] = new Edge(3, 11, 130000, 0);
            edge[4, 11] = new Edge(4, 11, 130000, 0);
            edge[5, 11] = new Edge(5, 11, 130000, 0);
            edge[6, 11] = new Edge(6, 11, 130000, 0);
            edge[7, 11] = new Edge(7, 11, 130000, 0);
            edge[8, 11] = new Edge(8, 11, 130000, 0);
            edge[9, 11] = new Edge(9, 11, 130000, 0);
            edge[10, 11] = new Edge(10, 11, 130000, 0);
            edge[11, 11] = new Edge(11, 11, 130000, 0);


            // xxxxxxxxxxxxxxxxxx Liste aller Vertics erstellen  xxxxxxxxxxxxxxxx
            Vertex[] vertex = new Vertex[v_total];

            // xxxxxxxxxxxx Vertics mit EXCEL-Werten belegen xxxxxxxxxxxxxxxx
            // ID, feedTotal, consumptionTotal, feedRemaining, consumptionRemaining)

            StreamReader VertexReader = new StreamReader(File.OpenRead(@"vertex.csv"));
            List<string> VertexA = new List<String>();
            List<string> VertexB = new List<String>();
            List<string> VertexC = new List<String>();
            List<string> VertexD = new List<String>();
            List<string> VertexE = new List<String>();
            List<string> VertexF = new List<String>();
            List<string> VertexG = new List<String>();


            while (!VertexReader.EndOfStream)
            {
                string vertexline = VertexReader.ReadLine();
                if (!String.IsNullOrWhiteSpace(vertexline))
                {
                    string[] values = vertexline.Split(',');
                    if (values.Length >= 7)
                    {
                        VertexA.Add(values[0]);
                        VertexB.Add(values[1]);
                        VertexC.Add(values[2]);
                        VertexD.Add(values[3]);
                        VertexE.Add(values[4]);
                        VertexF.Add(values[5]);
                        VertexG.Add(values[6]);
                    }
                }
            }

            string[] firstVertexA = VertexA.ToArray();
            string[] firstVertexB = VertexB.ToArray();
            string[] firstVertexC = VertexC.ToArray();
            string[] firstVertexD = VertexD.ToArray();
            string[] firstVertexE = VertexE.ToArray();
            string[] firstVertexF = VertexF.ToArray();
            string[] firstVertexG = VertexG.ToArray();

            for (int zl = 0; zl <= 11; zl++)
            {
                vertex[zl] = new Vertex(Convert.ToInt32(firstVertexA[zl]), Convert.ToDouble(firstVertexB[zl]), Convert.ToDouble(firstVertexC[zl]),
                                        Convert.ToDouble(firstVertexD[zl]), Convert.ToDouble(firstVertexE[zl]), Convert.ToDouble(firstVertexF[zl]),
                                        Convert.ToDouble(firstVertexG[zl]));
            }

            //vertex[0] = new Vertex(0, 0, 48000, 0, 48000, 0, 99999999);
            //vertex[1] = new Vertex(1, 156000, 0, 156000, 0, 100000, 0.2);
            //vertex[2] = new Vertex(2, 0, 0, 0, 0, 50000, 0.15);
            //vertex[3] = new Vertex(3, 0, 0, 0, 0, 50000, 0.15);
            //vertex[4] = new Vertex(4, 156000, 0, 156000, 0, 100000, 0.2);
            //vertex[5] = new Vertex(5, 0, 0, 0, 0, 50000, 0.15);
            //vertex[6] = new Vertex(6, 0, 0, 0, 0, 0, 99999999);
            //vertex[7] = new Vertex(7, 0, 40000, 0, 40000, 0, 99999999);
            //vertex[8] = new Vertex(8, 0, 64000, 0, 64000, 0, 99999999);
            //vertex[9] = new Vertex(9, 0, 32000, 0, 32000, 0, 99999999);
            //vertex[10] = new Vertex(10, 0, 72000, 0, 72000, 0, 99999999);
            //vertex[11] = new Vertex(11, 0, 56000, 0, 56000, 0, 99999999);


            // Zwei getrennte Listen für Einspeiser und Konsumenten erstellen und Daten aus den obigen Vertics ziehen
            List<Vertex> v_Feed = new List<Vertex>();
            List<Vertex> v_Consumption = new List<Vertex>();

            foreach (Vertex vertexElement in vertex)
            {
                if (vertexElement.consumptionTotal > 0)
                {
                    v_Consumption.Add(vertexElement);
                }
                if (vertexElement.feedTotal > 0)
                {
                    v_Feed.Add(vertexElement);
                }
            }

            // xxxxxxxx Berechnung solange noch ein Einspeiser in der Einspeiserliste enthalten ist  xxxxx
            while (v_Feed.Count > 0)
            {


                // Leitwerte zwischen den Verbrauchern und den verbleibenden Einspeisern aufaddieren
                int c = 0;
                foreach (Vertex vertexElement in v_Consumption)
                {
                    v_Consumption[c].leitwertRamaining = 0;
                    c++;
                }

                c = 0; int f;
                foreach (Vertex v_ConsumptionElement in v_Consumption)
                {
                    f = 0;
                    foreach (Vertex v_FeedElement in v_Feed)
                    {
                        v_Consumption[c].leitwertRamaining += 1 / feed_cons[v_FeedElement.ID, v_FeedElement.ID].resistance;
                        f++;
                    }
                    c++;
                }

                // Ermittlung des Flusses zwischen den Verbrauchern und den verbleibenden Einspeisern
                c = 0;

                foreach (Vertex v_ConsumptionElement in v_Consumption)
                {

                    f = 0; // Feed-Item
                    foreach (Vertex v_FeedElement in v_Feed)
                    {
                        if (Double.IsNaN(v_ConsumptionElement.consumptionRemaining))
                        {
                            Console.WriteLine("v_ConsumptionElement.consumptionRemaining weist ungültigen Wert auf");
                            Console.ReadKey();
                        }
                        else
                        {

                            feed_cons[v_FeedElement.ID, v_ConsumptionElement.ID].flow = v_ConsumptionElement.consumptionRemaining * (1 / feed_cons[v_FeedElement.ID, v_ConsumptionElement.ID].resistance) / v_ConsumptionElement.leitwertRamaining;
                            f++;
                        }
                    }
                    c++; // Consumption-Item
                }

                // Ermittlung des Einspeisers, der maximal überlastet ist

                double[] v_flow = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                foreach (Vertex v_ConsumptionElement in v_Consumption)
                {
                    foreach (Vertex v_FeedElement in v_Feed)
                    {
                        if (Double.IsNaN(feed_cons[v_FeedElement.ID, v_ConsumptionElement.ID].flow))
                        {
                            Console.WriteLine("feed_cons[v_FeedElement.ID, v_ConsumptionElement.ID].flow weist ungültigen Wert auf");
                            Console.ReadKey();
                        }
                        else
                        {
                            v_flow[v_FeedElement.ID] += feed_cons[v_FeedElement.ID, v_ConsumptionElement.ID].flow;
                        }

                    }
                }

                int v = 0;
                double maxOverload = 0;
                int ID_maxOverload = 0;
                int listItem_maxOverload = 9999999;

                foreach (Vertex vertexElement in v_Feed)
                {
                    if (v_flow[vertexElement.ID] / vertexElement.feedTotal > maxOverload)
                    {
                        if (v_flow[vertexElement.ID] / vertexElement.feedTotal > 1)
                        {

                            ID_maxOverload = vertexElement.ID;
                            listItem_maxOverload = v;
                            maxOverload = v_flow[vertexElement.ID] / vertexElement.feedTotal;
                        }
                        else
                        {
                            Console.WriteLine("Kein Einspeiser überlastet");
                        }
                    }
                    v++;
                }



                // Die Flüsse vom max. überlasteten Einspeiser werden prozentual auf die verfügbare Einspeisemenge reduziert;
                foreach (Vertex vertexElement in v_Consumption)
                {
                    if (v_Feed.Count > 1)
                    {
                        feed_cons[ID_maxOverload, vertexElement.ID].flow = feed_cons[ID_maxOverload, vertexElement.ID].flow * 1 / (maxOverload);
                    }
                    else
                    {
                        feed_cons[ID_maxOverload, vertexElement.ID].flow = vertexElement.consumptionRemaining;
                    }
                }

                c = 0;
                foreach (Vertex vertexElement in v_Consumption)
                {
                    v_Consumption[c].consumptionRemaining -= feed_cons[ID_maxOverload, vertexElement.ID].flow;

                    c++;
                }

                // Der Einspeiser wird aus der weiteren Berechnung herausgenommen.

                if (listItem_maxOverload < v_total)
                {
                    v_Feed.RemoveAt(listItem_maxOverload); // delete v_feed[ID_maxOverload]
                }
            } // end while, solange noch Feeds in v_feed-Liste sind

            for (int s = 0; s < v_total; s++)
            {
                for (int d = 0; d < v_total; d++)
                {
                    if (!(feed_cons[s, d].flow == 0))
                    {
                        // Console.WriteLine("feed cons flow von " + s + " nach " + d + "   " + feed_cons[s, d].flow);
                        Console.WriteLine("#"+ s + ";" + d + ";" + feed_cons[s, d].flow);
                    }
                }
            }

            // Kanten je Pfadgruppe einlesen 

            List<PathGroup> pathGroupList = new List<PathGroup>();
            PathGroup pathGroup;
            {
                
                    pathGroup = new PathGroup(6, 11, 6, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 6, 11, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 9, 8, 9, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 8, 9, 8, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 0, 11, 0, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 11, 0, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 10, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 6, 10, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 8, 5, 8, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 5, 8, 5, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 10, 9, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 9, 10, 9, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 0, 7, 0, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 7, 0, 7, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 10, 5, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 5, 10, 5, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 4, 3, 4, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 3, 4, 3, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 5, 1, 5, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 1, 5, 1, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 8, 1, 8, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 1, 8, 1, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 6, 5, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 5, 6, 5, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 7, 4, 7, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 4, 7, 4, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 3, 2, 3, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 2, 3, 2, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 5, 2, 5, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 2, 5, 2, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 2, 1, 2, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 1, 2, 1, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 6, 2, 5, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 6, 5, 6, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 6, 2, 6, 0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 6, 2, 3, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 6, 3, 6, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 6, 3, 6, 0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 6, 3, 2, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 6, 2, 6, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 2, 5, 2, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 2, 6, 5, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 2, 6, 2, 0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 2, 3, 2, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 2, 6, 3, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 3, 6, 3, 0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 3, 2, 3, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 3, 6, 2, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 7, 6, 7, 0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 7, 6, 11, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 7, 11, 0, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 7, 0, 7, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 6, 7, 6, 0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 6, 11, 6, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 6, 0, 11, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 6, 7, 0, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 3, 0, 7, 0.458672932246141, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 3, 7, 4, 0.387406846915549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 3, 0, 11, 0.444253113503299, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 3, 4, 3, 0.387406846915549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 3, 11, 6, 0.444253113503299, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 3, 6, 3, 0.51551919883389, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 3, 6, 7, -0.0712660853305917, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 5, 3, 2, 0.501864116510448, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 5, 2, 5, 0.473247898000575, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 5, 3, 6, 0.498135883489552, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 5, 6, 5, 0.526752101999425, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 5, 2, 6, 0.028616218509873, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 9, 5, 8, 0.544128717741451, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 9, 8, 9, 0.544128717741451, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 9, 5, 10, 0.455871282258549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 9, 10, 9, 0.455871282258549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 11, 6, 11, 0.606610883448134, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 11, 4, 3, 0.449722057607261, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 11, 3, 6, 0.449722057607261, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 11, 7, 0, 0.393389116551867, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 11, 0, 11, 0.393389116551867, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 11, 4, 7, 0.550277942392739, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 11, 6, 7, -0.156888825840872, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 6, 5, 1, -0.594636573183012, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 6, 6, 5, -0.470401514610137, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 6, 2, 1, -0.405363426816988, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 6, 6, 2, -0.529598485389863, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 6, 5, 2, 0.124235058572874, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 7, 3, 6, 0.410222843807112, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 7, 6, 7, 0.410222843807112, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 7, 3, 4, 0.589777156192888, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 7, 4, 7, 0.589777156192888, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 6, 4, 3, 0.64476425497865, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 6, 3, 2, 0.252884139365833, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 6, 2, 6, 0.391880115612817, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 6, 3, 6, 0.391880115612817, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 6, 4, 7, 0.35523574502135, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 6, 7, 6, 0.35523574502135, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 1, 1, 5, -0.594636573183012, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 1, 5, 6, -0.470401514610137, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 1, 1, 2, -0.405363426816988, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 1, 2, 6, -0.529598485389863, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 1, 2, 5, 0.124235058572874, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 4, 3, 4, 0.64476425497865, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 4, 2, 3, 0.252884139365833, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 4, 6, 2, 0.391880115612817, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 4, 6, 3, 0.391880115612817, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 4, 7, 4, 0.35523574502135, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 4, 6, 7, 0.35523574502135, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 8, 8, 5, -0.739002897313725, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 8, 5, 6, -0.516945838054908, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 8, 8, 9, -0.518265203777351, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 8, 9, 10, -0.518265203777351, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 8, 10, 6, -0.740322263036168, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 8, 5, 10, -0.222057059258816, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 3, 6, 3, 0.410222843807112, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 3, 7, 6, 0.410222843807112, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 3, 4, 3, 0.589777156192888, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 3, 7, 4, 0.589777156192888, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 6, 5, 8, -0.739002897313725, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 6, 6, 5, -0.516945838054908, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 6, 9, 8, -0.518265203777351, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 6, 10, 9, -0.518265203777351, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 6, 6, 10, -0.740322263036168, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 6, 10, 5, -0.222057059258816, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 10, 8, 5, 0.470366607524965, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 10, 5, 10, 0.470366607524965, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 10, 8, 9, 0.529633392475035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 10, 9, 10, 0.529633392475035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 8, 5, 8, 0.470366607524965, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 8, 10, 5, 0.470366607524965, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 8, 9, 8, 0.529633392475035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 8, 10, 9, 0.529633392475035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 1, 1, 5, -0.594636573183012, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 1, 5, 6, -0.470401514610137, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 1, 1, 2, -0.405363426816988, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 1, 2, 6, -0.529598485389863, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 1, 2, 5, 0.124235058572874, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 2, 5, 2, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 2, 6, 5, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 2, 6, 2, 0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 2, 3, 2, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 2, 6, 3, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 5, 6, 5, 0.530595169368965, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 5, 10, 5, 0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 5, 6, 10, 0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 8, 8, 5, -0.739002897313725, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 8, 5, 6, -0.516945838054908, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 8, 8, 9, -0.518265203777351, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 8, 9, 10, -0.518265203777351, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 8, 10, 6, -0.740322263036168, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 8, 5, 10, -0.222057059258816, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 7, 5, 1, -0.594636573183012, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 7, 6, 5, -0.470401514610137, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 7, 2, 1, -0.405363426816988, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 7, 6, 2, -0.529598485389863, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 7, 5, 2, 0.124235058572874, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 7, 6, 7, 0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 7, 6, 11, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 7, 11, 0, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 7, 0, 7, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 11, 5, 1, -0.594636573183012, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 11, 6, 5, -0.470401514610137, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 11, 2, 1, -0.405363426816988, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 11, 6, 2, -0.529598485389863, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 11, 5, 2, 0.124235058572874, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 7, 2, 5, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 7, 5, 6, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 7, 2, 6, 0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 7, 2, 3, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 7, 3, 6, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 7, 6, 7, 0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 7, 6, 11, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 7, 11, 0, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 7, 0, 7, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 9, 2, 5, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 9, 5, 6, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 9, 2, 6, 0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 9, 2, 3, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 9, 3, 6, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 10, 2, 5, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 10, 5, 6, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 10, 2, 6, 0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 10, 2, 3, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 10, 3, 6, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 11, 2, 5, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 11, 5, 6, 0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 11, 2, 6, 0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 11, 2, 3, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 11, 3, 6, 0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 8, 3, 2, 0.501864116510448, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 8, 2, 5, 0.473247898000575, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 8, 3, 6, 0.498135883489552, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 8, 6, 5, 0.526752101999425, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 8, 2, 6, 0.028616218509873, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 9, 3, 6, 0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 9, 3, 2, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 9, 2, 6, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 10, 3, 6, 0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 10, 3, 2, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 10, 2, 6, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 11, 3, 6, 0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 11, 3, 2, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 11, 2, 6, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 5, 3, 2, 0.501864116510448, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 5, 2, 5, 0.473247898000575, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 5, 3, 6, 0.498135883489552, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 5, 6, 5, 0.526752101999425, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 5, 2, 6, 0.028616218509873, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 8, 3, 2, 0.501864116510448, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 8, 2, 5, 0.473247898000575, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 8, 3, 6, 0.498135883489552, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 8, 6, 5, 0.526752101999425, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 8, 2, 6, 0.028616218509873, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 9, 3, 6, 0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 9, 3, 2, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 9, 2, 6, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 10, 3, 6, 0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 10, 3, 2, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 10, 2, 6, 0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 7, 5, 6, 0.530595169368965, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 7, 5, 10, 0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 7, 10, 6, 0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 7, 6, 7, 0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 7, 6, 11, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 7, 11, 0, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 7, 0, 7, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 11, 5, 6, 0.530595169368965, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 11, 5, 10, 0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 11, 10, 6, 0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 8, 7, 6, 0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 8, 11, 6, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 8, 0, 11, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 8, 7, 0, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 8, 8, 5, -0.739002897313725, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 8, 5, 6, -0.516945838054908, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 8, 8, 9, -0.518265203777351, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 8, 9, 10, -0.518265203777351, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 8, 10, 6, -0.740322263036168, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 8, 5, 10, -0.222057059258816, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 9, 7, 6, 0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 9, 11, 6, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 9, 0, 11, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 9, 7, 0, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 10, 7, 6, 0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 10, 11, 6, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 10, 0, 11, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 10, 7, 0, 0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 11, 5, 8, -0.739002897313725, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 11, 6, 5, -0.516945838054908, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 11, 9, 8, -0.518265203777351, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 11, 10, 9, -0.518265203777351, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 11, 6, 10, -0.740322263036168, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 11, 10, 5, -0.222057059258816, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 1, 0, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 1, 11, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 2, 0, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 2, 11, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 4, 0, 7, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 4, 7, 4, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 5, 0, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 5, 11, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 6, 0, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 6, 11, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 8, 0, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 8, 11, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 9, 0, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 9, 11, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 9, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 9, 10, 9, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 10, 0, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 10, 11, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(0, 10, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 3, 1, 2, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 3, 2, 3, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 4, 1, 2, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 4, 2, 3, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 4, 3, 4, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 9, 1, 8, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 9, 8, 9, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 10, 1, 5, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 10, 5, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 11, 6, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 4, 2, 3, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 4, 3, 4, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 8, 2, 5, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 8, 5, 8, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 9, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 9, 10, 9, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 10, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 11, 6, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 8, 5, 8, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 9, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 9, 10, 9, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 10, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 11, 6, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 5, 4, 3, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 8, 4, 3, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 8, 5, 8, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 9, 4, 3, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 9, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 9, 10, 9, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 10, 4, 3, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 10, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 11, 6, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 9, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 9, 10, 9, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 9, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 9, 10, 9, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 10, 6, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 11, 7, 0, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 11, 0, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 11, 6, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 11, 9, 10, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 11, 10, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 11, 6, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 11, 10, 6, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 11, 6, 11, 1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 0, 7, 0, 0.458672932246141, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 0, 4, 7, 0.387406846915549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 0, 11, 0, 0.444253113503299, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 0, 3, 4, 0.387406846915549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 0, 6, 11, 0.444253113503299, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 0, 3, 6, 0.51551919883389, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 0, 7, 6, -0.0712660853305917, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 3, 3, 2, 0.501864116510448, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 3, 2, 5, 0.473247898000575, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 3, 3, 6, 0.498135883489552, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 3, 6, 5, 0.526752101999425, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 3, 2, 6, 0.028616218509873, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 5, 8, 5, 0.544128717741451, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 5, 9, 8, 0.544128717741451, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 5, 10, 5, 0.455871282258549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 5, 9, 10, 0.455871282258549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 4, 11, 6, 0.606610883448134, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 4, 3, 4, 0.449722057607261, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 4, 6, 3, 0.449722057607261, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 4, 0, 7, 0.393389116551867, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 4, 11, 0, 0.393389116551867, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 4, 7, 4, 0.550277942392739, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 4, 7, 6, -0.156888825840872, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 0, 1, 5, 0.594636573183012, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 0, 5, 6, 0.470401514610137, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 0, 1, 2, 0.405363426816988, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 0, 2, 6, 0.529598485389863, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 0, 2, 5, -0.124235058572874, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 0, 5, 2, -0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 0, 6, 5, -0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 0, 6, 2, -0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 0, 3, 2, -0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 0, 6, 3, -0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 0, 6, 5, -0.530595169368965, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 0, 10, 5, -0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 0, 6, 10, -0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 0, 8, 5, -0.739002897313725, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 0, 5, 6, -0.516945838054908, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 0, 8, 9, -0.518265203777352, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 0, 9, 10, -0.518265203777352, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 0, 10, 6, -0.740322263036168, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 0, 5, 10, -0.222057059258816, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 1, 5, 1, 0.594636573183012, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 1, 6, 5, 0.470401514610137, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 1, 2, 1, 0.405363426816988, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 1, 6, 2, 0.529598485389863, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 1, 5, 2, -0.124235058572874, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 1, 6, 7, -0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 1, 6, 11, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 1, 11, 0, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 1, 0, 7, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 1, 5, 1, -0.594636573183012, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 1, 6, 5, -0.470401514610137, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 1, 2, 1, -0.405363426816989, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 1, 6, 2, -0.529598485389863, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 1, 5, 2, -0.124235058572874, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 2, 2, 5, -0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 2, 5, 6, -0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 2, 2, 6, -0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 2, 2, 3, -0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 2, 3, 6, -0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 2, 6, 7, -0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 2, 6, 11, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 2, 11, 0, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 2, 0, 7, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 2, 2, 5, -0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 2, 5, 6, -0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 2, 2, 6, -0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 2, 2, 3, -0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 2, 3, 6, -0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 2, 2, 5, -0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 2, 5, 6, -0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 2, 2, 6, -0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 2, 2, 3, -0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 2, 3, 6, -0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 2, 2, 5, -0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 2, 5, 6, -0.180944911617061, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 2, 2, 6, -0.62927865105439, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 2, 2, 3, -0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 2, 3, 6, -0.189776437328549, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 3, 3, 2, -0.501864116510448, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 3, 2, 5, -0.473247898000575, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 3, 3, 6, -0.498135883489552, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 3, 6, 5, -0.526752101999425, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 3, 2, 6, -0.028616218509873, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 3, 3, 6, -0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 3, 3, 2, -0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 3, 2, 6, -0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 3, 3, 6, -0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 3, 3, 2, -0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 3, 2, 6, -0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 3, 3, 6, -0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 3, 3, 2, -0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 3, 2, 6, -0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 4, 3, 2, -0.501864116510448, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 4, 2, 5, -0.473247898000575, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 4, 3, 6, -0.498135883489552, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 4, 6, 5, -0.526752101999425, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 4, 2, 6, -0.028616218509873, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 4, 3, 2, -0.501864116510448, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 4, 2, 5, -0.473247898000575, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 4, 3, 6, -0.498135883489552, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 4, 6, 5, -0.526752101999425, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 4, 2, 6, -0.028616218509873, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 4, 3, 6, -0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 4, 3, 2, -0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 4, 2, 6, -0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 4, 3, 6, -0.607788214974469, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 4, 3, 2, -0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 4, 2, 6, -0.392211785025531, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 5, 5, 6, -0.530595169368965, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 5, 5, 10, -0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 5, 10, 6, -0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 5, 6, 7, -0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 5, 6, 11, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 5, 11, 0, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(7, 5, 0, 7, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 5, 5, 6, -0.530595169368965, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 5, 5, 10, -0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 5, 10, 6, -0.469404830631035, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 7, 7, 6, -0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 7, 11, 6, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 7, 0, 11, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 7, 7, 0, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 7, 8, 5, -0.739002897313725, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 7, 5, 6, -0.516945838054908, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 7, 8, 9, -0.518265203777352, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 7, 9, 10, -0.518265203777352, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 7, 10, 6, -0.740322263036168, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 7, 5, 10, -0.222057059258816, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 7, 7, 6, -0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 7, 11, 6, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 7, 0, 11, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 7, 7, 0, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 7, 7, 6, -0.523056459865598, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 7, 11, 6, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 7, 0, 11, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 7, 7, 0, -0.476943540134402, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 8, 5, 8, -0.739002897313725, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 8, 6, 5, -0.516945838054908, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 8, 9, 8, -0.518265203777352, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 8, 10, 9, -0.518265203777352, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 8, 6, 10, -0.740322263036168, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 8, 10, 5, -0.222057059258816, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 0, 0, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(1, 0, 11, 6, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 0, 0, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(2, 0, 11, 6, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 0, 0, 7, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 0, 7, 4, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 0, 0, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 0, 11, 6, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 0, 0, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(6, 0, 11, 6, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 0, 0, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 0, 11, 6, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 0, 0, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 0, 11, 6, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 0, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 0, 10, 9, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 0, 0, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 0, 11, 6, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 0, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 1, 1, 2, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(3, 1, 2, 3, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 1, 1, 2, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 1, 2, 3, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 1, 3, 4, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 1, 1, 8, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 1, 8, 9, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 1, 1, 5, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 1, 5, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 1, 6, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 2, 2, 3, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(4, 2, 3, 4, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 2, 2, 5, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 2, 5, 8, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 2, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 2, 10, 9, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 2, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 2, 6, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 3, 5, 8, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 3, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 3, 10, 9, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 3, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 3, 6, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(5, 4, 4, 3, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 4, 4, 3, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(8, 4, 5, 8, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 4, 4, 3, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 4, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 4, 10, 9, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 4, 4, 3, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 4, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 5, 6, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 6, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 6, 10, 9, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 7, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(9, 7, 10, 9, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(10, 7, 6, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 7, 7, 0, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 7, 0, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 8, 6, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 9, 9, 10, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 9, 10, 6, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 9, 6, 11, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 10, 10, 6, -1, 0); pathGroupList.Add(pathGroup);
                    pathGroup = new PathGroup(11, 10, 6, 11, -1, 0); pathGroupList.Add(pathGroup);
                

                
            }
            // Den Pfadgruppen den errechneten Fluss beimessen

            for (int i = 0; i < pathGroupList.Count; i++)
            {

                for (int s = 0; s < v_total; s++)
                {
                    for (int d = 0; d < v_total; d++)
                    {

                        if ((pathGroupList[i].pathGroupSrc == s) && (pathGroupList[i].pathGroupdest == d))
                        {
                            pathGroupList[i].flow = pathGroupList[i].flowShare * feed_cons[s, d].flow;
                        }
                    }
                }
            }


            // Fluss je Kante ermitteln

            foreach (PathGroup pathGroupElement in pathGroupList)
            {
                for (int s = 0; s < v_total; s++)
                {
                    for (int d = 0; d < v_total; d++)
                    {
                        if (pathGroupElement.edgeSrc == s && pathGroupElement.edgeDest == d)
                        {
                            edge[s, d].flow += pathGroupElement.flow;

                        }
                    }

                }
            }

            // Resultierende Flussrichtung je Kante ermitteln und Gegenrichtungsfluss abziehen

            for (int s = 0; s < v_total; s++)
            {
                for (int d = 0; d < v_total; d++)
                {
                    if (Math.Abs(edge[s, d].flow) >= Math.Abs(edge[d, s].flow))
                    {
                        if (edge[s, d].flow > 0)
                        {
                            edge[s, d].flow -= edge[d, s].flow;
                            edge[d, s].flow = 0;
                        }
                        else
                        {
                            edge[d, s].flow -= edge[s, d].flow;
                            edge[s, d].flow = 0;

                        }
                    }
                    else

                    {

                        if (edge[d, s].flow > 0)
                        {
                            edge[d, s].flow -= edge[s, d].flow;
                            edge[s, d].flow = 0;
                        }
                        else
                        {
                            edge[s, d].flow -= edge[d, s].flow;
                            edge[d, s].flow = 0;

                        }
                    }

                }
            }

            //

            for (int s = 0; s < v_total; s++)
            {
                for (int d = 0; d < v_total; d++)
                {
                    if (Math.Abs(edge[s, d].flow) > 0)
                    {
                        //Console.WriteLine("edge flow von      " + edge[s, d].src + " nach " + edge[s, d].dest + "   " + String.Format( " {0:F5}", edge[s, d].flow));
                        Edge e = edge[s, d];
                        Console.WriteLine("" + e.src + ";" + e.dest + ";" + String.Format("{0:F5}", e.flow));
                    }
                }
            }
            //Console.WriteLine("Ready. Press any key");
            //Console.ReadKey();

        }


    }
}
