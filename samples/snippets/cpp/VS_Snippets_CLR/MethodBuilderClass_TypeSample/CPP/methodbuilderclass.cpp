
// System.Reflection.Emit.MethodBuilder
/*
This program demonstrates 'MethodBuilder' class. A dynamic class 'myTypeBuilder'
is created in which a constructor 'myConstructorBuilder' and a method 'myMethodBuilder'
are created dynamically. Their IL's are generated. The Non-Public methods of the class
are printed on the console. The attributes and signature of 'MyDynamicMethod' are displayed
on the console using 'Attributes' and 'Signature' properties of the 'MethodBuilder' class.
*/
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
int main()
{
   try
   {
      // Get the current AppDomain.
      AppDomain^ myAppDomain = AppDomain::CurrentDomain;
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "MyDynamicAssembly";

      // Create the dynamic assembly and set its access mode to 'Save'.
      AssemblyBuilder^ myAssemblyBuilder = myAppDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Save );

      // Create a dynamic module 'myModuleBuilder'.
      ModuleBuilder^ myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "MyDynamicModule", true );

      // Define a public class 'MyDynamicClass'.
      TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "MyDynamicClass", TypeAttributes::Public );

      // Define a public string field named 'myField'.
      FieldBuilder^ myField = myTypeBuilder->DefineField( "MyDynamicField", String::typeid, FieldAttributes::Public );

      // Define the dynamic method 'MyDynamicMethod'.
      array<Type^>^temp0 = gcnew array<Type^>(0);
      MethodBuilder^ myMethodBuilder = myTypeBuilder->DefineMethod( "MyDynamicMethod", MethodAttributes::Private, int::typeid, temp0 );

      // Generate the IL for 'myMethodBuilder'.
      ILGenerator^ myMethodIL = myMethodBuilder->GetILGenerator();

      // Emit the necessary opcodes.
      myMethodIL->Emit( OpCodes::Ldarg_0 );
      myMethodIL->Emit( OpCodes::Ldfld, myField );
      myMethodIL->Emit( OpCodes::Ret );

      // Create 'myTypeBuilder' class.
      Type^ myType1 = myTypeBuilder->CreateType();

      // Get the method information of 'myTypeBuilder'.
      array<MethodInfo^>^myInfo = myType1->GetMethods( static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance) );

      // Print non-public methods present of 'myType1'.
      Console::WriteLine( "\nThe Non-Public methods present in 'myType1' are:\n" );
      for ( int i = 0; i < myInfo->Length; i++ )
      {
         Console::WriteLine( myInfo[ i ]->Name );
      }
      Console::WriteLine( "\nThe Attribute of 'MyDynamicMethod' is :{0}", myMethodBuilder->Attributes );
      Console::WriteLine( "\nThe Signature of 'MyDynamicMethod' is : \n{0}", myMethodBuilder->Signature );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception :{0}", e->Message );
   }
}
// </Snippet1>
