using DecimalMath;

namespace Areas;

/// <summary>
/// Represents a circle geometric shape.
/// </summary>
public class Circle : Shape
{
    /// <summary>
    /// Initializes a new instance of the Circle to a specified radius.
    /// </summary>
    /// <param name="radius">Circle radius.</param>
    public Circle(decimal radius)
    {
        if (radius < 0)
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius less than zero.");

        Radius = radius;
    }

    private decimal Radius { get; }

    public override decimal CalculateArea() => DecimalEx.Pi * Radius * Radius;
}
