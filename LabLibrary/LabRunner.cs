﻿using Lab1;
using Lab2;
using Lab3;

namespace LabsLibrary
{
    
public class LabRunner
    {
        public void RunLab1(string inputFilePath, string outputFilePath)
        {
            SoldierSeparator soldierSeparator = new SoldierSeparator();
            int res = soldierSeparator.Execute(Convert.ToInt32(File.ReadAllText(inputFilePath).Trim()));

            File.WriteAllText(outputFilePath, res.ToString());

            Console.WriteLine("Data successfully written to the output file.");
        }
        public string RunLab1(Stream inputFileStream)
        {
            SoldierSeparator soldierSeparator = new SoldierSeparator();
            using (var reader = new StreamReader(inputFileStream)) 
            {
                int res = soldierSeparator.Execute(Convert.ToInt32(reader.ReadToEnd().Trim()));
                return res.ToString();
            }
            //int res = soldierSeparator.Execute(Convert.ToInt32(File.ReadAllText(inputFilePath).Trim()));

            //File.WriteAllText(outputFilePath, res.ToString());

            //Console.WriteLine("Data successfully written to the output file.");
            //return res.ToString();
        }

        public void RunLab2(string inputFilePath, string outputFilePath)
        {
            var input = File.ReadAllLines(inputFilePath);
            var firstLine = input[0].Split();
            int N = int.Parse(firstLine[0]);
            int K = int.Parse(firstLine[1]);

            // Створюємо матрицю на основі вхідних даних
            Matrix matrix = new Matrix(N, input);

            // Створюємо об'єкт для пошуку максимального шляху
            Lab2.MatrixPathFinder pathFinder = new Lab2.MatrixPathFinder(matrix, K);

            // Знаходимо максимальну суму
            int maxSum = pathFinder.FindMaxSum();

            File.WriteAllText(outputFilePath, maxSum.ToString());

            Console.WriteLine("Data successfully written to the output file.");
        }

        public string RunLab2(Stream inputFileStream)
        {
            string[] input;
            using (var reader = new StreamReader(inputFileStream))
            {
                input = reader.ReadToEnd().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            }

            var firstLine = input[0].Split();
            int N = int.Parse(firstLine[0]);
            int K = int.Parse(firstLine[1]);

            // Створюємо матрицю на основі вхідних даних
            Matrix matrix = new Matrix(N, input);

            // Створюємо об'єкт для пошуку максимального шляху
            Lab2.MatrixPathFinder pathFinder = new Lab2.MatrixPathFinder(matrix, K);

            // Знаходимо максимальну суму
            int maxSum = pathFinder.FindMaxSum();

            return maxSum.ToString();
        }

        public void RunLab3(string inputFilePath, string outputFilePath)
        {
            var inputLines = File.ReadAllLines(inputFilePath);
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
            Lab3.MatrixPathFinder pathFinder = new Lab3.MatrixPathFinder(points);
            var result = pathFinder.FindShortestPath();

            // Запис результату в файл OUTPUT.TXT
            using (StreamWriter writer = new StreamWriter(outputFilePath))
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

            Console.WriteLine("Data successfully written to the output file.");
        }
        public string RunLab3(Stream inputFileStream)
        {
            List<Vector> points = new List<Vector>();
            int n;

            using (var reader = new StreamReader(inputFileStream))
            {
                // Зчитуємо кількість точок
                n = int.Parse(reader.ReadLine());

                // Зчитуємо точки
                for (int i = 0; i < n; i++)
                {
                    var input = reader.ReadLine().Split();
                    int x = int.Parse(input[0]);
                    int y = int.Parse(input[1]);
                    points.Add(new Vector(x, y));
                }
            }

            Lab3.MatrixPathFinder pathFinder = new Lab3.MatrixPathFinder(points);

            // Знаходимо найкоротший шлях
            var result = pathFinder.FindShortestPath();

            return result.ToString(); 
        }

    }
    
}