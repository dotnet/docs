using System;

namespace MethodParameters;

// <DataTypes>
public record struct Point(int X, int Y);
// This doesn't use a primary constructor because the properties implemented for `record` types are 
// readonly in record class types. That would prevent the mutations necessary for this example.
public record class Point3D
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
}
// </DataTypes>

// <PassTypesByValue>
public class PassTypesByValue
{
    public static void Mutate(Point pt)
    {
        Console.WriteLine($"\tEnter {nameof(Mutate)}:\t\t{pt}");
        pt.X = 19;
        pt.Y = 23;

        Console.WriteLine($"\tExit {nameof(Mutate)}:\t\t{pt}");
    }
    public static void Mutate(Point3D pt)
    {
        Console.WriteLine($"\tEnter {nameof(Mutate)}:\t\t{pt}");
        pt.X = 19;
        pt.Y = 23;
        pt.Z = 42;

        Console.WriteLine($"\tExit {nameof(Mutate)}:\t\t{pt}");
    }

    public static void TestPassTypesByValue()
    {
        Console.WriteLine("===== Value Types =====");

        var ptStruct = new Point { X = 1, Y = 2 };
        Console.WriteLine($"After initialization:\t\t{ptStruct}");

        Mutate(ptStruct);

        Console.WriteLine($"After called {nameof(Mutate)}:\t\t{ptStruct}");

        Console.WriteLine("===== Reference Types =====");

        var ptClass = new Point3D { X = 1, Y = 2, Z = 3 };

        Console.WriteLine($"After initialization:\t\t{ptClass}");

        Mutate(ptClass);
        Console.WriteLine($"After called {nameof(Mutate)}:\t\t{ptClass}");

        // Output:
        // ===== Value Types =====
        // After initialization:           Point { X = 1, Y = 2 }
        //         Enter Mutate:           Point { X = 1, Y = 2 }
        //         Exit Mutate:            Point { X = 19, Y = 23 }
        // After called Mutate:            Point { X = 1, Y = 2 }
        // ===== Reference Types =====
        // After initialization:           Point3D { X = 1, Y = 2, Z = 3 }
        //         Enter Mutate:           Point3D { X = 1, Y = 2, Z = 3 }
        //         Exit Mutate:            Point3D { X = 19, Y = 23, Z = 42 }
        // After called Mutate:            Point3D { X = 19, Y = 23, Z = 42 }
    }
}
// </PassTypesByValue>


// <PassTypesByReference>
public class PassTypesByReference
{
    public static void Mutate(ref Point pt)
    {
        Console.WriteLine($"\tEnter {nameof(Mutate)}:\t\t{pt}");
        pt.X = 19;
        pt.Y = 23;

        Console.WriteLine($"\tExit {nameof(Mutate)}:\t\t{pt}");
    }
    public static void Mutate(ref Point3D pt)
    {
        Console.WriteLine($"\tEnter {nameof(Mutate)}:\t\t{pt}");
        pt.X = 19;
        pt.Y = 23;
        pt.Z = 42;

        Console.WriteLine($"\tExit {nameof(Mutate)}:\t\t{pt}");
    }

    public static void TestPassTypesByReference()
    {
        Console.WriteLine("===== Value Types =====");

        var pStruct = new Point { X = 1, Y = 2 };
        Console.WriteLine($"After initialization:\t\t{pStruct}");

        Mutate(ref pStruct);

        Console.WriteLine($"After called {nameof(Mutate)}:\t\t{pStruct}");

        Console.WriteLine("===== Reference Types =====");

        var pClass = new Point3D { X = 1, Y = 2, Z = 3 };

        Console.WriteLine($"After initialization:\t\t{pClass}");

        Mutate(ref pClass);
        Console.WriteLine($"After called {nameof(Mutate)}:\t\t{pClass}");

        // Output:
        // ===== Value Types =====
        // After initialization:           Point { X = 1, Y = 2 }
        //         Enter Mutate:           Point { X = 1, Y = 2 }
        //         Exit Mutate:            Point { X = 19, Y = 23 }
        // After called Mutate:            Point { X = 19, Y = 23 }
        // ===== Reference Types =====
        // After initialization:           Point3D { X = 1, Y = 2, Z = 3 }
        //         Enter Mutate:           Point3D { X = 1, Y = 2, Z = 3 }
        //         Exit Mutate:            Point3D { X = 19, Y = 23, Z = 42 }
        // After called Mutate:            Point3D { X = 19, Y = 23, Z = 42 }
    }
}
// </PassTypesByReference>

