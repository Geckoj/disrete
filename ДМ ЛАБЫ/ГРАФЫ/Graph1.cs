using System.Linq;

namespace Algorithms
{
    public class Program
    {
        //public static int[,] graph_matrix = new int[5, 5]
        //{
        //    { 0, 1, 1, 0, 1 },
        //    { 1, 0, 1, 0, 0 },
        //    { 1, 1, 0, 1, 0 },
        //    { 0, 0, 1, 0, 0 },
        //    { 1, 0, 0, 0, 0 }
        //};

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
        public static int[,] graph_matrix = new int[10, 10]
        {
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0},
            { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
            { 0, 0, 0, 0, 0, 0, 1, 1, 0, 1},
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        };

        public static int graph_vertices_number = graph_matrix.GetLength(1);
        public static List<int> graph_vertices = new List<int>();
        public static List<int> graph_vertices_visited = new List<int>();
        public static int s_components = 0;

        public static void Main()
        {

            for (int i = 0; i < graph_vertices_number; i++)
            {
                if (!graph_vertices_visited.Contains(i))
                {
                    CheckVertex(i);
                    s_components++;
                }
            }

            Console.WriteLine($"Количество компонентов связности в графе: {s_components}");

        }
        public static void CheckVertex(int vertex)
        {
            graph_vertices_visited.Add(vertex);
            for (int i = 0; i < graph_vertices_number; i++)
            {
                Console.WriteLine($"Вершина {vertex}, {i}; {graph_matrix[vertex, i]}");
                if (graph_matrix[vertex, i] == 1 && !graph_vertices_visited.Contains(i))
                {
                    CheckVertex(i);
                }
            }
            
            ShowList();

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
