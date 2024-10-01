namespace Lab2.Test;

[TestClass]
public class MatrixPathFinderTests
{
    [TestMethod]
    public void FindMaxSum_WithSmallMatrix_ReturnsCorrectResult()
    {
        // Arrange
        string[] inputData = new string[]
        {
            "3 3",
            "1 2 3",
            "4 5 6",
            "7 8 9"
        };
        Matrix matrix = new Matrix(3, inputData);
        MatrixPathFinder pathFinder = new MatrixPathFinder(matrix, 3);

        // Act
        int result = pathFinder.FindMaxSum();

        // Assert
        Assert.AreEqual(12, result);  // Шлях 1 → 4 → 7
    }

    [TestMethod]
    public void FindMaxSum_WithLargerMatrix_ReturnsCorrectResult()
    {
        // Arrange
        string[] inputData = new string[]
        {
            "5 7",
            "1 1 1 1 1",
            "1 1 3 1 9",
            "1 1 6 1 1",
            "1 1 3 1 1",
            "1 1 1 1 1"
        };
        Matrix matrix = new Matrix(5, inputData);
        MatrixPathFinder pathFinder = new MatrixPathFinder(matrix, 7);

        // Act
        int result = pathFinder.FindMaxSum();

        // Assert
        Assert.AreEqual(21, result);  // Правильний шлях дає 21
    }

    [TestMethod]
    public void FindMaxSum_WithSingleStep_ReturnsMatrixValue()
    {
        // Arrange
        string[] inputData = new string[]
        {
            "2 1",
            "10 20",
            "30 40"
        };
        Matrix matrix = new Matrix(2, inputData);
        MatrixPathFinder pathFinder = new MatrixPathFinder(matrix, 1);

        // Act
        int result = pathFinder.FindMaxSum();

        // Assert
        Assert.AreEqual(10, result);  // Початкова клітина (0,0)
    }

    [TestMethod]
    public void FindMaxSum_WithMaxSteps_ReturnsCorrectResult()
    {
        // Arrange
        string[] inputData = new string[]
        {
            "2 4",
            "1 2",
            "3 4"
        };
        Matrix matrix = new Matrix(2, inputData);
        MatrixPathFinder pathFinder = new MatrixPathFinder(matrix, 4);

        // Act
        int result = pathFinder.FindMaxSum();

        // Assert
        Assert.AreEqual(11, result);  // Шлях 1 → 3 → 4 → 2 → 4 = 10
    }

    [TestMethod]
    public void FindMaxSum_WithEdgeCase_ReturnsCorrectResult()
    {
        // Arrange
        string[] inputData = new string[]
        {
            "3 5",
            "1 1 1",
            "1 10 1",
            "1 1 1"
        };
        Matrix matrix = new Matrix(3, inputData);
        MatrixPathFinder pathFinder = new MatrixPathFinder(matrix, 5);

        // Act
        int result = pathFinder.FindMaxSum();

        // Assert
        Assert.AreEqual(23, result);  // Шлях 1 → 10 → кілька разів навколо 10
    }
}