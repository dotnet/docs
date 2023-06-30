//<Snippet1>
public partial class Employee
{
    public void DoWork()
    {
    }
}

public partial class Employee
{
    public void GoToLunch()
    {
    }
}
//</Snippet1>

//<Snippet2>
class Container
{
    partial class Nested
    {
        void Test() { }
    }

    partial class Nested
    {
        void Test2() { }
    }
}
//</Snippet2>

namespace MoonExample.Partial
{
    //<Snippet3>
    [SerializableAttribute]
    partial class Moon { }

    [ObsoleteAttribute]
    partial class Moon { }
    //</Snippet3>
}

namespace MoonExample.NonPartial
{
    //<Snippet4>
    [SerializableAttribute]
    [ObsoleteAttribute]
    class Moon { }
    //</Snippet4>
}

class Planet { }

interface IRotate { }

interface IRevolve { }

//<Snippet5>
partial class Earth : Planet, IRotate { }
partial class Earth : IRevolve { }
//</Snippet5>

class WrapEquivs
{
    //<Snippet6>
    class Earth : Planet, IRotate, IRevolve { }
    //</Snippet6>
}

//<Snippet7>
public partial class A { }
//public class A { }  // Error, must also be marked partial
//</Snippet7>

//<Snippet8>
partial class ClassWithNestedClass
{
    partial class NestedClass { }
}

partial class ClassWithNestedClass
{
    partial class NestedClass { }
}
//</Snippet8>

namespace WrapCoords2
{
    //<Snippet9>
    public partial class Coords
    {
        private int x;
        private int y;

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public partial class Coords
    {
        public void PrintCoords()
        {
            Console.WriteLine("Coords: {0},{1}", x, y);
        }
    }

    class TestCoords
    {
        static void Main()
        {
            Coords myCoords = new Coords(10, 15);
            myCoords.PrintCoords();

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    // Output: Coords: 10,15
    //</Snippet9>
}

//<Snippet10>
partial interface ITest
{
    void Interface_Test();
}

partial interface ITest
{
    void Interface_Test2();
}

partial struct S1
{
    void Struct_Test() { }
}

partial struct S1
{
    void Struct_Test2() { }
}
//</Snippet10>
