//REDMOND\glennha
//<Snippet1>
using System;
using System.Drawing;

public class Example
{
    public static void Main()
    {
        // Create an array of five Point structures.
        Point[] points = { new Point(100, 200), 
            new Point(150, 250), new Point(250, 375), 
            new Point(275, 395), new Point(295, 450) };

        // Find the first Point structure for which X times Y 
        // is greater than 100000. 
        Point first = Array.Find(points, ProductGT10);

        // Display the first structure found.
        Console.WriteLine("Found: X = {0}, Y = {1}", first.X, first.Y);
    }

    // Return true if X times Y is greater than 100000.
    private static bool ProductGT10(Point p)
    {
        return p.X * p.Y > 100000;
    }
}
// The example displays the following output:
//       Found: X = 275, Y = 395
// </Snippet1>


