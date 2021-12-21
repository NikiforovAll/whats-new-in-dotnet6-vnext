namespace Points;

public record class Point(double X, double Y, double Z);

// public record class Point
// {
//     public double X {  get; init; }
//     public double Y {  get; init; }
//     public double Z {  get; init; }
// }

public readonly record struct Point2(double X, double Y, double Z);

// public record struct Point2
// {
//     public double X {  get; init; }
//     public double Y {  get; init; }
//     public double Z {  get; init; }
// }

public record struct Point3(double X, double Y, double Z);

// public record struct Point3
// {
//     public double X { get; set; }
//     public double Y { get; set; }
//     public double Z { get; set; }
// }

public struct Point4
{
    // [new] Parameterless constructors in structs
    public Point4 ()
	{
        _secret = "secret value ctor";
        X = default; // error CS0843: Auto-implemented property 'Point4.X' must be fully assigned before control is returned to the caller.
        Y = default;
        Z = default;
	}
    public double X { get; init; }
    public double Y { get; init; }
    public double Z { get; init; }

    private string _secret;

    public override string ToString() => $"[{X},{Y},{Z}]";
}