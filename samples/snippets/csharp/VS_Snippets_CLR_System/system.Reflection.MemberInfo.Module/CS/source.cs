//<Snippet1>
using System;
using System.Reflection;

public class Test
{
    public override string ToString()
    {
        return "An instance of class Test!";
    }
}

public class Example
{
    public static void Main()
    {
        Test t = new Test();
        MethodInfo mi = t.GetType().GetMethod("ToString");
        Console.WriteLine("{0} is defined in {1}", mi.Name, mi.Module.Name);

        mi = t.GetType().GetMethod("GetHashCode");
        Console.WriteLine("{0} is defined in {1}", mi.Name, mi.Module.Name);
    }
}

/* This example produces code similar to the following:

  ToString is defined in source.exe
  GetHashCode is defined in mscorlib.dll
 */
//</Snippet1>
