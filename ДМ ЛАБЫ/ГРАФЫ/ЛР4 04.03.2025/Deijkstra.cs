using System;

class Deijkstra
{
    const int INF = int.MaxValue;

    public static int FindShortestPath(int[,] graph, int start, int finish)
    {
        int n = graph.GetLength(0);
        int[] dist = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            dist[i] = INF;
            visited[i] = false;
        }

        dist[start] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int u = MinDistance(dist, visited, n);

            visited[u] = true;

            for (int v = 0; v < n; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && dist[u] != INF && dist[u] + graph[u, v] < dist[v])
                {
                    dist[v] = dist[u] + graph[u, v];
                }
            }
        }
        return dist[finish];
    }
    private static int MinDistance(int[] dist, bool[] visited, int n)
    {
        int min = INF;
        int minIndex = -1;

        for (int v = 0; v < n; v++)
        {
            if (!visited[v] && dist[v] <= min)
            {
                min = dist[v];
                minIndex = v;
            }
        }
        return minIndex;
    }

    static void Main()
    {
        int[,] graph = new int[,]
        {
            { 0, 18, 25, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 5, 5, 30 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 10 },
            { 0, 0, 0, 0, 0, 0 }
        };

        int start = 0;
        int finish = 5;

        int shortestPath = FindShortestPath(graph, start, finish);
        if (shortestPath == INF)
        {
            Console.WriteLine($"Нет пути от вершины {start + 1} до вершины {finish + 1}");
        }
        else
        {
            Console.WriteLine($"Кратчайший путь от вершины {start + 1} до вершины {finish + 1} = {shortestPath}");
        }
    }
}
