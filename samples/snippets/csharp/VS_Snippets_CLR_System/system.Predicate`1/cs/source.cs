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

        // To find the first Point structure for which X times Y 
        // is greater than 100000, pass the array and a delegate
        // that represents the ProductGT10 method to the static 
        // Find method of the Array class. 
        Point first = Array.Find(points, ProductGT10);

        // Note that you do not need to create the delegate 
        // explicitly, or to specify the type parameter of the 
        // generic method, because the C# compiler has enough
        // context to determine that information for you.

        // Display the first structure found.
        Console.WriteLine("Found: X = {0}, Y = {1}", first.X, first.Y);
    }

    // This method implements the test condition for the Find
    // method.
    private static bool ProductGT10(Point p)
    {
        if (p.X * p.Y > 100000)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

/* This code example produces the following output:

Found: X = 275, Y = 395
 */
//</Snippet1>


