//Алгоритм Прима
using System;

class Prim_Alg
{
    public static int MinKey(int[] key, bool[] ost_tree, int vert_count)
    {
        int min = int.MaxValue;
        int min_index = -1;

        for (int v = 0; v < vert_count; v++)
        {
            if (!ost_tree[v] && key[v] < min)
            {
                min = key[v];
                min_index = v;
            }
        }

        return min_index;
    }

    public static void Print(int[] parent, int[,] graph)
    {
        int total_wt = 0;

        Console.WriteLine("Ребро \tВес");
        for (int i = 1; i < graph.GetLength(0); i++)
        {
            Console.WriteLine($"{parent[i]+1} - {i+1} \t{graph[i, parent[i]]}");
            total_wt += graph[i, parent[i]];
        }
        Console.WriteLine($"Вес минимального остовного дерева: {total_wt}");
    }

    public static void Prim_Algorithm(int[,] graph)
    {
        int vert_count = graph.GetLength(0);
        int[] parent = new int[vert_count];
        int[] key = new int[vert_count];
        bool[] ost_tree = new bool[vert_count];

        for (int i = 0; i < vert_count; i++)
        {
            key[i] = int.MaxValue;
            ost_tree[i] = false;
        }

        key[0] = 0;
        parent[0] = -1;

        for (int count = 0; count < vert_count - 1; count++)
        {
            int u = MinKey(key, ost_tree, vert_count);
            ost_tree[u] = true;

            for (int v = 0; v < vert_count; v++)
            {
                if (graph[u, v] != 0 && !ost_tree[v] && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
            }
        }
        Print(parent, graph);
    }

    static void Main()
    {
        int[,] graph = new int[,] {
            { 0, 6, 1, 5, 0, 0 },
            { 6, 0, 5, 0, 3, 0 },
            { 1, 5, 0, 5, 6, 4 },
            { 5, 0, 5, 0, 0, 2 },
            { 0, 3, 6, 0, 0, 6 },
            { 0, 0, 4, 2, 6, 0 }
        };

        Prim_Algorithm(graph);
    }
}
