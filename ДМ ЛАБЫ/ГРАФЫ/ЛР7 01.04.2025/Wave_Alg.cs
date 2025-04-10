//волновой алгоритм
using System;
using System.Collections.Generic;

class Program
{
    public struct Point
    {
        public int X, Y;
        public Point(int x, int y) 
        { 
            X = x;
            Y = y;
        }
    }

    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };
    const int INF = Int32.MaxValue;

    public static bool Is_Valid(int x, int y, int[,] map, bool[,] visited)
    {
        return x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1) && map[x, y] == 0 && !visited[x, y];
    }

    public static int[,] Wave_Algorithm(int[,] map, Point start, Point finish)
    {
        int m = map.GetLength(0);
        int n = map.GetLength(1);
        int[,] distance = new int[m, n];
        bool[,] visited = new bool[m, n];

        Queue<Point> queue = new Queue<Point>();
        queue.Enqueue(start);
        visited[start.X, start.Y] = true;
        distance[start.X, start.Y] = 0;

        while (queue.Count > 0)
        {
            Point current = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {


                int new_X = current.X + dx[i];
                int new_Y = current.Y + dy[i];

                if (Is_Valid(new_X, new_Y, map, visited))
                {
                    visited[new_X, new_Y] = true;
                    distance[new_X, new_Y] = distance[current.X, current.Y] + 1;

                    queue.Enqueue(new Point(new_X, new_Y));

                    if (new_X == finish.X && new_Y == finish.Y)
                    {
                        return distance;
                    }


                }
            }
        }

        if (!visited[finish.X, finish.Y]) 
        {
            distance[finish.X, finish.Y] = INF;
            
            return distance;
        }
        else
        {
            return distance;
        }

        
    }

    static void Main()
    {
        int[,] map = new int[,]
        {
            { 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

        Point start = new Point(0, 0);
        Point finish = new Point(4, 4);

        int[,] distance = Wave_Algorithm(map, start, finish);

        //for (int i = 0; i < map.GetLength(0); i++)
        //{
        //    for (int j = 0; j < map.GetLength(1); j++)
        //    {
        //        Console.Write($"{distance[i, j]}\t");
        //    }
        //    Console.WriteLine();
        //}
        //матрица расстояний

        if (distance[finish.X, finish.Y] == INF)
        {
            Console.WriteLine($"Нет пути от ({start.X}, {start.Y}) до " +
                $"({finish.X}, {finish.Y})");
        }
        else
        {
            Console.WriteLine($"Расстояние от ({start.X}, {start.Y}) до " +
            $"({finish.X}, {finish.Y}): {distance[finish.X, finish.Y]}");
        }
        
        
    }
}
