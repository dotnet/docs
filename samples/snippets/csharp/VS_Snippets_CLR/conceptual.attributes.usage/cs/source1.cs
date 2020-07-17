//<snippet1>
using System;
//<snippet2>
using System.Reflection;
[assembly:AssemblyTitle("My Assembly")]
//</snippet2>

//<snippet3>
public class Example
{
    // Specify attributes between square brackets in C#.
    // This attribute is applied only to the Add method.
    [Obsolete("Will be removed in next version.")]
    public static int Add(int a, int b)
    {
        return (a + b);
    }
}

class Test
{
    public static void Main()
    {
        // This generates a compile-time warning.
        int i = Example.Add(2, 2);
    }
}
//</snippet3>
//</snippet1>
