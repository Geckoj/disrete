using System;
using System.Linq;

class Graph
{
    public static void Algorithm_2(int[,] graph)
    {
        int vert_count = graph.GetLength(0);
        int[] components = new int[vert_count];
        HashSet<int> s_comp = new HashSet<int>();

        for (int i = 0; i < vert_count; i++)
            components[i] = i + 1;

        for (int i = 0; i < vert_count; i++)
        {
            if (components[i] != i + 1)
            {
                continue;
            }
                
            for (int j = 0; j < i; j++)
            {
                if (graph[i, j] == 1)
                {
                    if (components[i] != components[j])
                    {
                        int min_comp = Math.Min(components[i], components[j]);
                        int max_comp = Math.Max(components[i], components[j]);

                        for (int k = 0; k < vert_count; k++)
                        {
                            if (components[k] == max_comp)
                            {
                                components[k] = min_comp;
                            }
                        }
                    }
                }
            }
            show_arr(components, vert_count);
        }

        Console.WriteLine("\nПолученный список вершин:");
        show_arr(components, vert_count);

        for (int i = 0; i < vert_count; i++)
        {
            s_comp.Add(components[i]);
        }
        Console.WriteLine($"\nКоличество компонент связности: {s_comp.Count}");
    }

    public static void show_arr(int[] components, int vert_count)
    {
        Console.WriteLine();
        for (int i = 0; i < vert_count; i++)
        {
            Console.Write($"{components[i]}\t");
        }
    }

    static void Main()
    {
        int[,] graph = new int[6, 6]
        {
            { 0, 0, 1, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0 },
            { 1, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 1 },
            { 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 1, 0, 0 }
        };

        Algorithm_2(graph);
    }
}
