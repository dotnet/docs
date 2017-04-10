// <Snippet1>
using System;
using System.Collections.Generic;

class Program
{
	static Dictionary<Box, String> boxes;

	static void Main()
	{
		BoxSameDimensions boxDim = new BoxSameDimensions();
		boxes = new Dictionary<Box, string>(boxDim);

		Console.WriteLine("Boxes equality by dimensions:");
		Box redBox = new Box(8, 4, 8);
		Box greenBox = new Box(8, 6, 8);
		Box blueBox = new Box(8, 4, 8);
		Box yellowBox = new Box(8, 8, 8); 
		AddBox(redBox, "red");
		AddBox(greenBox, "green");
		AddBox(blueBox, "blue");
		AddBox(yellowBox, "yellow");

		Console.WriteLine();
		Console.WriteLine("Boxes equality by volume:");

		BoxSameVolume boxVolume = new BoxSameVolume();
		boxes = new Dictionary<Box, string>(boxVolume);
		Box pinkBox = new Box(8, 4, 8);
		Box orangeBox = new Box(8, 6, 8);
		Box purpleBox = new Box(4, 8, 8);
		Box brownBox = new Box(8, 8, 4);
		AddBox(pinkBox, "pink");
		AddBox(orangeBox, "orange");
		AddBox(purpleBox, "purple");
		AddBox(brownBox, "brown");
	}

	public static void AddBox(Box bx, string name)
	{
		try
		{
			boxes.Add(bx, name);
			Console.WriteLine("Added {0}, Count = {1}, HashCode = {2}", 
				name, boxes.Count.ToString(), bx.GetHashCode());
		}
		catch (ArgumentException)
		{
			Console.WriteLine("A box equal to {0} is already in the collection.", name);
		}
	}
}

public class Box
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
}

class BoxSameDimensions : EqualityComparer<Box>
{
	public override bool Equals(Box b1, Box b2)
	{
		if (b1 == null && b2 == null)
         return true;
      else if (b1 == null || b2 == null)
         return false;
         
		if (b1.Height == b2.Height && b1.Length == b2.Length
							&& b1.Width == b2.Width)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public override int GetHashCode(Box bx)
	{
		int hCode = bx.Height ^ bx.Length ^ bx.Width;
		return hCode.GetHashCode();
	}

}

class BoxSameVolume : EqualityComparer<Box>
{
	public override bool Equals(Box b1, Box b2)
	{
		if (b1 == null && b2 == null)
         return true;
      else if (b1 == null || b2 == null)
         return false;
         
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

	public override int GetHashCode(Box bx)
	{
		int hCode = bx.Height * bx.Length * bx.Width;
		return hCode.GetHashCode();
	}
}
/* This example produces the following output:
 * 
      Boxes equality by dimensions:
      Added red, Count = 1, HashCode = 46104728
      Added green, Count = 2, HashCode = 12289376
      A box equal to blue is already in the collection.
      Added yellow, Count = 3, HashCode = 43495525

      Boxes equality by volume:
      Added pink, Count = 1, HashCode = 55915408
      Added orange, Count = 2, HashCode = 33476626
      A box equal to purple is already in the collection.
      A box equal to brown is already in the collection.
 * 
*/
// </Snippet1>