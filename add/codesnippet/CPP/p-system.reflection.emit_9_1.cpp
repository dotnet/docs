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
   ConstructorBuilder^ constructor = myTypeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, constructorArgs );
   ILGenerator^ constructorIL = constructor->GetILGenerator();
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
   Console::WriteLine( "Name               : {0}", myFieldBuilder->Name );
   Console::WriteLine( "DeclaringType      : {0}", myFieldBuilder->DeclaringType );
   Console::WriteLine( "Type               : {0}", myFieldBuilder->FieldType );
   Console::WriteLine( "Token              : {0}", myFieldBuilder->GetToken().Token );
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

      // Invoke the S"MyMethod" method of the S"MyClass" class.
      Object^ myObject = myType->InvokeMember( "MyMethod", BindingFlags::InvokeMethod, nullptr, helloWorld, nullptr );
      Console::WriteLine( "MyClass::MyMethod returned: \"{0}\"", myObject );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception Caught {0}", e->Message );
   }
}