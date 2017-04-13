// REDMOND\glennha
// <Snippet1>
using System;
using System.Drawing;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create an array of PointF objects.
        PointF[] apf = {
            new PointF(27.8F, 32.62F),
            new PointF(99.3F, 147.273F),
            new PointF(7.5F, 1412.2F) };

        // Display each element in the PointF array.
        Console.WriteLine();
        foreach( PointF p in apf )
            Console.WriteLine(p);

        // Convert each PointF element to a Point object.
        Point[] ap = Array.ConvertAll(apf, 
            new Converter<PointF, Point>(PointFToPoint));

        // Display each element in the Point array.
        Console.WriteLine();
        foreach( Point p in ap )
        {
            Console.WriteLine(p);
        }
    }

    public static Point PointFToPoint(PointF pf)
    {
        return new Point(((int) pf.X), ((int) pf.Y));
    }
}

/* This code example produces the following output:

{X=27.8, Y=32.62}
{X=99.3, Y=147.273}
{X=7.5, Y=1412.2}

{X=27,Y=32}
{X=99,Y=147}
{X=7,Y=1412}
 */
// </Snippet1>


