//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Security;

void main()
{
    // Create a CustomAttributeBuilder for the assembly attribute. 
    // 
    // SecurityTransparentAttribute has a parameterless constructor, 
    // which is retrieved by passing an array of empty types for the
    // constructor's parameter types. The CustomAttributeBuilder is 
    // then created by passing the ConstructorInfo and an empty array
    // of objects to represent the parameters.
    //
    ConstructorInfo^ transparentCtor = 
        SecurityTransparentAttribute::typeid->GetConstructor(
            Type::EmptyTypes);
    CustomAttributeBuilder^ transparent = gcnew CustomAttributeBuilder(
        transparentCtor,
        gcnew array<Object^> {} );
      
    // Create a dynamic assembly using the attribute. The attribute is
    // passed as an array with one element.
    AssemblyName^ aName = gcnew AssemblyName("EmittedAssembly");
    AssemblyBuilder^ ab = AppDomain::CurrentDomain->DefineDynamicAssembly( 
        aName, 
        AssemblyBuilderAccess::Run,
        gcnew array<CustomAttributeBuilder^> { transparent } );

    ModuleBuilder^ mb = ab->DefineDynamicModule( aName->Name );
    TypeBuilder^ tb = mb->DefineType( 
        "MyDynamicType", 
        TypeAttributes::Public );
    tb->CreateType();

    Console::WriteLine("{0}\nAssembly attributes:", ab);
    for each (Attribute^ attr in ab->GetCustomAttributes(true))
    {
        Console::WriteLine("\t{0}", attr);
    }
};

/* This code example produces the following output:

EmittedAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
Assembly attributes:
        System.Security.SecurityTransparentAttribute
 */
//</Snippet1>
