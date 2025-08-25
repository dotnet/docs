namespace ValueEqualityPolymorphic;

// <TwoDPointClass>
// Safe polymorphic equality implementation using explicit interface implementation
class TwoDPoint : IEquatable<TwoDPoint>
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public TwoDPoint(int x, int y)
    {
        if (x is (< 1 or > 2000) || y is (< 1 or > 2000))
        {
            throw new ArgumentException("Point must be in range 1 - 2000");
        }
        this.X = x;
        this.Y = y;
    }

    public override bool Equals(object? obj) => Equals(obj as TwoDPoint);

    // Explicit interface implementation prevents compile-time type issues
    bool IEquatable<TwoDPoint>.Equals(TwoDPoint? p) => Equals((object?)p);

    protected virtual bool Equals(TwoDPoint? p)
    {
        if (p is null)
        {
            return false;
        }

        // Optimization for a common success case.
        if (Object.ReferenceEquals(this, p))
        {
            return true;
        }

        // If run-time types are not exactly the same, return false.
        if (this.GetType() != p.GetType())
        {
            return false;
        }

        // Return true if the fields match.
        // Note that the base class is not invoked because it is
        // System.Object, which defines Equals as reference equality.
        return (X == p.X) && (Y == p.Y);
    }

    public override int GetHashCode() => (X, Y).GetHashCode();

    public static bool operator ==(TwoDPoint? lhs, TwoDPoint? rhs)
    {
        if (lhs is null)
        {
            if (rhs is null)
            {
                return true;
            }

            // Only the left side is null.
            return false;
        }
        // Equals handles case of null on right side.
        return lhs.Equals(rhs);
    }

    public static bool operator !=(TwoDPoint? lhs, TwoDPoint? rhs) => !(lhs == rhs);
}
// </TwoDPointClass>

// <ThreeDPointClass>
// For the sake of simplicity, assume a ThreeDPoint IS a TwoDPoint.
class ThreeDPoint : TwoDPoint, IEquatable<ThreeDPoint>
{
    public int Z { get; private set; }

    public ThreeDPoint(int x, int y, int z)
        : base(x, y)
    {
        if ((z < 1) || (z > 2000))
        {
            throw new ArgumentException("Point must be in range 1 - 2000");
        }
        this.Z = z;
    }

    public override bool Equals(object? obj) => Equals(obj as ThreeDPoint);

    // Explicit interface implementation prevents compile-time type issues
    bool IEquatable<ThreeDPoint>.Equals(ThreeDPoint? p) => Equals((object?)p);

    protected override bool Equals(TwoDPoint? p)
    {
        if (p is null)
        {
            return false;
        }

        // Optimization for a common success case.
        if (Object.ReferenceEquals(this, p))
        {
            return true;
        }

        // Runtime type check happens in the base method
        if (p is ThreeDPoint threeD)
        {
            // Check properties that this class declares.
            if (Z != threeD.Z)
            {
                return false;
            }

            return base.Equals(p);
        }

        return false;
    }

    public override int GetHashCode() => (X, Y, Z).GetHashCode();

    public static bool operator ==(ThreeDPoint? lhs, ThreeDPoint? rhs)
    {
        if (lhs is null)
        {
            if (rhs is null)
            {
                // null == null = true.
                return true;
            }

            // Only the left side is null.
            return false;
        }
        // Equals handles the case of null on right side.
        return lhs.Equals(rhs);
    }

    public static bool operator !=(ThreeDPoint? lhs, ThreeDPoint? rhs) => !(lhs == rhs);
}
// </ThreeDPointClass>

