
// System.Reflection.Emit.ILGenerator
// System.Reflection.Emit.ILGenerator.BeginScope()
// System.Reflection.Emit.ILGenerator.EndScope()
/*
This program demonstrates the 'BeginScope()', 'EndScope()' methods and the class
'ILGenerator'. A dynamic class 'myTypeBuilder' is created in which a
constructor 'myConstructor' and a method 'myMethod' are created dynamically. Their IL's
are generated. A local variable 'myLocalBuilder' is declared using 'DeclareLocal' property
of 'myMethodIL'. The scope of 'myLocalBuilder' is specified using 'BeginScope' and
'EndScope' methods. Respective messages related to scope are printed on the console. 
*/
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

int main()
{
   try
   {
      // <Snippet2>
      // <Snippet3>
      // Get the current AppDomain.
      AppDomain^ myAppDomain = AppDomain::CurrentDomain;
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "SampleAssembly";

      // Create a dynamic assembly 'myAssembly' with access mode 'Run'.
      AssemblyBuilder^ myAssembly = myAppDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );

      // Create a dynamic module 'myModule' in 'myAssembly'.
      ModuleBuilder^ myModule = myAssembly->DefineDynamicModule( "MyDynamicModule", true );

      // Define a public class 'MyDynamicClass'.
      TypeBuilder^ myTypeBuilder = myModule->DefineType( "MyDynamicClass", TypeAttributes::Public );

      // Define a public string field.
      FieldBuilder^ myField = myTypeBuilder->DefineField( "MyDynamicField", String::typeid, FieldAttributes::Public );

      // Create the constructor.
      array<Type^>^myConstructorArgs = {String::typeid};
      ConstructorBuilder^ myConstructor = myTypeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, myConstructorArgs );

      // Generate IL for 'myConstructor'.
      ILGenerator^ myConstructorIL = myConstructor->GetILGenerator();

      // Emit the necessary opcodes.
      myConstructorIL->Emit( OpCodes::Ldarg_0 );
      ConstructorInfo^ mySuperConstructor = Object::typeid->GetConstructor( gcnew array<Type^>(0) );
      myConstructorIL->Emit( OpCodes::Call, mySuperConstructor );
      myConstructorIL->Emit( OpCodes::Ldarg_0 );
      myConstructorIL->Emit( OpCodes::Ldarg_1 );
      myConstructorIL->Emit( OpCodes::Stfld, myField );
      myConstructorIL->Emit( OpCodes::Ret );

      // Define a dynamic method named 'MyDynamicMethod'.
      MethodBuilder^ myMethod = myTypeBuilder->DefineMethod( "MyDynamicMethod", MethodAttributes::Public, String::typeid, nullptr );

      // Generate IL for 'myMethod'.
      ILGenerator^ myMethodIL = myMethod->GetILGenerator();

      // Begin the scope for a local variable.
      myMethodIL->BeginScope();
      LocalBuilder^ myLocalBuilder = myMethodIL->DeclareLocal( int::typeid );
      Console::WriteLine( "\nTrying to access the local variable within the scope." );
      Console::WriteLine( "'myLocalBuilder' type is :{0}", myLocalBuilder->LocalType );
      myMethodIL->Emit( OpCodes::Ldstr, "Local value" );
      myMethodIL->Emit( OpCodes::Stloc_0, myLocalBuilder );

      // End the scope of 'myLocalBuilder'.
      myMethodIL->EndScope();

      // Access the local variable outside the scope.
      Console::WriteLine( "\nTrying to access the local variable outside the scope:\n" );
      myMethodIL->Emit( OpCodes::Stloc_0, myLocalBuilder );
      myMethodIL->Emit( OpCodes::Ldloc_0 );
      myMethodIL->Emit( OpCodes::Ret );

      // Create 'MyDynamicClass' class.
      Type^ myType1 = myTypeBuilder->CreateType();
      // </Snippet3>
      // </Snippet2>

      // Create an instance of the 'MyDynamicClass'.
      array<Object^>^temp0 = {"HelloWorld"};
      Object^ myObject1 = Activator::CreateInstance( myType1, temp0 );

      // Invoke 'MyDynamicMethod' method of 'MyDynamicClass'.
      Object^ myObject2 = myType1->InvokeMember( "MyDynamicMethod", BindingFlags::InvokeMethod, nullptr, myObject1, nullptr );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception :{0}", e->Message );
   }
}
// </Snippet1>
