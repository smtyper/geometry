namespace Areas;

/// <summary>
/// Represents a geometric shape.
/// </summary>
public abstract class Shape : IHasArea
{
    /// <summary>
    /// Calculates shape area.
    /// </summary>
    public abstract decimal CalculateArea();
}
