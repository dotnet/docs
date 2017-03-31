// System.Reflection.Emit.TypeBuilder.DefineField()
// System.Reflection.Emit.TypeBuilder.DefineConstructor()
// System.Reflection.Emit.TypeBuilder.AddInterfaceImplementation()
// System.Reflection.Emit.TypeBuilder.BaseType

/* The following program demonstrates the property 'BaseType' and methods 
   'DefineField','DefineConstructor','AddInterfaceImplementation' of the
   class 'TypeBuilder'. 
   The program creates a dynamic assembly and a type within it called as 
   'HelloWorld' This defines a field and implements an interface.
*/

using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Threading;

// Declare the interface.
interface class IHello
{
   void SayHello();
};

// Create the transient dynamic assembly.
Type^ CreateDynamicAssembly( AppDomain^ myAppDomain, AssemblyBuilderAccess myAccess )
{
   // Create a simple name for assembly.
   AssemblyName^ myAssemblyName = gcnew AssemblyName;
   myAssemblyName->Name = "EmittedAssembly";
   // Create the dynamic assembly.
   AssemblyBuilder^ myAssemblyBuilder = myAppDomain->DefineDynamicAssembly( myAssemblyName, myAccess );
   // Create a dynamic module named 'CalleeModule' in the assembly.
   ModuleBuilder^ myModuleBuilder;
   myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "EmittedModule",
      "EmittedModule.mod" );
// <Snippet1>
// <Snippet4>
   // Define a public class named 'myHelloWorld' in the assembly.
   TypeBuilder^ helloWorldTypeBuilder =
      myModuleBuilder->DefineType( "HelloWorld", TypeAttributes::Public );
   
   // Get base type.
   Console::WriteLine( "Base Type :{0}", helloWorldTypeBuilder->BaseType->Name );
// </Snippet4>

   // Define 'myGreetingField' field.
   FieldBuilder^ myGreetingField =
      helloWorldTypeBuilder->DefineField( "myGreeting", String::typeid,
         FieldAttributes::Public );
// </Snippet1>

// <Snippet2>
   // Define the constructor.
   array<Type^>^ constructorArgs = {String::typeid};
   ConstructorBuilder^ myConstructorBuilder =
      helloWorldTypeBuilder->DefineConstructor( MethodAttributes::Public,
         CallingConventions::Standard, constructorArgs );
   // Generate IL for the method.The constructor stores its argument in the private field.
   ILGenerator^ myConstructorIL = myConstructorBuilder->GetILGenerator();
   myConstructorIL->Emit( OpCodes::Ldarg_0 );
   myConstructorIL->Emit( OpCodes::Ldarg_1 );
   myConstructorIL->Emit( OpCodes::Stfld, myGreetingField );
   myConstructorIL->Emit( OpCodes::Ret );
// </Snippet2>

// <Snippet3>
   // Mark the class as implementing 'IHello' interface.
   helloWorldTypeBuilder->AddInterfaceImplementation( IHello::typeid );
   MethodBuilder^ myMethodBuilder =
      helloWorldTypeBuilder->DefineMethod( "SayHello",
         (MethodAttributes)(MethodAttributes::Public | MethodAttributes::Virtual),
         nullptr,
         nullptr );
   // Generate IL for 'SayHello' method.
   ILGenerator^ myMethodIL = myMethodBuilder->GetILGenerator();
   myMethodIL->EmitWriteLine( myGreetingField );
   myMethodIL->Emit( OpCodes::Ret );
   MethodInfo^ sayHelloMethod = IHello::typeid->GetMethod( "SayHello" );
   helloWorldTypeBuilder->DefineMethodOverride( myMethodBuilder, sayHelloMethod );
// </Snippet3>
   return (helloWorldTypeBuilder->CreateType());
}

int main()
{
   Console::WriteLine( "TypeBuilder Sample" );
   Console::WriteLine( "----------------------" );

   // Create 'helloWorldType' .
   Type^ helloWorldType = CreateDynamicAssembly( Thread::GetDomain(), AssemblyBuilderAccess::RunAndSave );
   
   // Create an instance of 'HelloWorld' class.
   array<Object^>^ temp0 = {"Called HelloWorld"};
   Object^ helloWorld = Activator::CreateInstance( helloWorldType, temp0 );
   
   // Invoke 'SayHello' method.
   helloWorldType->InvokeMember( "SayHello", static_cast<BindingFlags>(BindingFlags::Default | BindingFlags::InvokeMethod), nullptr, helloWorld, nullptr );
   
   // Get defined field in the class.
   Console::WriteLine( "Defined Field :{0}", helloWorldType->GetField( "myGreeting" )->Name );
   AssemblyBuilder^ myAssemblyBuilder = dynamic_cast<AssemblyBuilder^>(helloWorldType->Assembly);
   myAssemblyBuilder->Save( "EmittedAssembly.dll" );
}
