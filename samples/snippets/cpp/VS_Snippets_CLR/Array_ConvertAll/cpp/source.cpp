// REDMOND\glennha
// <Snippet1>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections::Generic;

Point PointFToPoint(PointF pf)
{
    return Point((int) pf.X, (int) pf.Y);
};

void main()
{
    // Create an array of PointF objects.
    array<PointF>^ apf = {
        PointF(27.8F, 32.62F),
        PointF(99.3F, 147.273F),
        PointF(7.5F, 1412.2F) };


    // Display each element in the PointF array.
    Console::WriteLine();
    for each(PointF p in apf)
    {
        Console::WriteLine(p);
    }

    // Convert each PointF element to a Point object.
    array<Point>^ ap = 
        Array::ConvertAll(apf, 
            gcnew Converter<PointF, Point>(PointFToPoint)
        );

    // Display each element in the Point array.
    Console::WriteLine();
    for each(Point p in ap)
    {
        Console::WriteLine(p);
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


