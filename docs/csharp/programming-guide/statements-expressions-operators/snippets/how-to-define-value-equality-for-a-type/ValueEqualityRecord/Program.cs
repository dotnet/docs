namespace ValueEqualityRecord;

public record TwoDPoint(int X, int Y);

public record ThreeDPoint(int X, int Y, int Z) : TwoDPoint(X, Y);

class Program
{
    static void Main(string[] args)
    {
        // Create some points
        TwoDPoint pointA = new TwoDPoint(3, 4);
        TwoDPoint pointB = new TwoDPoint(3, 4);
        TwoDPoint pointC = new TwoDPoint(5, 6);
        
        ThreeDPoint point3D_A = new ThreeDPoint(3, 4, 5);
        ThreeDPoint point3D_B = new ThreeDPoint(3, 4, 5);
        ThreeDPoint point3D_C = new ThreeDPoint(3, 4, 7);

        Console.WriteLine("=== Value Equality with Records ===");
        
        // Value equality works automatically
        Console.WriteLine($"pointA.Equals(pointB) = {pointA.Equals(pointB)}"); // True
        Console.WriteLine($"pointA == pointB = {pointA == pointB}"); // True
        Console.WriteLine($"pointA.Equals(pointC) = {pointA.Equals(pointC)}"); // False
        Console.WriteLine($"pointA == pointC = {pointA == pointC}"); // False

        Console.WriteLine("\n=== Hash Codes ===");
        
        // Equal objects have equal hash codes automatically
        Console.WriteLine($"pointA.GetHashCode() = {pointA.GetHashCode()}");
        Console.WriteLine($"pointB.GetHashCode() = {pointB.GetHashCode()}");
        Console.WriteLine($"pointC.GetHashCode() = {pointC.GetHashCode()}");
        
        Console.WriteLine("\n=== Inheritance with Records ===");
        
        // Inheritance works correctly with value equality
        Console.WriteLine($"point3D_A.Equals(point3D_B) = {point3D_A.Equals(point3D_B)}"); // True
        Console.WriteLine($"point3D_A == point3D_B = {point3D_A == point3D_B}"); // True
        Console.WriteLine($"point3D_A.Equals(point3D_C) = {point3D_A.Equals(point3D_C)}"); // False
        
        // Different types are not equal (unlike problematic class example)
        Console.WriteLine($"pointA.Equals(point3D_A) = {pointA.Equals(point3D_A)}"); // False
        
        Console.WriteLine("\n=== Collections ===");
        
        // Works seamlessly with collections
        var pointSet = new HashSet<TwoDPoint> { pointA, pointB, pointC };
        Console.WriteLine($"Set contains {pointSet.Count} unique points"); // 2 unique points
        
        var pointDict = new Dictionary<TwoDPoint, string>
        {
            { pointA, "First point" },
            { pointC, "Different point" }
        };
        
        // Demonstrate that equivalent points work as the same key
        var duplicatePoint = new TwoDPoint(3, 4);
        Console.WriteLine($"Dictionary contains key for {duplicatePoint}: {pointDict.ContainsKey(duplicatePoint)}"); // True
        Console.WriteLine($"Dictionary contains {pointDict.Count} entries"); // 2 entries
        
        Console.WriteLine("\n=== String Representation ===");
        
        // Automatic ToString implementation
        Console.WriteLine($"pointA.ToString() = {pointA}");
        Console.WriteLine($"point3D_A.ToString() = {point3D_A}");

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}

/* Expected Output:
=== Value Equality with Records ===
pointA.Equals(pointB) = True
pointA == pointB = True
pointA.Equals(pointC) = False
pointA == pointC = False

=== Hash Codes ===
pointA.GetHashCode() = -1400834708
pointB.GetHashCode() = -1400834708
pointC.GetHashCode() = -148136000

=== Inheritance with Records ===
point3D_A.Equals(point3D_B) = True
point3D_A == point3D_B = True
point3D_A.Equals(point3D_C) = False
pointA.Equals(point3D_A) = False

=== Collections ===
Set contains 2 unique points
Dictionary contains key for TwoDPoint { X = 3, Y = 4 }: True
Dictionary contains 2 entries

=== String Representation ===
pointA.ToString() = TwoDPoint { X = 3, Y = 4 }
point3D_A.ToString() = ThreeDPoint { X = 3, Y = 4, Z = 5 }
*/