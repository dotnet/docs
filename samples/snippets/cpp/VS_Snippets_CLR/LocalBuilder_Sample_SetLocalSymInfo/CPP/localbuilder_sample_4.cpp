
// System.Reflection.Emit.LocalBuilder
// System.Reflection.Emit.ILGenerator.DeclareLocal(Type)
// System.Reflection.Emit.LocalBuilder.SetLocalSymInfo(String)
// System.Reflection.Emit.LocalBuilder.LocalType()
// System.Reflection.Emit.LocalBuilder.SetLocalSymInfo(String, Int32, Int32)
/*

This program demonstrates 'LocalType' property, 'SetLocalSymInfo(String)',
'SetLocalSymInfo(String, Int32,Int32)' methods, class level for 'LocalBuilder' and
'DeclareLocal(Type)' method of ILGenerator class. An assembly 'myClass' is created using
AssemblyBuilder, ModuleBuilder, FieldBuilder, TypeBuilder, ConstructorBuilder classes.
Localbuilder class is used to create local variables of the specified type.

*/
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Threading;
int main()
{
    // Create an assembly.
    AssemblyName^ myAssemblyName = gcnew AssemblyName;
    myAssemblyName->Name = "SampleAssembly";
    AssemblyBuilder^ myAssembly = Thread::GetDomain()->DefineDynamicAssembly( 
        myAssemblyName, AssemblyBuilderAccess::RunAndSave );

    // Create a module. For a single-file assembly the module
    // name is usually the same as the assembly name.
    ModuleBuilder^ myModule = myAssembly->DefineDynamicModule( 
        myAssemblyName->Name, myAssemblyName->Name + ".dll", true );

    // Define a public class 'Example'.
    TypeBuilder^ myTypeBuilder = myModule->DefineType( "Example", TypeAttributes::Public );

    // Create the 'Function1' public method, which takes an integer
    // and returns a string.
    MethodBuilder^ myMethod = myTypeBuilder->DefineMethod( "Function1", 
        MethodAttributes::Public | MethodAttributes::Static, String::typeid, 
        gcnew array<Type^> { int::typeid } );

    // Generate IL for 'Function1'. The function body demonstrates
    // assigning an argument to a local variable, assigning a 
    // constant string to a local variable, and putting the contents
    // of local variables on the stack.
    ILGenerator^ myMethodIL = myMethod->GetILGenerator();

    // <Snippet2>
    // Create local variables named myString and myInt.
    LocalBuilder^ myLB1 = myMethodIL->DeclareLocal( String::typeid );
    myLB1->SetLocalSymInfo( "myString" );
    Console::WriteLine( "local 'myString' type is: {0}", myLB1->LocalType );

    LocalBuilder^ myLB2 = myMethodIL->DeclareLocal( int::typeid );
    myLB2->SetLocalSymInfo( "myInt", 1, 2 );
    Console::WriteLine( "local 'myInt' type is: {0}", myLB2->LocalType );
    // </Snippet2>

    // Store the function argument in myInt.
    myMethodIL->Emit( OpCodes::Ldarg_0 );
    myMethodIL->Emit( OpCodes::Stloc_1 );

    // Store a literal value in myString, and return the value.
    myMethodIL->Emit( OpCodes::Ldstr, "string value"  );
    myMethodIL->Emit( OpCodes::Stloc_0 );
    myMethodIL->Emit( OpCodes::Ldloc_0 );
    myMethodIL->Emit( OpCodes::Ret );

    // Create "Example" class.
    Type^ myType1 = myTypeBuilder->CreateType();
    Console::WriteLine( "'Example' is created." );

    myAssembly->Save(myAssemblyName->Name + ".dll");
    Console::WriteLine( "'{0}' is created.", myAssemblyName->Name + ".dll" );

    // Invoke 'Function1' method of 'Example', passing the value 42.
    Object^ myObject2 = myType1->InvokeMember( "Function1", 
        BindingFlags::InvokeMethod, nullptr, nullptr, 
        gcnew array<Object^> { 42 } );

    Console::WriteLine( "Example::Function1 returned: {0}", myObject2 );
}
/* This code example produces the following output:

local 'myString' type is: System.String
local 'myInt' type is: System.Int32
'Example' is created.
'SampleAssembly.dll' is created.
Example::Function1 returned: string value
 */
// </Snippet1>
