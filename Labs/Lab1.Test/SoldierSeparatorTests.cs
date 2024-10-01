using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Lab1.Test;

[TestClass]
public class SoldierSeparatorTests
{
    [TestMethod]
    public void Execute_WhenSoldiersCountIsLessThanOrEqualTo3_ReturnsZero()
    {
        var separator = new SoldierSeparator();
        var result = separator.Execute(3);

        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Execute_WhenSoldiersCountIsGreaterThan3AndGroupsAreFormed_ReturnsCorrectFinalGroupCounter()
    {
        var separator = new SoldierSeparator();
        var result = separator.Execute(5);

        Assert.AreEqual(1, result); // Example expected result
    }

    [TestMethod]
    public void Execute_WhenSoldiersCountIsLarge_ReturnsCorrectFinalGroupCounter()
    {
        var separator = new SoldierSeparator();
        var result = separator.Execute(10);

        Assert.AreEqual(2, result); // Adjust this based on logic expectation
    }

    [TestMethod]
    public void Execute_WhenSoldiersCountIsZero_ReturnsZero()
    {
        var separator = new SoldierSeparator();
        var result = separator.Execute(0);

        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Execute_WhenSoldiersCountIsNegative_ReturnsZero()
    {
        var separator = new SoldierSeparator();
        var result = separator.Execute(-5);

        Assert.AreEqual(0, result); // Assuming negative numbers don't form groups
    }
}