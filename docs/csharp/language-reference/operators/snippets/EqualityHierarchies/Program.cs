// <HierarchyUsage>
Shape circle1 = new Circle("red", 5.0);
Shape circle2 = new Circle("red", 7.0);
Shape circle3 = new Circle("red", 5.0);
Shape shape1  = new Shape("red");

Console.WriteLine(circle1.Equals(circle2)); // => False  (Radius differs)
Console.WriteLine(circle1.Equals(circle3)); // => True
Console.WriteLine(circle1.Equals(shape1));  // => False  (different runtime types)
// </HierarchyUsage>

// ── Type declarations ────────────────────────────────────────────────────────

// <HierarchyShapeDefinition>
// Shape is an unsealed base class. Making Equals virtual and guarding with GetType()
// ensures a derived instance is never equal to an instance of a different runtime type.
class Shape : IEquatable<Shape>
{
    public string Color { get; }
    public Shape(string color) => Color = color;

    public override bool Equals(object? obj) => Equals(obj as Shape);

    // virtual so derived classes can override and augment the comparison
    public virtual bool Equals(Shape? other) =>
        other is not null &&
        GetType() == other.GetType() &&   // reject different runtime types
        Color == other.Color;

    // GetType() is included because equality requires matching runtime types
    public override int GetHashCode() => HashCode.Combine(GetType(), Color);

    public static bool operator ==(Shape? l, Shape? r) => l?.Equals(r) ?? r is null;
    public static bool operator !=(Shape? l, Shape? r) => !(l == r);
}
// </HierarchyShapeDefinition>

// <HierarchyCircleDefinition>
class Circle : Shape
{
    public double Radius { get; }
    public Circle(string color, double radius) : base(color) => Radius = radius;

    public override bool Equals(object? obj) => Equals(obj as Shape);

    // Calls base.Equals to verify Color and runtime type, then adds Radius
    public override bool Equals(Shape? other) =>
        other is Circle c && base.Equals(c) && Radius == c.Radius;

    public override int GetHashCode() => HashCode.Combine(GetType(), Color, Radius);
}
// </HierarchyCircleDefinition>