namespace Areas.Tests;

public class ShapeTests
{
    [Test, TestCaseSource(nameof(AbstractShapeAreaTestCases))]
    public void AbstractShapeAreaTest(IEnumerable<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            var area = shape.CalculateArea();
            Assert.Positive(area);
        }
    }

    private static IEnumerable<IEnumerable<Shape>> AbstractShapeAreaTestCases() => new[]
    {
        new Shape[] { new Circle(18), new Triangle(new decimal[] { 7, 8, 9 }), new Circle(12) }
    };
}
