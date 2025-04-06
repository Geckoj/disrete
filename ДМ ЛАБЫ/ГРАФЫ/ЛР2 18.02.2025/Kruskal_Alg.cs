using System;
using System.Collections.Generic;
using System.Linq;

class Kruskal_Algorithm
{
    public static void Main()
    {
        // Список рёбер графа (вес, вершина v1, вершина v2)
        List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>()
        {
            Tuple.Create(6, 1, 2), Tuple.Create(1, 1, 3), Tuple.Create(5, 1, 4),
            Tuple.Create(5, 2, 3), Tuple.Create(5, 3, 4), Tuple.Create(3, 2, 5),
            Tuple.Create(6, 3, 5), Tuple.Create(6, 5, 6), Tuple.Create(4, 3, 6),
            Tuple.Create(2, 4, 6)
        };

        var sortedEdges = edges.OrderBy(e => e.Item1).ToList();

        //Множество U для соединённых вершин, словарь D для групп вершин (рёбер), список
        // T для рёбер, входящих в минимальное остовное дерево
        
        HashSet<int> U = new HashSet<int>();
        Dictionary<int, List<int>> D = new Dictionary<int, List<int>>();
        List<Tuple<int, int, int>> T = new List<Tuple<int, int, int>>();

        foreach (var r in sortedEdges)
        {
            if (!U.Contains(r.Item2) || !U.Contains(r.Item3))
            {
                if (!U.Contains(r.Item2) && !U.Contains(r.Item3))
                {
                    D[r.Item2] = new List<int> { r.Item2, r.Item3 };
                    D[r.Item3] = D[r.Item2];
                }
                else
                {
                    if (!D.ContainsKey(r.Item2))
                    {
                        D[r.Item3].Add(r.Item2);
                        D[r.Item2] = D[r.Item3];
                    }
                    else
                    {
                        D[r.Item2].Add(r.Item3);
                        D[r.Item3] = D[r.Item2];
                    }
                }

                T.Add(r);
                U.Add(r.Item2);
                U.Add(r.Item3);
            }
        }

        foreach (var r in sortedEdges)
        {
            if (!D[r.Item2].Contains(r.Item3))
            {
                T.Add(r);
                List<int> group1 = new List<int>(D[r.Item2]);
                D[r.Item2].AddRange(D[r.Item3]);
                D[r.Item3].AddRange(group1);
            }
        }

        Console.WriteLine("Минимальное остовное дерево:");
        int total_wt = 0;
        foreach (var edge in T)
        {
            Console.WriteLine($"{edge.Item2} - {edge.Item3} : {edge.Item1}");
            total_wt += edge.Item1;
        }
        Console.WriteLine($"Суммарный вес минимального остовного дерева: {total_wt}");
    }
}
