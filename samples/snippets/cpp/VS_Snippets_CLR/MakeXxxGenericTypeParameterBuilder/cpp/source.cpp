//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

int main()
{
    // Define a dynamic assembly to contain the sample type. The
    // assembly will not be run, but only saved to disk, so
    // AssemblyBuilderAccess.Save is specified.
    //
    AppDomain^ appDomain = AppDomain::CurrentDomain;
    AssemblyName^ assemblyName = gcnew
        AssemblyName("MakeXxxGenericTypeParameterExample");
    AssemblyBuilder^ assemblyBuilder = appDomain->DefineDynamicAssembly
        (assemblyName, AssemblyBuilderAccess::Save);

    // An assembly is made up of executable modules. For a single
    // module assembly, the module name and file name are the
    // same as the assembly name.
    ModuleBuilder^ moduleBuilder = assemblyBuilder->DefineDynamicModule
        (assemblyName->Name, assemblyName->Name + ".dll");

    // Define the sample type.
    TypeBuilder^ typeBuilder = moduleBuilder->DefineType("Sample",
        TypeAttributes::Public | TypeAttributes::Abstract);

    // Make the sample type a generic type, by defining a type
    // parameter T. All type parameters are defined at the same
    // time, by passing an array containing the type parameter
    // names. 
    array<String^>^ typeParamNames = {"T"};
    array<GenericTypeParameterBuilder^>^ typeParams =
        typeBuilder->DefineGenericParameters(typeParamNames);

    // Define a method that takes a ByRef argument of type T, a
    // pointer to type T, and one-dimensional array of type T.
    // The method returns a two-dimensional array of type T.
    //
    // To create this method, you need Type objects that repre-
    // sent the parameter types and the return type. Use the
    // MakeByRefType, MakePointerType, and MakeArrayType methods
    // to create the Type objects, using the generic type para-
    // meter T.
    //
    Type^ byRefType = typeParams[0]->MakeByRefType();
    Type^ pointerType = typeParams[0]->MakePointerType();
    Type^ arrayType = typeParams[0]->MakeArrayType();
    Type^ twoDimArrayType = typeParams[0]->MakeArrayType(2);

    // Create the array of parameter types.
    array<Type^>^ parameterTypes = {byRefType, pointerType, arrayType};

    // Define the abstract Test method. After you have compiled
    // and run this example code, you can use ildasm.exe to open
    // MakeXxxGenericTypeParameterExample.dll, examine the Sample
    // type, and verify the parameter types and return type of
    // the TestMethod method.
    //
    MethodBuilder^ methodBuilder = typeBuilder->DefineMethod("TestMethod",
        MethodAttributes::Abstract | MethodAttributes::Virtual 
        | MethodAttributes::Public, twoDimArrayType, parameterTypes);

    // Create the type and save the assembly. For a single-file 
    // assembly, there is only one module to store the manifest 
    // information in.
    //
    typeBuilder->CreateType();
    assemblyBuilder->Save(assemblyName->Name + ".dll");
};
//</Snippet1>
