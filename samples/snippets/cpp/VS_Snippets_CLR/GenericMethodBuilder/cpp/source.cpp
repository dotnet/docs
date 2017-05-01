//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class GenericReflectionSample
{
};

int main()
{
    // Creating a dynamic assembly requires an AssemblyName
    // object, and the current application domain.
    //
    AssemblyName^ asmName =
        gcnew AssemblyName("EmittedAssembly");
    AppDomain^ domain = AppDomain::CurrentDomain;
    AssemblyBuilder^ sampleAssemblyBuilder =
        domain->DefineDynamicAssembly(asmName,
        AssemblyBuilderAccess::RunAndSave);

    // Define the module that contains the code. For an
    // assembly with one module, the module name is the
    // assembly name plus a file extension.
    ModuleBuilder^ sampleModuleBuilder =
        sampleAssemblyBuilder->DefineDynamicModule(asmName->Name,
        asmName->Name + ".dll");

    TypeBuilder^ sampleTypeBuilder =
        sampleModuleBuilder->DefineType("SampleType",
        TypeAttributes::Public | TypeAttributes::Abstract);

    //<Snippet4>
    // Define a Shared, Public method with standard calling
    // conventions. Do not specify the parameter types or the
    // return type, because type parameters will be used for
    // those types, and the type parameters have not been
    // defined yet.
    MethodBuilder^ sampleMethodBuilder =
        sampleTypeBuilder->DefineMethod("SampleMethod",
        MethodAttributes::Public | MethodAttributes::Static);
    //</Snippet4>

    //<Snippet3>
    // Defining generic parameters for the method makes it a
    // generic method. By convention, type parameters are
    // single alphabetic characters. T and U are used here.
    //
    array<String^>^ genericTypeNames = {"T", "U"};
    array<GenericTypeParameterBuilder^>^ genericTypes =
        sampleMethodBuilder->DefineGenericParameters(
        genericTypeNames);
    //</Snippet3>

    //<Snippet7>
    // Use the IsGenericMethod property to find out if a
    // dynamic method is generic, and IsGenericMethodDefinition
    // to find out if it defines a generic method.
    Console::WriteLine("Is SampleMethod generic? {0}",
        sampleMethodBuilder->IsGenericMethod);
    Console::WriteLine(
        "Is SampleMethod a generic method definition? {0}",
        sampleMethodBuilder->IsGenericMethodDefinition);
    //</Snippet7>

    //<Snippet5>
    // Set parameter types for the method. The method takes
    // one parameter, and its type is specified by the first
    // type parameter, T.
    array<Type^>^ parameterTypes = {genericTypes[0]};
    sampleMethodBuilder->SetParameters(parameterTypes);

    // Set the return type for the method. The return type is
    // specified by the second type parameter, U.
    sampleMethodBuilder->SetReturnType(genericTypes[1]);
    //</Snippet5>

    // Generate a code body for the method. The method doesn't
    // do anything except return null.
    //
    ILGenerator^ ilgen = sampleMethodBuilder->GetILGenerator();
    ilgen->Emit(OpCodes::Ldnull);
    ilgen->Emit(OpCodes::Ret);

    //<Snippet6>
    // Complete the type.
    Type^ sampleType = sampleTypeBuilder->CreateType();

    // To bind types to a dynamic generic method, you must
    // first call the GetMethod method on the completed type.
    // You can then define an array of types, and bind them
    // to the method.
    MethodInfo^ sampleMethodInfo = sampleType->GetMethod("SampleMethod");
    array<Type^>^ boundParameters =
        {String::typeid, GenericReflectionSample::typeid};
    MethodInfo^ boundMethodInfo =
        sampleMethodInfo->MakeGenericMethod(boundParameters);
    // Display a string representing the bound method.
    Console::WriteLine(boundMethodInfo);
    //</Snippet6>

    // Save the assembly, so it can be examined with Ildasm.exe.
    sampleAssemblyBuilder->Save(asmName->Name + ".dll");
}

/* This code example produces the following output:
Is SampleMethod generic? True
Is SampleMethod a generic method definition? True
GenericReflectionSample SampleMethod[String,GenericReflectionSample](System.String)
*/
//</Snippet1>



