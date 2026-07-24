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

