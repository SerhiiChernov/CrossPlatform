namespace Lab2;

public class MatrixPathFinder
{
    private readonly Matrix matrix;
    private  readonly int maxSteps;
    private  readonly int[,,] dp;

    public MatrixPathFinder(Matrix matrix, int maxSteps)
    {
        this.matrix = matrix;
        this.maxSteps = maxSteps;
        dp = new int[this.matrix.Size, this.matrix.Size, this.maxSteps + 1];

        // Ініціалізація dp масиву
        InitializeDP();
    }

    // Ініціалізуємо DP масив початковими значеннями
    private void InitializeDP()
    {
        for (int i = 0; i < matrix.Size; i++)
        {
            for (int j = 0; j < matrix.Size; j++)
            {
                for (int k = 0; k <= maxSteps; k++)
                {
                    dp[i, j, k] = int.MinValue;
                }
            }
        }

        // Стартова клітина (0, 0) - початок шляху
        dp[0, 0, 1] = matrix.Data[0, 0];
    }

    // Метод для пошуку максимальної суми на шляху довжиною K
    public int FindMaxSum()
    {
        // Основний цикл для обчислення dp значень
        for (int k = 2; k <= maxSteps; k++)
        {
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    // Оновлюємо dp для кожної клітини (i, j) на k кроці
                    UpdateDP(i, j, k);
                }
            }
        }

        // Знаходимо максимальну суму серед усіх клітин після точно K кроків
        int maxSum = int.MinValue;
        for (int i = 0; i < matrix.Size; i++)
        {
            for (int j = 0; j < matrix.Size; j++)
            {
                maxSum = Math.Max(maxSum, dp[i, j, maxSteps]);
            }
        }

        return maxSum;
    }

    // Оновлює значення dp для поточної клітини (i, j) на кроці k
    private void UpdateDP(int i, int j, int k)
    {
        // Вгору
        if (i > 0)
            dp[i, j, k] = Math.Max(dp[i, j, k], dp[i - 1, j, k - 1] + matrix.Data[i, j]);

        // Вниз
        if (i < matrix.Size - 1)
            dp[i, j, k] = Math.Max(dp[i, j, k], dp[i + 1, j, k - 1] + matrix.Data[i, j]);

        // Вліво
        if (j > 0)
            dp[i, j, k] = Math.Max(dp[i, j, k], dp[i, j - 1, k - 1] + matrix.Data[i, j]);

        // Вправо
        if (j < matrix.Size - 1)
            dp[i, j, k] = Math.Max(dp[i, j, k], dp[i, j + 1, k - 1] + matrix.Data[i, j]);
    }
}