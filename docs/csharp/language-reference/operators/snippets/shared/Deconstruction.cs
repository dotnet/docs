using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace operators;
public class Deconstruction
{
    public static void Examples()
    {
        // <TupleDeconstruction>
        var tuple = (X: 1, Y: 2);
        var (x, y) = tuple;

        Console.WriteLine(x); // output: 1
        Console.WriteLine(y); // output: 2
        // </TupleDeconstruction>

        // <TupleDeconstructionWithDiscard>
        var tuple2 = (X: 0, Y: 1, Label: "The origin");
        var (x2, _, _) = tuple2;
        // </TupleDeconstructionWithDiscard>

        // <AllDiscards>
        var (_, _, _) = tuple2;
        // </AllDiscards>

        // <RecordDeconstructionUsage>
        var house = new House(1000, "123 Coder St.")
        {
            RealtorNotes = """
            This is a great starter home, with a separate room that's a great home office setup.
            """
        };

        var (squareFeet, address) = house;
        Console.WriteLine(squareFeet); // output: 1000
        Console.WriteLine(address); // output: 123 Coder St.
        Console.WriteLine(house.RealtorNotes);
        // </RecordDeconstructionUsage>

        // <StructDeconstructionUsage>
        var point = new Point3D { X = 1, Y = 2, Z = 3 };

        // Deconstruct 3D coords
        var (x3, y3, z3) = point;
        Console.WriteLine(x3); // output: 1
        Console.WriteLine(y3); // output: 2
        Console.WriteLine(z3); // output: 3

        // Deconstruct 2D coords
        var (x4, y4) = point;
        Console.WriteLine(x4); // output: 1
        Console.WriteLine(y4); // output: 2
        // </StructDeconstructionUsage>
    }
}

// <RecordDeconstruction>
public record House(int SquareFeet, string Address)
{
    public required string RealtorNotes { get; set; }
}
// </RecordDeconstruction>

// <StructDeconstruction>
public struct Point3D
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public void Deconstruct(out int x, out int y, out int z)
    {
        x = X;
        y = Y;
        z = Z;
    }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }
}
// </StructDeconstruction>
