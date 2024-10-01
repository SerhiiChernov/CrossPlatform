namespace Lab2;

public class Matrix
{
    public int Size { get; }
    public int[,] Data { get; }

    public Matrix(int size, string[] inputData)
    {
        Size = size;
        Data = new int[Size, Size];

        // Заповнюємо матрицю даними
        for (int i = 0; i < Size; i++)
        {
            var row = inputData[i + 1].Split();
            for (int j = 0; j < Size; j++)
            {
                Data[i, j] = int.Parse(row[j]);
            }
        }
    }
}
