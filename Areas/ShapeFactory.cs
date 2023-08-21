namespace Areas;

/// <summary>
/// Geometrci shapes factory.
/// </summary>
public static class ShapeFactory
{
    /// <summary>
    /// Creates a new instance of the Circle to a specified radius.
    /// </summary>
    /// <param name="radius">Circle radius.</param>
    /// <returns></returns>
    public static Shape CreateCircle(decimal radius) => new Circle(radius);

    /// <summary>
    /// Creates a new instance of the Triangle to a specified edges.
    /// </summary>
    /// <param name="edges">Triangle edge lengths.</param>
    /// <returns></returns>
    public static Shape CreateTriangle(decimal[] edges) => new Triangle(edges);
}
