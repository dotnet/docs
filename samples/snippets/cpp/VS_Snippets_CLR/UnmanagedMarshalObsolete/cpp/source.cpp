// REDMOND\glennha
//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Runtime::InteropServices;

void main()
{
    AppDomain^ myDomain = AppDomain::CurrentDomain;
    AssemblyName^ myAsmName = gcnew AssemblyName("EmitMarshalAs");

    AssemblyBuilder^ myAssembly = 
        myDomain->DefineDynamicAssembly(myAsmName, 
            AssemblyBuilderAccess::RunAndSave);

    ModuleBuilder^ myModule = 
        myAssembly->DefineDynamicModule(myAsmName->Name, 
            myAsmName->Name + ".dll");
 
    TypeBuilder^ myType = 
        myModule->DefineType("Sample", TypeAttributes::Public);

    MethodBuilder^ myMethod = 
        myType->DefineMethod("Test", MethodAttributes::Public,
            nullptr, gcnew array<Type^> { String::typeid });


    // Get a parameter builder for the parameter that needs the 
    // attribute, using the HasFieldMarshal attribute. In this
    // example, the parameter is at position 0 and has the name
    // "arg".
    ParameterBuilder^ pb = 
        myMethod->DefineParameter(0, 
            ParameterAttributes::HasFieldMarshal, "arg");

    // Get the MarshalAsAttribute constructor that takes an
    // argument of type UnmanagedType.
    //
    //Type^ maattrType = MarshalAsAttribute::typeid;
    ConstructorInfo^ ci = 
        (MarshalAsAttribute::typeid)->GetConstructor(
            gcnew array<Type^> { UnmanagedType::typeid });

    // Create a CustomAttributeBuilder representing the attribute,
    // specifying the necessary unmanaged type. In this case, 
    // UnmanagedType.BStr is specified.
    //
    CustomAttributeBuilder^ cabuilder = 
        gcnew CustomAttributeBuilder(
            ci, gcnew array<Object^> { UnmanagedType::BStr });

    // Apply the attribute to the parameter.
    //
    pb->SetCustomAttribute(cabuilder);


    ILGenerator^ il = myMethod->GetILGenerator();
    il->Emit(OpCodes::Ret);

    Type^ finished = myType->CreateType();
    myAssembly->Save(myAsmName->Name + ".dll");
}
//</Snippet1>
