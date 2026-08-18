// <ClassEquality>
var order1 = new Order(42, "Shoes");
var order2 = new Order(42, "Shoes");

Console.WriteLine(order1 == order2);               // => False
Console.WriteLine(order1.Equals(order2));          // => False
Console.WriteLine(ReferenceEquals(order1, order2)); // => False

Order order3 = order1;
Console.WriteLine(order1 == order3);               // => True
// </ClassEquality>

// <StructEquality>
var pt1 = new Point(3, 4);
var pt2 = new Point(3, 4);

Console.WriteLine(pt1.Equals(pt2)); // => True
// </StructEquality>

// <RecordEquality>
var person1 = new Person("Ada", "Lovelace");
var person2 = new Person("Ada", "Lovelace");

Console.WriteLine(person1 == person2);               // => True
Console.WriteLine(person1.Equals(person2));          // => True
Console.WriteLine(ReferenceEquals(person1, person2)); // => False
// </RecordEquality>

// <RecordStructEquality>
var dim1 = new Dimension(1920, 1080);
var dim2 = new Dimension(1920, 1080);

Console.WriteLine(dim1 == dim2);      // => True
Console.WriteLine(dim1.Equals(dim2)); // => True
// </RecordStructEquality>

// <TupleEquality>
var t1 = (Name: "Grace", Role: "Engineer");
var t2 = (Name: "Grace", Role: "Engineer");

Console.WriteLine(t1 == t2); // => True
// </TupleEquality>

// <IEquatableUsage>
var red1 = new Color(255, 0, 0);
var red2 = new Color(255, 0, 0);

Console.WriteLine(red1.Equals(red2)); // => True
Console.WriteLine(red1 == red2);      // => False  (no == overload; identity check)
// </IEquatableUsage>

// <ReferenceEqualsDemo>
var doc1 = new Document("Report");
var doc2 = new Document("Report");
var doc3 = doc1;

Console.WriteLine(ReferenceEquals(doc1, doc2)); // => False
Console.WriteLine(ReferenceEquals(doc1, doc3)); // => True
// </ReferenceEqualsDemo>

// <RecordWithCollectionProblem>
var playlist1 = new Playlist("Chill", new List<string> { "Song A", "Song B" });
var playlist2 = new Playlist("Chill", new List<string> { "Song A", "Song B" });

Console.WriteLine(playlist1.Equals(playlist2));                        // => False (different List instances)
Console.WriteLine(playlist1.Tracks.SequenceEqual(playlist2.Tracks));   // => True
// </RecordWithCollectionProblem>

// <RecordWithCollectionFixed>
var fixed1 = new PlaylistFixed("Chill", new List<string> { "Song A", "Song B" });
var fixed2 = new PlaylistFixed("Chill", new List<string> { "Song A", "Song B" });

Console.WriteLine(fixed1.Equals(fixed2)); // => True
// </RecordWithCollectionFixed>

// <PolymorphicEqualityUsage>
Shape circle1 = new Circle("red", 5.0);
Shape circle2 = new Circle("red", 7.0);
Shape circle3 = new Circle("red", 5.0);

Console.WriteLine(circle1.Equals(circle2)); // => False  (Radius differs)
Console.WriteLine(circle1.Equals(circle3)); // => True
// </PolymorphicEqualityUsage>

// ── Type declarations ────────────────────────────────────────────────────────

class Order(int id, string name)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
}

struct Point(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;
}

record Person(string First, string Last);

record struct Dimension(double Width, double Height);

// <ColorDefinition>
class Color : IEquatable<Color>
{
    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public int R { get; }
    public int G { get; }
    public int B { get; }

    public bool Equals(Color? other) =>
        other is not null && R == other.R && G == other.G && B == other.B;

    public override bool Equals(object? obj) => obj is Color other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(R, G, B);
}
// </ColorDefinition>

class Document(string title)
{
    public string Title { get; } = title;
}

// <PolymorphicEqualityDefinition>
// Unsealed class hierarchy — make the typed Equals virtual and guard with GetType()
// so a derived instance is never equal to an instance of a different runtime type.
class Shape : IEquatable<Shape>
{
    public string Color { get; }
    public Shape(string color) => Color = color;

    public override bool Equals(object? obj) => Equals(obj as Shape);

    // virtual so derived classes can override the comparison logic
    public virtual bool Equals(Shape? other) =>
        other is not null &&
        GetType() == other.GetType() &&   // reject different runtime types
        Color == other.Color;

    public override int GetHashCode() => HashCode.Combine(GetType(), Color);

    public static bool operator ==(Shape? l, Shape? r) => l?.Equals(r) ?? r is null;
    public static bool operator !=(Shape? l, Shape? r) => !(l == r);
}

class Circle : Shape
{
    public double Radius { get; }
    public Circle(string color, double radius) : base(color) => Radius = radius;

    public override bool Equals(object? obj) => Equals(obj as Shape);

    public override bool Equals(Shape? other) =>
        other is Circle c && base.Equals(c) && Radius == c.Radius;

    public override int GetHashCode() => HashCode.Combine(Color, Radius);
}
// </PolymorphicEqualityDefinition>

record Playlist(string Name, List<string> Tracks);

// <PlaylistFixedDefinition>
record PlaylistFixed(string Name, List<string> Tracks) : IEquatable<PlaylistFixed>
{
    public virtual bool Equals(PlaylistFixed? other) =>
        other is not null &&
        Name == other.Name &&
        Tracks.SequenceEqual(other.Tracks);

    public override int GetHashCode()
    {
        var hc = new HashCode();
        hc.Add(Name);
        foreach (var t in Tracks) hc.Add(t);
        return hc.ToHashCode();
    }
}
// </PlaylistFixedDefinition>

