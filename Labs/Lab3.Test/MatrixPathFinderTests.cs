namespace Lab3.Test;

[TestClass]
public class MatrixPathFinderTests
{
    [TestMethod]
    public void TestPathExists()
    {
        // Arrange
        var points = new List<Vector>
        {
            new Vector(0, 0),  // Стартовий вузол
            new Vector(0, 1),
            new Vector(1, 1),
            new Vector(1, 0),
            new Vector(0, 3)   // Фінішний вузол
        };
        var pathFinder = new MatrixPathFinder(points);

        // Act
        var result = pathFinder.FindShortestPath();

        // Assert
        Assert.AreEqual(-1, result[0], "Шлях не повинен бути знайдений.");
    }

    [TestMethod]
    public void TestPathExistsWithDirectConnection()
    {
        // Arrange
        var points = new List<Vector>
        {
            new Vector(0, 0),  // Стартовий вузол
            new Vector(0, 1),  // Проміжний вузол
            new Vector(0, 2),  // Проміжний вузол
            new Vector(0, 3)   // Фінішний вузол
        };
        var pathFinder = new MatrixPathFinder(points);

        // Act
        var result = pathFinder.FindShortestPath();

        // Assert
        Assert.IsNotNull(result, "Шлях має бути знайдений.");
        Assert.AreEqual(3, result.Count - 1, "Шлях має складатися з трьох кроків.");
        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, result, "Шлях має пройти через вузли 1 → 2 → 3 → 4.");
    }


    [TestMethod]
    public void TestPathExistsWithMultipleSteps()
    {
        // Arrange
        var points = new List<Vector>
        {
            new Vector(0, 0),  // Стартовий вузол
            new Vector(0, 1),
            new Vector(1, 1),
            new Vector(1, 0),
            new Vector(1, 2),  // Проміжний вузол
            new Vector(0, 3)   // Фінішний вузол
        };
        var pathFinder = new MatrixPathFinder(points);

        // Act
        List<int> result = pathFinder.FindShortestPath();

        // Assert
        Assert.IsNotNull(result, "Шлях має бути знайдений.");
        Assert.AreEqual(3, result.Count - 1, "Шлях має складатися з трьох кроків.");
        CollectionAssert.AreEqual(new List<int> { 1, 2, 5, 6 }, result, "Шлях має пройти через вузли 1 → 2 → 5 → 6.");
    }

    [TestMethod]
    public void TestNoPathExists()
    {
        // Arrange
        var points = new List<Vector>
        {
            new Vector(0, 0),  // Стартовий вузол
            new Vector(100, 100), // Ізольований вузол
            new Vector(200, 200)  // Фінішний вузол, недосяжний
        };
        var pathFinder = new MatrixPathFinder(points);

        // Act
        var result = pathFinder.FindShortestPath();

        // Assert
        Assert.AreEqual(-1, result[0], "Шлях не повинен бути знайдений.");
    }

    [TestMethod]
    public void TestSingleNodePath()
    {
        // Arrange
        var points = new List<Vector>
        {
            new Vector(0, 0) // Один єдиний вузол
        };
        var pathFinder = new MatrixPathFinder(points);

        // Act
        var result = pathFinder.FindShortestPath();

        // Assert
        Assert.AreEqual(1, result.Count, "Шлях має складатися з одного вузла.");
        Assert.AreEqual(1, result[0], "Єдиний вузол у шляху має бути вузол 1.");
    }
}