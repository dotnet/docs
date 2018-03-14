// REDMOND\glennha
//<Snippet1>
using System;
using System.Reflection;

// Mark this public assembly for obfuscation.
[assembly:ObfuscateAssemblyAttribute(false)]

// This class is marked for obfuscation, because the assembly
// is marked.
public class Type1
{

    // Exclude this method from obfuscation. The default value
    // of the Exclude property is true, so it is not necessary
    // to specify Exclude=True, although spelling it out makes
    // your intent clearer.
    [ObfuscationAttribute(Exclude=true)]
    public void MethodA() {}

    // This member is marked for obfuscation because the class
    // is marked.
    public void MethodB() {}
}

// Exclude this type from obfuscation, but do not apply that
// exclusion to members. The default value of the Exclude 
// property is true, so it is not necessary to specify 
// Exclude=true, although spelling it out makes your intent 
// clearer.
//<Snippet4>
//<Snippet2>
[ObfuscationAttribute(Exclude=true, ApplyToMembers=false)]
public class Type2
{
//</Snippet2>

    // The exclusion of the type is not applied to its members,
    // however in order to mark the member with the "default" 
    // feature it is necessary to specify Exclude=false,
    // because the default value of Exclude is true. The tool
    // should not strip this attribute after obfuscation.
//<Snippet3>
    [ObfuscationAttribute(Exclude=false, Feature="default", 
        StripAfterObfuscation=false)]
    public void MethodA() {}
//</Snippet3>

    // This member is marked for obfuscation, because the 
    // exclusion of the type is not applied to its members.
    public void MethodB() {}

}
//</Snippet4>

// This class only exists to provide an entry point for the
// assembly and to display the attribute values.
internal class Test
{

    public static void Main()
    {

        // Display the ObfuscateAssemblyAttribute properties
        // for the assembly.        
        Assembly assem = typeof(Test).Assembly;
        object[] assemAttrs = assem.GetCustomAttributes(
            typeof(ObfuscateAssemblyAttribute), false);

        foreach( Attribute a in assemAttrs )
        {
            ShowObfuscateAssembly((ObfuscateAssemblyAttribute) a);
        }

        // Display the ObfuscationAttribute properties for each
        // type that is visible to users of the assembly.
        foreach( Type t in assem.GetTypes() )
        {
            if (t.IsVisible)
            {
                object[] tAttrs = t.GetCustomAttributes(
                    typeof(ObfuscationAttribute), false);

                foreach( Attribute a in tAttrs )
                {
                    ShowObfuscation(((ObfuscationAttribute) a),
                        t.Name);
                }

                // Display the ObfuscationAttribute properties
                // for each member in the type.
                foreach( MemberInfo m in t.GetMembers() )
                {
                    object[] mAttrs = m.GetCustomAttributes(
                        typeof(ObfuscationAttribute), false);

                    foreach( Attribute a in mAttrs )
                    {
                        ShowObfuscation(((ObfuscationAttribute) a), 
                            t.Name + "." + m.Name);
                    }
                }
            }
        }
    }

    private static void ShowObfuscateAssembly(
        ObfuscateAssemblyAttribute ob)
    {
        Console.WriteLine("\r\nObfuscateAssemblyAttribute properties:");
        Console.WriteLine("   AssemblyIsPrivate: {0}", 
            ob.AssemblyIsPrivate);
        Console.WriteLine("   StripAfterObfuscation: {0}",
            ob.StripAfterObfuscation);
    }

    private static void ShowObfuscation(
        ObfuscationAttribute ob, string target)
    {
        Console.WriteLine("\r\nObfuscationAttribute properties for: {0}",
            target);
        Console.WriteLine("   Exclude: {0}", ob.Exclude);
        Console.WriteLine("   Feature: {0}", ob.Feature);
        Console.WriteLine("   StripAfterObfuscation: {0}",
            ob.StripAfterObfuscation);
        Console.WriteLine("   ApplyToMembers: {0}", ob.ApplyToMembers);
    }
}

/* This code example produces the following output:

ObfuscateAssemblyAttribute properties:
   AssemblyIsPrivate: False
   StripAfterObfuscation: True

ObfuscationAttribute properties for: Type1.MethodA
   Exclude: True
   Feature: all
   StripAfterObfuscation: True
   ApplyToMembers: True

ObfuscationAttribute properties for: Type2
   Exclude: True
   Feature: all
   StripAfterObfuscation: True
   ApplyToMembers: False

ObfuscationAttribute properties for: Type2.MethodA
   Exclude: False
   Feature: default
   StripAfterObfuscation: False
   ApplyToMembers: True
 */
//</Snippet1>



