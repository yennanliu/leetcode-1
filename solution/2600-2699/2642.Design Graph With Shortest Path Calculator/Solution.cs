public class Graph {
    private int n;
    private int[,] g;
    private readonly int inf = 1 << 29;

    public Graph(int n, int[][] edges) {
        this.n = n;
        g = new int[n, n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                g[i, j] = inf;
            }
        }
        foreach (var e in edges) {
            int f = e[0], t = e[1], c = e[2];
            g[f, t] = c;
        }
    }

    public void AddEdge(int[] edge) {
        int f = edge[0], t = edge[1], c = edge[2];
        g[f, t] = c;
    }

    public int ShortestPath(int node1, int node2) {
        int[] dist = new int[n];
        bool[] vis = new bool[n];
        Array.Fill(dist, inf);
        dist[node1] = 0;
        for (int i = 0; i < n; ++i) {
            int t = -1;
            for (int j = 0; j < n; ++j) {
                if (!vis[j] && (t == -1 || dist[t] > dist[j])) {
                    t = j;
                }
            }
            vis[t] = true;
            for (int j = 0; j < n; ++j) {
                dist[j] = Math.Min(dist[j], dist[t] + g[t, j]);
            }
        }
        return dist[node2] >= inf ? -1 : dist[node2];
    }
}

/**
 * Your Graph object will be instantiated and called as such:
 * Graph obj = new Graph(n, edges);
 * obj.AddEdge(edge);
 * int param_2 = obj.ShortestPath(node1,node2);
 */