using System;

class Ford_Bellman
{
    public const int INF = Int32.MaxValue;
    public static bool hasNegativeCycle = false;

    public static int[,] Run(int N, int start, int[,] W)
    {
        int[,] F = new int[N, N];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                F[i, j] = INF;
            }
        }

        F[0, start] = 0;

        for (int k = 1; k < N; k++)
        {
            for (int i = 0; i < N; i++)
            {
                F[k, i] = F[k - 1, i];

                for (int j = 0; j < N; j++)
                {
                    if (F[k - 1, j] != Int32.MaxValue && W[j, i] != Int32.MaxValue)
                    {
                        int newDist = F[k - 1, j] + W[j, i];
                        if (newDist < F[k, i])
                        {
                            F[k, i] = newDist;
                        }
                    }
                }
            }
        }

        for (int i = 0; i < F.GetLength(0); i++)
        {
            for (int j = 0; j < F.GetLength(1); j++)
            {
                if (F[i, j] == INF)
                {
                    Console.Write($"INF\t");
                }
                else
                {
                    Console.Write($"{F[i, j]}\t");
                }

            }
            Console.WriteLine();
        }

        int[] last_iter = new int[N];
        for (int m = 0; m < F.GetLength(0); m++)
        {
            last_iter[m] = F[N - 1, m];
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (F[N - 1, i] != Int32.MaxValue && W[i, j] != Int32.MaxValue)
                {
                    int newDist = F[N - 1, i] + W[i, j];
                    if (newDist < F[N - 1, j])
                    {
                        hasNegativeCycle = true;
                        //Console.WriteLine($"dist: {newDist} old dist: {F[N - 1, j]}\t i: {i}\tj: {j}");

                        last_iter[j] = newDist;
                    }
                }
            }
        }

        foreach (int elem in last_iter)
        {
            if (elem == INF)
            {
                Console.Write($"INF\t");
            }
            else
            {
                Console.Write($"{elem}\t");
            }
        }
        Console.WriteLine();
        return F;
        
    }

    public static void Main()
    {

        int[,] W = {
            { 0, 5, INF, 10, 12 },
            { INF, 0, INF, INF, INF },
            { 7, INF, 0, INF, INF },
            { 10, INF, INF, 0, -10 },
            { INF, INF, INF, 5, 0 }
        };
        Console.WriteLine("Введите вершину, от которой будут рассчитываться пути (начиная с 1)");
        int start = Convert.ToInt32(Console.ReadLine()) - 1;

        int[,] result = Run(W.GetLength(0), start, W);

        if (hasNegativeCycle)
        {
            Console.WriteLine("Граф содержит цикл с отрицательным весом.");
        }
        else
        {
            Console.WriteLine("Граф не содержит циклов с отрицательным весом.");
            for (int i = 0; i < W.GetLength(0); i++)
            {
                if (result[W.GetLength(0) - 1, i] >= INF)
                {
                    Console.WriteLine($"До вершины {i + 1}: нет пути");
                }
                else
                {
                    Console.WriteLine($"До вершины {i + 1}: {result[W.GetLength(0) - 1, i]}");
                }            
            }
        }
    }
}
