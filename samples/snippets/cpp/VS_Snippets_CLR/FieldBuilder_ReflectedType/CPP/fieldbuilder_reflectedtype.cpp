
// System::Reflection::Emit::FieldBuilder.ReflectedType
// System::Reflection::Emit::FieldBuilder.Attributes
/*
   The following example demonstrates 'ReflectedType' and 'Attributes'
   properties of 'FieldBuilder' class.A new class 'MyClass' is created.
   A  Field and a method are defined in the class.In the constructor of the class
   the field is initialized.Method of the class gets the value of the Field.
   An instance of the class is created and method is invoked.
*/
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
Type^ CreateType( AppDomain^ currentDomain )
{
   // Create an assembly.
   AssemblyName^ myAssemblyName = gcnew AssemblyName;
   myAssemblyName->Name = "DynamicAssembly";
   AssemblyBuilder^ myAssembly = currentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );

   // Create a dynamic module in Dynamic Assembly.
   ModuleBuilder^ myModuleBuilder = myAssembly->DefineDynamicModule( "MyModule" );

   // Define a public class named S"MyClass" in the assembly.
   TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "MyClass", TypeAttributes::Public );

   // Define a private String field named S"MyField" in the type.
   FieldBuilder^ myFieldBuilder = myTypeBuilder->DefineField( "MyField", String::typeid, static_cast<FieldAttributes>(FieldAttributes::Private | FieldAttributes::Static) );

   // Create the constructor.
   array<Type^>^constructorArgs = {String::typeid};
   ConstructorBuilder^ myConstructor = myTypeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, constructorArgs );
   ILGenerator^ constructorIL = myConstructor->GetILGenerator();
   constructorIL->Emit( OpCodes::Ldarg_0 );
   ConstructorInfo^ superConstructor = Object::typeid->GetConstructor( gcnew array<Type^>(0) );
   constructorIL->Emit( OpCodes::Call, superConstructor );
   constructorIL->Emit( OpCodes::Ldarg_0 );
   constructorIL->Emit( OpCodes::Ldarg_1 );
   constructorIL->Emit( OpCodes::Stfld, myFieldBuilder );
   constructorIL->Emit( OpCodes::Ret );

   // Create the MyMethod method.
   MethodBuilder^ myMethodBuilder = myTypeBuilder->DefineMethod( "MyMethod", MethodAttributes::Public, String::typeid, nullptr );
   ILGenerator^ methodIL = myMethodBuilder->GetILGenerator();
   methodIL->Emit( OpCodes::Ldarg_0 );
   methodIL->Emit( OpCodes::Ldfld, myFieldBuilder );
   methodIL->Emit( OpCodes::Ret );
   if ( myFieldBuilder->Attributes.Equals( FieldAttributes::Static ) )
   {
      Console::WriteLine( "Field attribute defined as Static" );
   }
   else
   if ( myFieldBuilder->Attributes.Equals( FieldAttributes::Static | FieldAttributes::Private ) )
   {
      Console::WriteLine( "Field attributes are Static and Private" );
   }


   Console::WriteLine( "ReflectedType of Field is : {0}", myFieldBuilder->ReflectedType );
   return myTypeBuilder->CreateType();
}

int main()
{
   try
   {
      Type^ myType = CreateType( Thread::GetDomain() );

      // Create an instance of the S"HelloWorld" class.
      array<Object^>^type = {"HelloWorld"};
      Object^ helloWorld = Activator::CreateInstance( myType, type );

      // Invoke the S"MyMethod"  of the S"MyClass".
      Object^ myObject = myType->InvokeMember( "MyMethod", BindingFlags::InvokeMethod, nullptr, helloWorld, nullptr );
      Console::WriteLine( "MyClass::MyMethod returned: \"{0}\"", myObject );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception Caught {0}", e->Message );
   }
}
// </Snippet1>
