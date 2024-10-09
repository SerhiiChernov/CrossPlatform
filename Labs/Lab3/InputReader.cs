namespace Lab3;

public class InputReader
{
    public static List<(int X, int Y)> ReadNodes(string filePath)
    {
        var input = File.ReadAllLines(filePath);
        int N = int.Parse(input[0]);

        var nodes = new List<(int X, int Y)>();
        for (int i = 1; i <= N; i++)
        {
            var parts = input[i].Split();
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            nodes.Add((x, y));
        }

        return nodes;
    }
}