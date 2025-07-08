using System;
using System.Reflection;

class Example
{   static void Main()
    {
        string test = "System.Collections.Generic.Dictionary`2[System.String,[MyNamespace.MyType, MyAssembly]]";
        //<Snippet1>
        Type t = Type.GetType(test,
                              (aName) => aName.Name == "MyAssembly" ?
                                  Assembly.LoadFrom(@".\MyPath\v5.0\MyAssembly.dll") : null,
                              (assem, name, ignore) => assem == null ?
                                  Type.GetType(name, false, ignore) :
                                      assem.GetType(name, false, ignore)
                             );
        //</Snippet1>
        Console.WriteLine(t);

        test = "System.Collections.Generic.Dictionary`2[[YourNamespace.YourType, YourAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null], [MyNamespace.MyType, MyAssembly]]";
        //<Snippet2>
        Type t2 = Type.GetType(test,
                               (aName) => aName.Name == "MyAssembly" ?
                                   Assembly.LoadFrom(@".\MyPath\v5.0\MyAssembly.dll") :
                                   Assembly.Load(aName),
                               (assem, name, ignore) => assem == null ?
                                   Type.GetType(name, false, ignore) :
                                       assem.GetType(name, false, ignore), true
                              );
        //</Snippet2>
        Console.WriteLine(t2);
    }
}
