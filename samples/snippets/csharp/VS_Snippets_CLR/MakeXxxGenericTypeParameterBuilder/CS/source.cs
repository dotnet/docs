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
        AssemblyName myAsmName = new 
            AssemblyName("MakeXxxGenericTypeParameterExample");
        AssemblyBuilder myAssembly = myDomain.DefineDynamicAssembly(
            myAsmName, AssemblyBuilderAccess.Save);

        // An assembly is made up of executable modules. For a single-
        // module assembly, the module name and file name are the same 
        // as the assembly name. 
        //
        ModuleBuilder myModule = myAssembly.DefineDynamicModule(
            myAsmName.Name, myAsmName.Name + ".dll");

        // Define the sample type.
        TypeBuilder myType = myModule.DefineType("Sample", 
            TypeAttributes.Public | TypeAttributes.Abstract);

        // Make the sample type a generic type, by defining a type
        // parameter T. All type parameters are defined at the same
        // time, by passing an array containing the type parameter
        // names. 
        string[] typeParamNames = {"T"};
        GenericTypeParameterBuilder[] typeParams = 
            myType.DefineGenericParameters(typeParamNames);

        // Define a method that takes a ByRef argument of type T, a
        // pointer to type T, and one-dimensional array of type T. The
        // method returns a two-dimensional array of type T.
        //
        // To create this method, you need Type objects that represent the
        // parameter types and the return type. Use the MakeByRefType, 
        // MakePointerType, and MakeArrayType methods to create the Type
        // objects, using the generic type parameter T.
        //
        Type byRefType = typeParams[0].MakeByRefType();
        Type pointerType = typeParams[0].MakePointerType();
        Type arrayType = typeParams[0].MakeArrayType();
        Type twoDimArrayType = typeParams[0].MakeArrayType(2);

        // Create the array of parameter types.
        Type[] parameterTypes = {byRefType, pointerType, arrayType};

        // Define the abstract Test method. After you have compiled
        // and run this example code, you can use ildasm.exe to open
        // MakeXxxGenericTypeParameterExample.dll, examine the Sample
        // type, and verify the parameter types and return type of
        // the TestMethod method.
        //
        MethodBuilder myMethodBuilder = myType.DefineMethod(
            "TestMethod", 
            MethodAttributes.Abstract | MethodAttributes.Virtual
            | MethodAttributes.Public, 
            twoDimArrayType, 
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


