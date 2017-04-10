// REDMOND\glennha
// <Snippet1>
using System;
using System.Drawing;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        List<PointF> lpf = new List<PointF>();

        lpf.Add(new PointF(27.8F, 32.62F));
        lpf.Add(new PointF(99.3F, 147.273F));
        lpf.Add(new PointF(7.5F, 1412.2F));

        Console.WriteLine();
        foreach( PointF p in lpf )
        {
            Console.WriteLine(p);
        }

        List<Point> lp = lpf.ConvertAll( 
            new Converter<PointF, Point>(PointFToPoint));

        Console.WriteLine();
        foreach( Point p in lp )
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


