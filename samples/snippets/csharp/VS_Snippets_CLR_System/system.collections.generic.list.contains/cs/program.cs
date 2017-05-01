// <Snippet1>
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Cube> cubes = new List<Cube>();

        cubes.Add(new Cube(8, 8, 4));
        cubes.Add(new Cube(8, 4, 8));
        cubes.Add(new Cube(8, 6, 4));

        if (cubes.Contains(new Cube(8, 6, 4))) {
            Console.WriteLine("An equal cube is already in the collection.");
        }
        else {
            Console.WriteLine("Cube can be added.");
        }

        //Outputs "An equal cube is already in the collection."
    }
}

public class Cube : IEquatable<Cube>
{

    public Cube(int h, int l, int w)
    {
        this.Height = h;
        this.Length = l;
        this.Width = w;
    }
    public int Height { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }

    public bool Equals(Cube other)
    {
        if (this.Height == other.Height && this.Length == other.Length
            && this.Width == other.Width) {
            return true;
        }
        else {
            return false;
        }
    }
}
// </Snippet1>