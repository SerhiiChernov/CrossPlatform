using System;
using System.IO;
namespace Lab2;

class Program
{
    static void Main()
    {
        // Читання вхідних даних
        string inputfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input.txt");
        var input = File.ReadAllLines(inputfilePath);
        var firstLine = input[0].Split();
        int N = int.Parse(firstLine[0]);
        int K = int.Parse(firstLine[1]);

        // Створюємо матрицю на основі вхідних даних
        Matrix matrix = new Matrix(N, input);
        
        // Створюємо об'єкт для пошуку максимального шляху
        MatrixPathFinder pathFinder = new MatrixPathFinder(matrix, K);

        // Знаходимо максимальну суму
        int maxSum = pathFinder.FindMaxSum();

        // Запис результату
        string outputfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Output.txt");
        File.WriteAllText("Output.txt", maxSum.ToString());
    }
}

// Клас для зберігання та роботи з матрицею

// Клас для пошуку максимального шляху по матриці

