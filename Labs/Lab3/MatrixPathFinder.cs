namespace Lab3;

public class MatrixPathFinder
{
    private List<Vector> points;
    private Vector start;
    private Vector finish;
    private Dictionary<Vector, int> distances;
    private Dictionary<Vector, Vector> predecessors;

    private readonly List<(int, int)> directions = new List<(int, int)>
    {
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1), (0, 0), (0, 1),
        (1, -1), (1, 0), (1, 1)
    };

    public MatrixPathFinder(List<Vector> points)
    {
        this.points = points;
        this.start = points[0];
        this.finish = points[points.Count - 1];
        this.distances = new Dictionary<Vector, int>();
        this.predecessors = new Dictionary<Vector, Vector>();
    }

    // BFS для пошуку найкоротшого шляху
    public List<int> FindShortestPath()
    {
        Queue<Vector> queue = new Queue<Vector>();
        queue.Enqueue(start);
        distances[start] = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.Equals(finish)) break;

            foreach (var direction in directions)
            {
                var neighbor = new Vector(current.X + direction.Item1, current.Y + direction.Item2);

                if (IsValidMove(neighbor) && !distances.ContainsKey(neighbor))
                {
                    distances[neighbor] = distances[current] + 1;
                    predecessors[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return ConstructPath();
    }

    // Метод для побудови шляху від фінішної точки до стартової
    private List<int> ConstructPath()
    {
        List<int> path = new List<int>();

        if (!distances.ContainsKey(finish))
            return new List<int> { -1 };  // Фініш недосяжний

        Vector current = finish;
        while (current != null)
        {
            int index = points.IndexOf(current);
            path.Insert(0, index + 1);
            if (!predecessors.ContainsKey(current)) break;
            current = predecessors[current];
        }

        return path;
    }

    // Перевіряє, чи є сусідній вузол в межах множини S
    private bool IsValidMove(Vector point)
    {
        return points.Contains(point);
    }
}