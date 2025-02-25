using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Algorithms
{
    public class Program
    {
        private static int[,] graph_matrix = new int[5, 5]
        {
           { 0, 1, 1, 0, 1 },
           { 1, 0, 1, 0, 0 },
           { 1, 1, 0, 1, 0 },
           { 0, 0, 1, 0, 0 },
           { 1, 0, 0, 0, 0 }
        };

        //public static int[,] graph_matrix = new int[6, 6]
        //{
        //    { 0, 1, 0, 0, 0, 1 },
        //    { 1, 0, 1, 0, 1, 0 },
        //    { 0, 1, 0, 1, 1, 0 },
        //    { 0, 0, 1, 0, 0, 0 },
        //    { 0, 1, 1, 0, 0, 1 },
        //    { 1, 0, 0, 0, 1, 0 }
        //};
        //public static int[,] graph_matrix = new int[6, 6]
        //{
        //    { 0, 1, 1, 0, 0, 0 },
        //    { 1, 0, 1, 0, 0, 0 },
        //    { 1, 1, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 1, 0 },
        //    { 0, 0, 0, 1, 0, 1 },
        //    { 0, 0, 0, 0, 1, 0 }
        //};
        // public static int[,] graph_matrix = new int[10, 10]
        // {
        //     { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
        //     { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
        //     { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
        //     { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        //     { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
        //     { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
        //     { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0},
        //     { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
        //     { 0, 0, 0, 0, 0, 0, 1, 1, 0, 1},
        //     { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        // };

        public static int graph_vertices_number = graph_matrix.GetLength(1);
        public static List<int> graph_vertices = new List<int>();
        public static List<int> graph_vertices_visited = new List<int>();
        public static List<string> mosts = new List<string>();
        public static int s_components = 0;

        public static void Main()
        {
            for (int a = 0; a < graph_vertices_number; a++)
            {
                for (int b = 0; b < graph_vertices_number; b++)
                {
                    if (a != b)
                    {
                        for (int i = 0; i < graph_vertices_number; i++)
                    {
                        if (!graph_vertices_visited.Contains(i))
                        {
                            CheckVertex(i, TestMatrix(graph_matrix, a, b));
                            s_components++;
                        }
                        
                    }

                    Console.WriteLine($"Количество компонентов связности в графе: {s_components}; Ребро: {a+1}-{b+1}");

                    if (s_components > 1)
                    {
                        mosts.Add($"{a+1}-{b+1}");
                    }

                    graph_vertices_visited.Clear();
                    s_components = 0;
                    }
                }
            }
            System.Console.WriteLine("Мосты:");
            foreach (string elem in mosts)
            {

                Console.Write($"{elem},\t");
            }
        }
        public static void CheckVertex(int vertex, int[,] matrix)
        {
            graph_vertices_visited.Add(vertex);
            for (int i = 0; i < graph_vertices_number; i++)
            {
                Console.WriteLine($"Вершина {vertex}, {i}; {matrix[vertex, i]}");
                if (matrix[vertex, i] == 1 && !graph_vertices_visited.Contains(i))
                {
                    CheckVertex(i, matrix);
                }
            }
            
            // ShowList();

        }

        public static int[,] TestMatrix(int[,] matrix, int i, int j)
        {
            int [,] test_matrix = (int[,])matrix.Clone();
            test_matrix[i, j] = 0;
            test_matrix[j, i] = 0;
            
            return test_matrix;
        }
        public static void ShowList()
        {
            Console.WriteLine();
            foreach (int elem in graph_vertices_visited)
            {
                Console.Write($"{elem}\t");
            }
            Console.WriteLine();
        }
    }
}
