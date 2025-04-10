class Floyd_Algorithm
{
    public const int INF = Int32.MaxValue;
    
    public static int[,] Alg(int[,] graph)
    {
        int[,] output = (int[,])graph.Clone();

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            for (int j = 0; j < graph.GetLongLength(0); j++)
            {
                for (int l = 0; l < graph.GetLength(0); l++)
                {
                    if ((output[j, i] == INF) || (output[i, l] == INF))
                    {
                        int sum = INF;
                        output[j, l] = Math.Min(output[j, l], sum);
                    }
                    else
                    {
                        output[j, l] = Math.Min(output[j, l], output[j, i] + output[i, l]);
                    }
                    
                    
                    Console.WriteLine(output[j, l]);
                }
            }
        }

        return output;

    }
    public static void Main()
    {
        //int[,] graph_matrix = 
        //{
        //    { 0, 5, INF, 10, 12 },
        //    { INF, 0, INF, INF, INF },
        //    { 7, INF, 0, INF, INF },
        //    { 10, INF, INF, 0, 15 },
        //    { INF, INF, INF, 5, 0 }
        //};

        int[,] graph_matrix =
        {
            { 0, 1, 6, INF },
            { INF, 0, 4, 1 },
            { INF, INF, 0, INF },
            { INF, INF, 1, 0 },
        };

        int[,] result = Alg(graph_matrix);

        for (int i = 0; i < graph_matrix.GetLength(0); i++)
        {
            for (int j = 0; j < graph_matrix.GetLength(0); j++)
            {
                if (result[i,j] == INF)
                {
                    Console.Write($"INF\t");
                }
                else
                { 
                    Console.Write($"{result[i, j]}\t");
                }
            }
            Console.WriteLine();
        }
    }
}
