//<snippet1>
using namespace System;
//<snippet2>
using namespace System::Reflection;
[assembly:AssemblyTitle("My Assembly")];
//</snippet2>

//<snippet3>
public ref class Example
{
    // Specify attributes between square brackets in C#.
    // This attribute is applied only to the Add method.
public:
    [Obsolete("Will be removed in next version.")]
    static int Add(int a, int b)
    {
        return (a + b);
    }
};

ref class Test
{
public:
    static void Main()
    {
        // This generates a compile-time warning.
        int i = Example::Add(2, 2);
    }
};

int main()
{
    Test::Main();
}
//</snippet3>
//</snippet1>
