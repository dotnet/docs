using System;
using System.IO;
using System.Reflection;

public class Sample
{

    public void Method(Type type) {
        ConstructorInfo cInfo;
// <Snippet1>
cInfo = type.GetConstructor (BindingFlags.ExactBinding, null, 
         Type.EmptyTypes, null);
// </Snippet1>
    }
}
