//<snippet1>
using System;
using System.Collections.Generic;
// Simple business object. A PartId is used to identify a part 
// but the part name be different for the same Id.
public class Part : IEquatable<Part>
{
    public string PartName { get; set; }
    public int PartId { get; set; }
    public override string ToString()
    {
        return "ID: " + PartId + "   Name: " + PartName;
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Part objAsPart = obj as Part;
        if (objAsPart == null) return false;
        else return Equals(objAsPart);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public bool Equals(Part other)
    {
        if (other == null) return false;
        return (this.PartId.Equals(other.PartId));
    }
    // Should also override == and != operators.

}
public class Example
{

    public static void Main()
    {
        List<Part> parts = new List<Part>();

        Console.WriteLine("\nCapacity: {0}", parts.Capacity);

        parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
        parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
        parts.Add(new Part() { PartName = "seat", PartId = 1434 });
        parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
        parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;

        Console.WriteLine();
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }

        Console.WriteLine("\nCapacity: {0}", parts.Capacity);
        Console.WriteLine("Count: {0}", parts.Count);

        parts.TrimExcess();
        Console.WriteLine("\nTrimExcess()");
        Console.WriteLine("Capacity: {0}", parts.Capacity);
        Console.WriteLine("Count: {0}", parts.Count);

        parts.Clear();
        Console.WriteLine("\nClear()");
        Console.WriteLine("Capacity: {0}", parts.Capacity);
        Console.WriteLine("Count: {0}", parts.Count);
    }
    /*
     This code example produces the following output. 
            Capacity: 0

            ID: 1234   Name: crank arm
            ID: 1334   Name: chain ring
            ID: 1434   Name: seat
            ID: 1534   Name: cassette
            ID: 1634   Name: shift lever

            Capacity: 8
            Count: 5

            TrimExcess()
            Capacity: 5
            Count: 5

            Clear()
            Capacity: 5
            Count: 0
     */
}
//</snippet1>

