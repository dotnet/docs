// <Snippet1>
using System;
using System.Reflection;

class Class1
{
    public static void Main()
    {
        // You must supply a valid fully qualified assembly name.            
        Assembly SampleAssembly = Assembly.Load
		    ("SampleAssembly, Version=1.0.2004.0, Culture=neutral, PublicKeyToken=8744b20f8da049e3");
        // Display all the types contained in the specified assembly.
		foreach (Type oType in SampleAssembly.GetTypes()) {
            Console.WriteLine(oType.Name);
        }
    }
}
// </Snippet1>