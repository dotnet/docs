//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.VisualBasic;

public class Example
{
    public static void Main()
    {
        // Define a dynamic assembly to contain the sample type. The
        // assembly will not be run, but only saved to disk, so
        // AssemblyBuilderAccess.Save is specified.
        //
        AppDomain myDomain = AppDomain.CurrentDomain;
        AssemblyName myAsmName = new AssemblyName("MakeXxxTypeExample");
        AssemblyBuilder myAssembly = myDomain.DefineDynamicAssembly(
            myAsmName, 
            AssemblyBuilderAccess.Save);

        // An assembly is made up of executable modules. For a single-
        // module assembly, the module name and file name are the same 
        // as the assembly name. 
        //
        ModuleBuilder myModule = myAssembly.DefineDynamicModule(
            myAsmName.Name, 
            myAsmName.Name + ".dll");

        // Define the sample type.
        TypeBuilder myType = myModule.DefineType(
            "Sample", 
            TypeAttributes.Public | TypeAttributes.Abstract);

        // Define a method that takes a ref argument of type Sample,
        // a pointer to type Sample, and an array of Sample objects. The
        // method returns a two-dimensional array of Sample objects.
        //
        // To create this method, you need Type objects that represent the
        // parameter types and the return type. Use the MakeByRefType, 
        // MakePointerType, and MakeArrayType methods to create the Type
        // objects.
        //
        Type byRefMyType = myType.MakeByRefType();
        Type pointerMyType = myType.MakePointerType();
        Type arrayMyType = myType.MakeArrayType();
        Type twoDimArrayMyType = myType.MakeArrayType(2);

        // Create the array of parameter types.
        Type[] parameterTypes = {byRefMyType, pointerMyType, arrayMyType};

        // Define the abstract Test method. After you have compiled
        // and run this code example code, you can use ildasm.exe 
        // to open MakeXxxTypeExample.dll, examine the Sample type,
        // and verify the parameter types and return type of the
        // TestMethod method.
        //
        MethodBuilder myMethodBuilder = myType.DefineMethod(
            "TestMethod", 
            MethodAttributes.Abstract | MethodAttributes.Virtual 
                | MethodAttributes.Public,
            twoDimArrayMyType,
            parameterTypes);

        // Create the type and save the assembly. For a single-file 
        // assembly, there is only one module to store the manifest 
        // information in.
        //
        myType.CreateType();
        myAssembly.Save(myAsmName.Name + ".dll");
    }
}
//</Snippet1>


