using DecimalMath;

namespace Areas.Tests;

public class CircleTests
{
    #region Cases

    [TestCase(-12)]

    #endregion
    [Test]
    public void CircleInitializeTest(decimal radius) =>
        Assert.Throws<ArgumentOutOfRangeException>(() => { _ = new Circle(radius); });

    #region Cases

    [TestCase(1, 3.14)]
    [TestCase(2, 12.57)]
    [TestCase(3, 28.27)]
    [TestCase(4, 50.27)]
    [TestCase(5, 78.54)]
    [TestCase(6, 113.1)]

    #endregion
    [Test]
    public void CalculateAreaTest(decimal radius, decimal area)
    {
        var circle = new Circle(radius);
        var result = circle.CalculateArea();

        Assert.That(result.RoundFromZero(2), Is.EqualTo(area.RoundFromZero(2)));
    }
}
