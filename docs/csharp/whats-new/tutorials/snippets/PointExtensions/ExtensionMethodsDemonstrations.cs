using System.Drawing;
using System.Numerics;
using ExtensionMethods;

public static class ExtensionMethodsDemonstrations
{
    public static void TraditionalExtensionMethods()
    {
        Console.WriteLine("Existing Extension Methods Demonstration");
        Console.WriteLine("==========================================\n");

        OriginAsADataElement();
        ArithmeticWithPoints();
        DiscreteArithmeticWithPoints();
        ExtensionMethodsThis();
        MoreExamples();
    }

    static void OriginAsADataElement()
    {
        // <StaticPropertySubstitute>
        Console.WriteLine("1. Retrieve the origin");
        Console.WriteLine("--------------------------------------------");

        // Inline implementation since Point.Origin doesn't exist in ExtensionMethods
        Point origin = Point.Empty; // Equivalent to Point.Origin
        Console.WriteLine($"Point.Origin (inline): {origin}");
        Console.WriteLine($"Same as Point.Empty: {origin == Point.Empty}");
        Console.WriteLine();
        // </StaticPropertySubstitute>
    }

    static void ArithmeticWithPoints()
    {
        Console.WriteLine("2. Perform arithmetic with points.");
        Console.WriteLine("-----------------------------------------------");

        Point p1 = new Point(5, 3);
        Point p2 = new Point(2, 7);

        Console.WriteLine($"Point 1: {p1}");
        Console.WriteLine($"Point 2: {p2}");
        
        // Inline implementation since + and - operators don't exist in ExtensionMethods
        Point addition = new Point(p1.X + p2.X, p1.Y + p2.Y);
        Point subtraction1 = new Point(p1.X - p2.X, p1.Y - p2.Y);
        Point subtraction2 = new Point(p2.X - p1.X, p2.Y - p1.Y);
        
        Console.WriteLine($"Addition (p1 + p2): {addition}");
        Console.WriteLine($"Subtraction (p1 - p2): {subtraction1}");
        Console.WriteLine($"Subtraction (p2 - p1): {subtraction2}");
        Console.WriteLine();
    }

    static void DiscreteArithmeticWithPoints()
    {
        // <DiscreteXYOperators>
        Console.WriteLine("3. Addition and subtraction with discrete X and Y values");
        Console.WriteLine("------------------------------------------");

        Point point = new Point(10, 8);
        int offsetX = 3;
        int offsetY = -2;
        int scaleX = 2;
        int scaleY = 3;
        int divisorX = 2;
        int divisorY = 4;

        Console.WriteLine($"Original point: {point}");
        Console.WriteLine($"Offset: ({offsetX}, {offsetY})");
        Console.WriteLine($"Scale: ({scaleX}, {scaleY})");
        Console.WriteLine($"Divisor: ({divisorX}, {divisorY})");
        Console.WriteLine();

        // Inline implementations since tuple operators don't exist in ExtensionMethods
        Point addedOffset = new Point(point.X + offsetX, point.Y + offsetY);
        Point subtractedOffset = new Point(point.X - offsetX, point.Y - offsetY);
        Point scaledPoint = new Point(point.X * scaleX, point.Y * scaleY);
        Point dividedPoint = new Point(point.X / divisorX, point.Y / divisorY);

        Console.WriteLine($"point + offset: {addedOffset}");
        Console.WriteLine($"point - offset: {subtractedOffset}");
        Console.WriteLine($"point * scale: {scaledPoint}");
        Console.WriteLine($"point / divisor: {dividedPoint}");
        Console.WriteLine();
        // </DiscreteXYOperators>
    }

