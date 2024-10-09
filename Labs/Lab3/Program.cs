using System;
using System.Collections.Generic;
using System.IO;
namespace Lab3;

class Program
{
    static void Main()
    {
        // Читання даних з файлу INPUT.TXT
        string inputfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input.txt");
        var inputLines = File.ReadAllLines(inputfilePath);
        int n = int.Parse(inputLines[0]);
        List<Vector> points = new List<Vector>();

        for (int i = 1; i <= n; i++)
        {
            var input = inputLines[i].Split();
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            points.Add(new Vector(x, y));
        }

        // Створення екземпляра MatrixPathFinder
        MatrixPathFinder pathFinder = new MatrixPathFinder(points);
        var result = pathFinder.FindShortestPath();

        // Запис результату в файл OUTPUT.TXT
        using (StreamWriter writer = new StreamWriter("Output.txt"))
        {
            if (result[0] == -1)
            {
                writer.WriteLine(-1);
            }
            else
            {
                writer.WriteLine(result.Count - 1);
                writer.WriteLine(string.Join(" ", result));
            }
        }
    }
}
