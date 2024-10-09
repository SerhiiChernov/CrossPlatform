namespace Lab3;

public class OutputWriter
{
    public static void WriteResult(List<int> result, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            if (result == null)
            {
                writer.WriteLine(-1);
            }
            else
            {
                writer.WriteLine(result.Count - 1); // Мінімальна кількість ходів
                writer.WriteLine(string.Join(" ", result)); // Послідовність вузлів
            }
        }
    }
}