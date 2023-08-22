using DecimalMath;

namespace Areas.Tests;

public class TriangleTests
{
    [Test, TestCaseSource(nameof(GetTriangleInitializeTestCases))]
    public void TriangleInitializeTest(decimal[] edges) =>
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Triangle(edges));

    #region Cases

    [TestCase(3, 4, 5, 6)]
    [TestCase(7, 8, 9, 26.83)]
    [TestCase(12, 16, 20, 96)]
    [TestCase(5, 12, 13, 30)]
    [TestCase(9, 10, 17, 36)]

    #endregion
    [Test]
    public void CalculateAreaTest(decimal firstEdge, decimal secondEdge, decimal thirdEdge, decimal area)
    {
        var edges = new[] { firstEdge, secondEdge, thirdEdge };
        var triangle = new Triangle(edges);
        var result = triangle.CalculateArea();

        Assert.That(result.RoundFromZero(2), Is.EqualTo(area.RoundFromZero(2)));
    }

    #region Cases

    [TestCase(3, 4, 5, true)]
    [TestCase(5, 12, 13, true)]
    [TestCase(6, 8, 10, true)]
    [TestCase(4, 7, 9, false)]

    #endregion
    [Test]
    public void IsRightTest(decimal firstEdge, decimal secondEdge, decimal thirdEdge, bool isRight)
    {
        var edges = new[] { firstEdge, secondEdge, thirdEdge };
        var triangle = new Triangle(edges);
        var result = triangle.IsRight();

        Assert.That(result, Is.EqualTo(isRight));
    }

    private static IEnumerable<decimal[]> GetTriangleInitializeTestCases() => new[]
    {
        new[] { 1M, 2M },
        new[] { 1M, 2M, 4M, 5M },
        new[] { 1M, 4M, -8M },
        new[] { 15M, 2M, 7M }
    };
}