// <PassByValueReassignment>
public class PassByValueReassignment
{
    public static void Reassign(Point pt)
    {
        Console.WriteLine($"\tEnter {nameof(Reassign)}:\t\t{pt}");
        pt = new Point { X = 13, Y = 29 };

        Console.WriteLine($"\tExit {nameof(Reassign)}:\t\t{pt}");
    }

    public static void Reassign(Point3D pt)
    {
        Console.WriteLine($"\tEnter {nameof(Reassign)}:\t\t{pt}");
        pt = new Point3D { X = 13, Y = 29, Z = -42 };

        Console.WriteLine($"\tExit {nameof(Reassign)}:\t\t{pt}");
    }

    public static void TestPassByValueReassignment()
    {
        Console.WriteLine("===== Value Types =====");

        var ptStruct = new Point { X = 1, Y = 2 };
        Console.WriteLine($"After initialization:\t\t{ptStruct}");

        Reassign(ptStruct);

        Console.WriteLine($"After called {nameof(Reassign)}:\t\t{ptStruct}");

        Console.WriteLine("===== Reference Types =====");

        var ptClass = new Point3D { X = 1, Y = 2, Z = 3 };

        Console.WriteLine($"After initialization:\t\t{ptClass}");

        Reassign(ptClass);
        Console.WriteLine($"After called {nameof(Reassign)}:\t\t{ptClass}");

        // Output:
        // ===== Value Types =====
        // After initialization:           Point { X = 1, Y = 2 }
        //         Enter Reassign:         Point { X = 1, Y = 2 }
        //         Exit Reassign:          Point { X = 13, Y = 29 }
        // After called Reassign:          Point { X = 1, Y = 2 }
        // ===== Reference Types =====
        // After initialization:           Point3D { X = 1, Y = 2, Z = 3 }
        //         Enter Reassign:         Point3D { X = 1, Y = 2, Z = 3 }
        //         Exit Reassign:          Point3D { X = 13, Y = 29, Z = -42 }
        // After called Reassign:          Point3D { X = 1, Y = 2, Z = 3 }
    }
}
// </PassByValueReassignment>

// <PassByReferenceReassignment>
public class PassByReferenceReassignment
{
    public static void Reassign(ref Point pt)
    {
        Console.WriteLine($"\tEnter {nameof(Reassign)}:\t\t{pt}");
        pt = new Point { X = 13, Y = 29 };

        Console.WriteLine($"\tExit {nameof(Reassign)}:\t\t{pt}");
    }

    public static void Reassign(ref Point3D pt)
    {
        Console.WriteLine($"\tEnter {nameof(Reassign)}:\t\t{pt}");
        pt = new Point3D { X = 13, Y = 29, Z = -42 };

        Console.WriteLine($"\tExit {nameof(Reassign)}:\t\t{pt}");
    }

    public static void TestPassByReferenceReassignment()
    {
        Console.WriteLine("===== Value Types =====");

        var ptStruct = new Point { X = 1, Y = 2 };
        Console.WriteLine($"After initialization:\t\t{ptStruct}");

        Reassign(ref ptStruct);

        Console.WriteLine($"After called {nameof(Reassign)}:\t\t{ptStruct}");

        Console.WriteLine("===== Reference Types =====");

        var ptClass = new Point3D { X = 1, Y = 2, Z = 3 };

        Console.WriteLine($"After initialization:\t\t{ptClass}");

        Reassign(ref ptClass);
        Console.WriteLine($"After called {nameof(Reassign)}:\t\t{ptClass}");

        // Output:
        // ===== Value Types =====
        // After initialization:           Point { X = 1, Y = 2 }
        //         Enter Reassign:         Point { X = 1, Y = 2 }
        //         Exit Reassign:          Point { X = 13, Y = 29 }
        // After called Reassign:          Point { X = 13, Y = 29 }
        // ===== Reference Types =====
        // After initialization:           Point3D { X = 1, Y = 2, Z = 3 }
        //         Enter Reassign:         Point3D { X = 1, Y = 2, Z = 3 }
        //         Exit Reassign:          Point3D { X = 13, Y = 29, Z = -42 }
        // After called Reassign:          Point3D { X = 13, Y = 29, Z = -42 }
    }
}
// </PassByReferenceReassignment>

