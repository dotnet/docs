using System.Drawing;
using System.Numerics;
using ExtensionMembers;

public static class ExtensionMemberDemonstrations
{
    public static void NewExtensionMembers()
    {
        Console.WriteLine("Point Extension Members Demonstration");
        Console.WriteLine("=====================================\n");

        OriginAsStaticProperty();
        ArithmeticWithPoints();
        DiscreteArithmeticWithPoints();
        ExtensionMethods();
        MoreExamples();
    }

    static void OriginAsStaticProperty()
    {
        // <StaticProperty>
        Console.WriteLine("1. Static Properties");
        Console.WriteLine("-------------------");

        Point origin = Point.Origin;
        Console.WriteLine($"Point.Origin: {origin}");
        Console.WriteLine($"Same as Point.Empty: {origin == Point.Empty}");
        Console.WriteLine();
        // </StaticProperty>
    }

    static void ArithmeticWithPoints()
    {
        Console.WriteLine("2. Arithmetic Operators (Point + Point, Point - Point)");
        Console.WriteLine("-----------------------------------------------------");

        Point p1 = new Point(5, 3);
        Point p2 = new Point(2, 7);

        Console.WriteLine($"Point 1: {p1}");
        Console.WriteLine($"Point 2: {p2}");
        Console.WriteLine($"Addition (p1 + p2): {p1 + p2}");
        Console.WriteLine($"Subtraction (p1 - p2): {p1 - p2}");
        Console.WriteLine($"Subtraction (p2 - p1): {p2 - p1}");
        Console.WriteLine();
    }

    static void DiscreteArithmeticWithPoints()
    {
        // <DiscreteXYOperators>
        Console.WriteLine("3. Discrete Operators using tuples (Point with (int, int))");
        Console.WriteLine("------------------------------------------");

        Point point = new Point(10, 8);
        var offset = (3, -2);
        var scale = (2, 3);
        var divisor = (2, 4);

        Console.WriteLine($"Original point: {point}");
        Console.WriteLine($"Offset tuple: {offset}");
        Console.WriteLine($"Scale tuple: {scale}");
        Console.WriteLine($"Divisor tuple: {divisor}");
        Console.WriteLine();

        Console.WriteLine($"point + offset: {point + offset}");
        Console.WriteLine($"point - offset: {point - offset}");
        Console.WriteLine($"point * scale: {point * scale}");
        Console.WriteLine($"point / divisor: {point / divisor}");
        Console.WriteLine();
        // </DiscreteXYOperators>
    }

    static void ExtensionMethods()
    {
        // <InstanceMethods>
        Console.WriteLine("4. Instance Methods");
        Console.WriteLine("------------------");

        // ToVector demonstration
        Point vectorPoint = new Point(12, 16);
        Vector2 vector = vectorPoint.ToVector();
        Console.WriteLine($"Point {vectorPoint} as Vector2: {vector}");
        Console.WriteLine();

        // Translate demonstration
        Point translatePoint = new Point(5, 5);
        Console.WriteLine($"Before Translate: {translatePoint}");
        translatePoint.Translate(3, -2);
        Console.WriteLine($"After Translate(3, -2): {translatePoint}");
        Console.WriteLine();

        // Scale demonstration
        Point scalePoint = new Point(4, 6);
        Console.WriteLine($"Before Scale: {scalePoint}");
        scalePoint.Scale(2, 3);
        Console.WriteLine($"After Scale(2, 3): {scalePoint}");
        Console.WriteLine();

        // Rotate demonstration
        Point rotatePoint1 = new Point(10, 0);
        Console.WriteLine($"Before Rotate: {rotatePoint1}");
        rotatePoint1.Rotate(90);
        Console.WriteLine($"After Rotate(90°): {rotatePoint1}");

        Point rotatePoint2 = new Point(5, 5);
        Console.WriteLine($"Before Rotate: {rotatePoint2}");
        rotatePoint2.Rotate(45);
        Console.WriteLine($"After Rotate(45°): {rotatePoint2}");

        Point rotatePoint3 = new Point(3, 4);
        Console.WriteLine($"Before Rotate: {rotatePoint3}");
        rotatePoint3.Rotate(180);
        Console.WriteLine($"After Rotate(180°): {rotatePoint3}");
        Console.WriteLine();
        // </InstanceMethods>
    }

    static void MoreExamples()
    {
        // <FinalScenarios>
        Console.WriteLine("5. Complex Scenarios");
        Console.WriteLine("-------------------");

        // Combining operators and methods
        Console.WriteLine("Scenario 1: Building a rectangle using operators");
        Point topLeft = Point.Origin;
        Point bottomRight = topLeft + (10, 8);
        Point topRight = new Point(bottomRight.X, topLeft.Y);
        Point bottomLeft = new Point(topLeft.X, bottomRight.Y);

        Console.WriteLine($"Rectangle corners:");
        Console.WriteLine($"  Top-Left: {topLeft}");
        Console.WriteLine($"  Top-Right: {topRight}");
        Console.WriteLine($"  Bottom-Left: {bottomLeft}");
        Console.WriteLine($"  Bottom-Right: {bottomRight}");
        Console.WriteLine();

        // Transformation chain
        Console.WriteLine("Scenario 2: Transformation chain");
        Point transformPoint = new Point(2, 3);
        Console.WriteLine($"Starting point: {transformPoint}");

        // Scale up
        transformPoint.Scale(3, 2);
        Console.WriteLine($"After scaling by (3, 2): {transformPoint}");

        // Translate
        transformPoint = transformPoint + (5, -3);
        Console.WriteLine($"After translating by (5, -3): {transformPoint}");

        // Rotate
        transformPoint.Rotate(45);
        Console.WriteLine($"After rotating 45°: {transformPoint}");

        // Convert to vector
        Vector2 finalVector = transformPoint.ToVector();
        Console.WriteLine($"Final result as Vector2: {finalVector}");
        Console.WriteLine();

        // Distance calculation using operators
        Console.WriteLine("Scenario 3: Distance calculation");
        Point point1 = new Point(1, 1);
        Point point2 = new Point(4, 5);
        Point difference = point2 - point1;
        Vector2 diffVector = difference.ToVector();
        float distance = diffVector.Length();

        Console.WriteLine($"Point 1: {point1}");
        Console.WriteLine($"Point 2: {point2}");
        Console.WriteLine($"Difference: {difference}");
        Console.WriteLine($"Distance: {distance:F2}");
        Console.WriteLine();

        Console.WriteLine("Demonstration complete!");
        // </FinalScenarios>
    }
}