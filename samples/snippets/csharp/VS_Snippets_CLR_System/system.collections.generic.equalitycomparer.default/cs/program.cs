// <Snippet1>
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        BoxEqDimensions bxd = new BoxEqDimensions();
        BoxEqVolume bxv = new BoxEqVolume();

        Dictionary<Box, string> boxesByDim = new Dictionary<Box, string>(bxd);
        Dictionary<Box, string> boxesByVol = new Dictionary<Box, string>(bxv);

        try
        {
            Box redBox = new Box(8, 8, 4);
            Box blueBox = new Box(6, 8, 4);
            Box greenBox = new Box(4, 8, 8);

            Console.WriteLine("Adding boxes by Dimension");

            boxesByDim.Add(redBox, "red");
            boxesByDim.Add(blueBox, "blue");
            boxesByDim.Add(greenBox, "green");

            PrintBoxCollection(boxesByDim);

            Console.WriteLine("\nAdding boxes by Volume");

            boxesByVol.Add(redBox, "red");
            boxesByVol.Add(blueBox, "blue");
            boxesByVol.Add(greenBox, "green");

            PrintBoxCollection(boxesByVol);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }
    private static void PrintBoxCollection(Dictionary<Box,string> boxes)
    {
        foreach (KeyValuePair<Box, string> kvp in boxes)
        {
            Console.WriteLine("{0} x {1} x {2} - {3}", kvp.Key.Height.ToString(),
                                                       kvp.Key.Length.ToString(),
                                                       kvp.Key.Width.ToString(), kvp.Value);
        }
    }
}

public class BoxEqDimensions : EqualityComparer<Box>
{
    public override int GetHashCode(Box bx)
    {
        int hCode = bx.Height ^ bx.Length ^ bx.Width;
        return hCode.GetHashCode();
    }
    
    public override bool Equals(Box b1, Box b2)
    {
        return EqualityComparer<Box>.Default.Equals(b1, b2);
    }
}


public class BoxEqVolume : EqualityComparer<Box>
{
    public override int GetHashCode(Box bx)
    {
        int hCode = bx.Height ^ bx.Length ^ bx.Width;
        return hCode.GetHashCode();
    }

    public override bool Equals(Box b1, Box b2)
    {
        if (b1.Height * b1.Width * b1.Length ==
            b2.Height * b2.Width * b2.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Box : IEquatable<Box>
{

    public Box(int h, int l, int w)
    {
        this.Height = h;
        this.Length = l;
        this.Width = w;
    }
    public int Height { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }

    public bool Equals(Box other)
    {
        if (this.Height == other.Height & this.Length == other.Length
            & this.Width == other.Width)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

/* This example produces the following output:
 * 
   Adding boxes by Dimension
    8 x 8 x 4 - red
    6 x 8 x 4 - blue
    4 x 8 x 8 - green

    Adding boxes by Volume
    An item with the same key has already been added.
 * 
 */ 
// </Snippet1>