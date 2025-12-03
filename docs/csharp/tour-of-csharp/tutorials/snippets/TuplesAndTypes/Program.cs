// <CreateTuple>
var pt = (X: 1, Y: 2);

var slope = (double)pt.Y / (double)pt.X;
Console.WriteLine($"A line from the origin to the point {pt} has a slope of {slope}.");
// </CreateTuple>

// <Modify>
pt.X = pt.X + 5;
Console.WriteLine($"The point is now at {pt}.");
// </Modify>

// <Wither>
var pt2 = pt with { Y = 10 };
Console.WriteLine($"The point 'pt2' is at {pt2}.");
// </Wither>

// <NamedAssignment>
var subscript = (A: 0, B: 0);
subscript = pt;
Console.WriteLine(subscript);
// </NamedAssignment>

// <TupleTypes>
var namedData = (Name: "Morning observation", Temp: 17, Wind: 4);
var person = (FirstName: "", LastName: "");
var order = (Product: "guitar picks", style: "triangle", quantity: 500, UnitPrice: 0.10m);
// </TupleTypes>

// <UsePointRecord>
Point pt3 = new Point(1, 1);
var pt4 = pt3 with { Y = 10 };
Console.WriteLine($"The two points are {pt} and {pt2}");
// </UsePointRecord>

// <UseSlope>
double slopeResult = pt4.Slope();
Console.WriteLine($"The slope of {pt4} is {slopeResult}");
// </UseSlope>

// <RecordStructPoint>
public record struct Point(int X, int Y)
// </RecordStructPoint>
// <AddSlopeMethod>
{
    public double Slope() => (double)Y / (double)X;
}
// </AddSlopeMethod>

namespace PrimaryRecord
{
    // <PointRecord>
    public record Point(int X, int Y);
    // </PointRecord>
}

