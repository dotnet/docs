//<Snippet1>
using System;
using System.Reflection;

[assembly: ObfuscateAssemblyAttribute(true, 
    StripAfterObfuscation=false)]
//</Snippet1>

public class Type1
{
    [ObfuscationAttribute(Exclude=true)]
    public void MethodA() {}

    public static void Main() {}
}
