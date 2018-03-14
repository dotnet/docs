//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;

class Example
{
    static void Main()
    {
        // Create a CustomAttributeBuilder for the assembly attribute. 
        // 
        // SecurityTransparentAttribute has a parameterless constructor, 
        // which is retrieved by passing an array of empty types for the
        // constructor's parameter types. The CustomAttributeBuilder is 
        // then created by passing the ConstructorInfo and an empty array
        // of objects to represent the parameters.
        //
        ConstructorInfo transparentCtor = 
            typeof(SecurityTransparentAttribute).GetConstructor(
                Type.EmptyTypes);
        CustomAttributeBuilder transparent = new CustomAttributeBuilder(
            transparentCtor,
            new Object[] {} );
      
        // Create a dynamic assembly using the attribute. The attribute is
        // passed as an array with one element.
        AssemblyName aName = new AssemblyName("EmittedAssembly");
        AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly( 
            aName, 
            AssemblyBuilderAccess.Run,
            new CustomAttributeBuilder[] { transparent } );

        ModuleBuilder mb = ab.DefineDynamicModule( aName.Name );
        TypeBuilder tb = mb.DefineType( 
            "MyDynamicType", 
            TypeAttributes.Public );
        tb.CreateType();

        Console.WriteLine("{0}\nAssembly attributes:", ab);
        foreach (Attribute attr in ab.GetCustomAttributes(true))
        {
            Console.WriteLine("\t{0}", attr);
        }
    }
}

/* This code example produces the following output:

EmittedAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
Assembly attributes:
        System.Security.SecurityTransparentAttribute
 */
//</Snippet1>
