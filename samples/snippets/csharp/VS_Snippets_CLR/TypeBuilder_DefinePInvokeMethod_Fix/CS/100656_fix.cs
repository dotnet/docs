//<Snippet1>
using System;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

public class Example
{
    public static void Main()
    {
        // Create the AssemblyBuilder.
        AssemblyName asmName = new AssemblyName("PInvokeTest");           
        AssemblyBuilder dynamicAsm = AppDomain.CurrentDomain.DefineDynamicAssembly(
            asmName, 
            AssemblyBuilderAccess.RunAndSave
        );

        // Create the module.
        ModuleBuilder dynamicMod = 
            dynamicAsm.DefineDynamicModule(asmName.Name, asmName.Name + ".dll");

        // Create the TypeBuilder for the class that will contain the 
        // signature for the PInvoke call.
        TypeBuilder tb = dynamicMod.DefineType(
            "MyType", 
            TypeAttributes.Public | TypeAttributes.UnicodeClass
        );
    
        MethodBuilder mb = tb.DefinePInvokeMethod(
            "GetTickCount",
            "Kernel32.dll",
            MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.PinvokeImpl,
            CallingConventions.Standard,
            typeof(int),
            Type.EmptyTypes,
            CallingConvention.Winapi,
            CharSet.Ansi);

        // Add PreserveSig to the method implementation flags. NOTE: If this line
        // is commented out, the return value will be zero when the method is
        // invoked.
        mb.SetImplementationFlags(
            mb.GetMethodImplementationFlags() | MethodImplAttributes.PreserveSig);

        // The PInvoke method does not have a method body. 

        // Create the class and test the method.
        Type t = tb.CreateType();

        MethodInfo mi = t.GetMethod("GetTickCount");
        Console.WriteLine("Testing PInvoke method...");
        Console.WriteLine("GetTickCount returned: {0}", mi.Invoke(null, null));

        // Produce the .dll file.
        Console.WriteLine("Saving: " + asmName.Name + ".dll");
        dynamicAsm.Save(asmName.Name + ".dll");
    }
}

/* This example produces output similar to the following:

Testing PInvoke method...
GetTickCount returned: 1312576235
Saving: PInvokeTest.dll
 */
//</Snippet1>