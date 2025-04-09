
using System.Xml.Linq;

FirstExample();

void FirstExample()
{
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
}

