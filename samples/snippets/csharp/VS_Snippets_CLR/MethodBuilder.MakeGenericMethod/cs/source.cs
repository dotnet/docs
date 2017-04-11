// REDMOND\glennha
// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

class Example
{
    public static void Main()
    {
        // Define a transient dynamic assembly (only to run, not
        // to save) with one module and a type "Test".
        // 
        AssemblyName aName = new AssemblyName("MyDynamic");
        AssemblyBuilder ab = 
            AppDomain.CurrentDomain.DefineDynamicAssembly(
                aName, 
                AssemblyBuilderAccess.Run);
        ModuleBuilder mb = ab.DefineDynamicModule(aName.Name);
        TypeBuilder tb = mb.DefineType("Test");

        // Add a public static method "M" to Test, and make it a
        // generic method with one type parameter named "T").
        //
        MethodBuilder meb = tb.DefineMethod("M", 
            MethodAttributes.Public | MethodAttributes.Static);
        GenericTypeParameterBuilder[] typeParams = 
            meb.DefineGenericParameters(new string[] { "T" });

        // Give the method one parameter, of type T, and a 
        // return type of T.
        meb.SetParameters(typeParams);
        meb.SetReturnType(typeParams[0]);

        // Create a MethodInfo for M<string>, which can be used in
        // emitted code. This is possible even though the method
        // does not yet have a body, and the enclosing type is not
        // created.
        MethodInfo mi = meb.MakeGenericMethod(typeof(string));
        // Note that this is actually a subclass of MethodInfo, 
        // which has rather limited capabilities -- for
        // example, you cannot reflect on its parameters.
    }
}
// </Snippet1>