    static void ExtensionMethodsThis()
    {
        Console.WriteLine("4. Instance Methods (using ExtensionMethods)");
        Console.WriteLine("---------------------------------------------");

        // ToVector demonstration - using extension method
        Point vectorPoint = new Point(12, 16);
        Vector2 vector = vectorPoint.ToVector();
        Console.WriteLine($"Point {vectorPoint} as Vector2: {vector}");
        Console.WriteLine();

        // Translate demonstration - using extension method
        Point translatePoint = new Point(5, 5);
        Console.WriteLine($"Before Translate: {translatePoint}");
        translatePoint.Translate(3, -2);
        Console.WriteLine($"After Translate(3, -2): {translatePoint}");
        Console.WriteLine();

        // Scale demonstration - using extension method
        Point scalePoint = new Point(4, 6);
        Console.WriteLine($"Before Scale: {scalePoint}");
        scalePoint.Scale(2, 3);
        Console.WriteLine($"After Scale(2, 3): {scalePoint}");
        Console.WriteLine();

        // Rotate demonstration - using extension method
        Point rotatePoint1 = new Point(10, 0);
        Console.WriteLine($"Before Rotate: {rotatePoint1}");
        rotatePoint1.Rotate(90);
        Console.WriteLine($"After Rotate(90�): {rotatePoint1}");

        Point rotatePoint2 = new Point(5, 5);
        Console.WriteLine($"Before Rotate: {rotatePoint2}");
        rotatePoint2.Rotate(45);
        Console.WriteLine($"After Rotate(45�): {rotatePoint2}");

        Point rotatePoint3 = new Point(3, 4);
        Console.WriteLine($"Before Rotate: {rotatePoint3}");
        rotatePoint3.Rotate(180);
        Console.WriteLine($"After Rotate(180�): {rotatePoint3}");
        Console.WriteLine();
    }

    static void MoreExamples()
    {
        // <FinalScenarios>
        Console.WriteLine("5. Complex Scenarios (mixed implementation)");
        Console.WriteLine("-------------------------------------------");

        // Combining operators and methods
        Console.WriteLine("Scenario 1: Building a rectangle using inline operators");
        Point topLeft = Point.Empty; // Inline equivalent of Point.Origin
        Point bottomRight = new Point(topLeft.X + 10, topLeft.Y + 8); // Inline addition
        Point topRight = new Point(bottomRight.X, topLeft.Y);
        Point bottomLeft = new Point(topLeft.X, bottomRight.Y);

        Console.WriteLine($"Rectangle corners:");
        Console.WriteLine($"  Top-Left: {topLeft}");
        Console.WriteLine($"  Top-Right: {topRight}");
        Console.WriteLine($"  Bottom-Left: {bottomLeft}");
        Console.WriteLine($"  Bottom-Right: {bottomRight}");
        Console.WriteLine();

        // Transformation chain
        Console.WriteLine("Scenario 2: Transformation chain (mixed methods)");
        Point transformPoint = new Point(2, 3);
        Console.WriteLine($"Starting point: {transformPoint}");

        // Scale up - using extension method
        transformPoint.Scale(3, 2);
        Console.WriteLine($"After scaling by (3, 2): {transformPoint}");

        // Translate - using inline addition
        transformPoint = new Point(transformPoint.X + 5, transformPoint.Y + (-3));
        Console.WriteLine($"After translating by (5, -3): {transformPoint}");

        // Rotate - using extension method
        transformPoint.Rotate(45);
        Console.WriteLine($"After rotating 45�: {transformPoint}");

        // Convert to vector - using extension method
        Vector2 finalVector = transformPoint.ToVector();
        Console.WriteLine($"Final result as Vector2: {finalVector}");
        Console.WriteLine();

        // Distance calculation using inline operators and extension methods
        Console.WriteLine("Scenario 3: Distance calculation (mixed methods)");
        Point point1 = new Point(1, 1);
        Point point2 = new Point(4, 5);
        Point difference = new Point(point2.X - point1.X, point2.Y - point1.Y); // Inline subtraction
        Vector2 diffVector = difference.ToVector(); // Extension method
        float distance = diffVector.Length();

        Console.WriteLine($"Point 1: {point1}");
        Console.WriteLine($"Point 2: {point2}");
        Console.WriteLine($"Difference: {difference}");
        Console.WriteLine($"Distance: {distance:F2}");
        Console.WriteLine();

        Console.WriteLine("Traditional extension methods demonstration complete!");
        // </FinalScenarios>
    }
}