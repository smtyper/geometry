using DecimalMath;

namespace Areas;

/// <summary>
/// Represents a triangle geometric shape.
/// </summary>
public class Triangle : Shape
{
    /// <summary>
    /// Initializes a new instance of the Triangle to a specified edges.
    /// </summary>
    /// <param name="edges">Triangle edge lengths.</param>
    public Triangle(decimal[] edges)
    {
        if (edges.Length is not 3)
            throw new ArgumentOutOfRangeException(nameof(edges), "Triangle must have three edges.");

        if (edges.Any(edge => edge <= 0))
            throw new ArgumentOutOfRangeException(nameof(edges), "Edge less than or equal to zero.");

        if (!IsCorrectEdges(edges))
            throw new ArgumentOutOfRangeException(nameof(edges), "The sum of two edges is less than the third.");

        Edges = edges;
    }

    private IReadOnlyList<decimal> Edges { get; }

    public override decimal CalculateArea()
    {
        var semiPerimeter = (Edges[0] + Edges[1] + Edges[2]) / 2;

        var area = DecimalEx.Sqrt(semiPerimeter * (semiPerimeter - Edges[0]) * (semiPerimeter - Edges[1]) *
                                  (semiPerimeter - Edges[2]));

        return area;
    }

    /// <summary>
    /// Checks if a triangle is right.
    /// </summary>
    public bool IsRight() => new[]
        {
            IsInversePythagoreanTheorem(Edges[0], Edges[1], Edges[2]),
            IsInversePythagoreanTheorem(Edges[1], Edges[2], Edges[0]),
            IsInversePythagoreanTheorem(Edges[2], Edges[0], Edges[1])
        }
        .Any(isRight => isRight);

    private static bool IsCorrectEdges(decimal[] edges) => new[]
    {
        edges[0] < edges[1] + edges[2],
        edges[1] < edges[2] + edges[0],
        edges[2] < edges[0] + edges[1]

    }
        .All(isCorrect => isCorrect);

    private static bool IsInversePythagoreanTheorem(decimal firstLeg, decimal secondLeg, decimal hypotenuse) =>
        (firstLeg * firstLeg) + (secondLeg * secondLeg) == hypotenuse * hypotenuse;
}