// <MainProgram>
class Program
{
    static void Main(string[] args)
    {
        // <PolymorphicTest>
        Console.WriteLine("=== Safe Polymorphic Equality ===");
        
        // Test polymorphic scenarios that were problematic before
        TwoDPoint p1 = new ThreeDPoint(1, 2, 3);
        TwoDPoint p2 = new ThreeDPoint(1, 2, 4);
        TwoDPoint p3 = new ThreeDPoint(1, 2, 3);
        TwoDPoint p4 = new TwoDPoint(1, 2);
        
        Console.WriteLine("Testing polymorphic equality (declared as TwoDPoint):");
        Console.WriteLine($"p1 = ThreeDPoint(1, 2, 3) as TwoDPoint");
        Console.WriteLine($"p2 = ThreeDPoint(1, 2, 4) as TwoDPoint");
        Console.WriteLine($"p3 = ThreeDPoint(1, 2, 3) as TwoDPoint");
        Console.WriteLine($"p4 = TwoDPoint(1, 2)");
        Console.WriteLine();
        
        Console.WriteLine($"p1.Equals(p2) = {p1.Equals(p2)}"); // False - different Z values
        Console.WriteLine($"p1.Equals(p3) = {p1.Equals(p3)}"); // True - same values
        Console.WriteLine($"p1.Equals(p4) = {p1.Equals(p4)}"); // False - different types
        Console.WriteLine($"p4.Equals(p1) = {p4.Equals(p1)}"); // False - different types
        Console.WriteLine();
        // </PolymorphicTest>
        
        // <DirectTest>
        // Test direct type comparisons
        var point3D_A = new ThreeDPoint(3, 4, 5);
        var point3D_B = new ThreeDPoint(3, 4, 5);
        var point3D_C = new ThreeDPoint(3, 4, 7);
        var point2D_A = new TwoDPoint(3, 4);
        
        Console.WriteLine("Testing direct type comparisons:");
        Console.WriteLine($"point3D_A.Equals(point3D_B) = {point3D_A.Equals(point3D_B)}"); // True
        Console.WriteLine($"point3D_A.Equals(point3D_C) = {point3D_A.Equals(point3D_C)}"); // False
        Console.WriteLine($"point3D_A.Equals(point2D_A) = {point3D_A.Equals(point2D_A)}"); // False
        Console.WriteLine($"point2D_A.Equals(point3D_A) = {point2D_A.Equals(point3D_A)}"); // False
        Console.WriteLine();
        // </DirectTest>
        
        // <OperatorTest>
        // Test operators
        Console.WriteLine("Testing operators:");
        Console.WriteLine($"p1 == p2: {p1 == p2}"); // False
        Console.WriteLine($"p1 == p3: {p1 == p3}"); // True
        Console.WriteLine($"point3D_A == point3D_B: {point3D_A == point3D_B}"); // True
        Console.WriteLine();
        // </OperatorTest>
        
        // <CollectionTest>
        // Test with collections
        Console.WriteLine("Testing with collections:");
        var hashSet = new HashSet<TwoDPoint> { p1, p2, p3, p4 };
        Console.WriteLine($"HashSet contains {hashSet.Count} unique points"); // Should be 3: one ThreeDPoint(1,2,3), one ThreeDPoint(1,2,4), one TwoDPoint(1,2)
        
        var dictionary = new Dictionary<TwoDPoint, string>
        {
            { p1, "First 3D point" },
            { p2, "Second 3D point" },
            { p4, "2D point" }
        };
        
        Console.WriteLine($"Dictionary contains {dictionary.Count} entries");
        Console.WriteLine($"Dictionary lookup for equivalent point: {dictionary.ContainsKey(new ThreeDPoint(1, 2, 3))}"); // True
        // </CollectionTest>

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
// </MainProgram>

/* Expected Output:
=== Safe Polymorphic Equality ===
Testing polymorphic equality (declared as TwoDPoint):
p1 = ThreeDPoint(1, 2, 3) as TwoDPoint
p2 = ThreeDPoint(1, 2, 4) as TwoDPoint
p3 = ThreeDPoint(1, 2, 3) as TwoDPoint
p4 = TwoDPoint(1, 2)

p1.Equals(p2) = False
p1.Equals(p3) = True
p1.Equals(p4) = False
p4.Equals(p1) = False

Testing direct type comparisons:
point3D_A.Equals(point3D_B) = True
point3D_A.Equals(point3D_C) = False
point3D_A.Equals(point2D_A) = False
point2D_A.Equals(point3D_A) = False

Testing operators:
p1 == p2: False
p1 == p3: True
point3D_A == point3D_B: True

Testing with collections:
HashSet contains 3 unique points
Dictionary contains 3 entries
Dictionary lookup for equivalent point: True
*/