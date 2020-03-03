
// System.Reflection.Emit.TypeBuilder.DefineNestedType(string, TypeAttributes, Type, Type[])
// System.Reflection.Emit.TypeBuilder.DefineMethodOverride(MethodInfo, MethodInfo)
// System.Reflection.Emit.TypeBuilder.DefineMethod(string, MethodAttributes,Type,Type[])
/*
The following program demonstrates the 'DefineNestedType', 'DefineMethodOverride' and
'DefineMethod' methods of 'TypeBuilder' class. It builds an assembly by defining
'MyHelloWorld' type. 'MyHelloWorld' class has a nested class 'MyNestedClass' which extends 
'EmittedClass' and implements 'IMyInterface' interface. Then it creates and instance of
'MyNestedClass' type and calls the 'HelloMethod' using 'IMyInterface' object and
results are displayed to the console.
*/
// <Snippet1>
// <Snippet2>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
public interface class IMyInterface
{
   String^ HelloMethod( String^ parameter );
};

public ref class EmittedClass
{
public:
   // Because this method calls Activator::CreateInstance, 
   // it requires full trust. 
   [System::Security::Permissions::PermissionSetAttribute
	(System::Security::Permissions::SecurityAction::Demand, Name = "FullTrust")]
   static void Main()
   {
      Type^ myNestedClassType = CreateCallee( Thread::GetDomain() );
      
      // Create an instance of 'MyNestedClass'.
      IMyInterface^ myInterface = dynamic_cast<IMyInterface^>(Activator::CreateInstance( myNestedClassType ));
      Console::WriteLine( myInterface->HelloMethod( "Bill" ) );
   }

private:

   // Create the callee transient dynamic assembly.
   static Type^ CreateCallee( AppDomain^ myAppDomain )
   {
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "EmittedClass";
      
      // Create the callee dynamic assembly.
      AssemblyBuilder^ myAssembly = myAppDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );
      
      // Create a dynamic module in the callee assembly.
      ModuleBuilder^ myModule = myAssembly->DefineDynamicModule( "EmittedModule" );
      
      // Define a public class named "MyHelloWorld".
      TypeBuilder^ myHelloWorldType = myModule->DefineType( "MyHelloWorld", TypeAttributes::Public );
      
      // Define a public nested class named 'MyNestedClass'.
      array<Type^>^temp0 = {IMyInterface::typeid};
      TypeBuilder^ myNestedClassType = myHelloWorldType->DefineNestedType( "MyNestedClass", TypeAttributes::NestedPublic, EmittedClass::typeid, temp0 );
      
      // Implement 'IMyInterface' interface.
      myNestedClassType->AddInterfaceImplementation( IMyInterface::typeid );
      
      // Define 'HelloMethod' of 'IMyInterface'.
      array<Type^>^temp1 = {String::typeid};
      MethodBuilder^ myHelloMethod = myNestedClassType->DefineMethod( "HelloMethod", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Virtual), String::typeid, temp1 );
      
      // Generate IL for 'GetGreeting' method.
      ILGenerator^ myMethodIL = myHelloMethod->GetILGenerator();
      myMethodIL->Emit( OpCodes::Ldstr, "Hi! " );
      myMethodIL->Emit( OpCodes::Ldarg_1 );
      array<Type^>^temp2 = {String::typeid,String::typeid};
      MethodInfo^ infoMethod = String::typeid->GetMethod( "Concat", temp2 );
      myMethodIL->Emit( OpCodes::Call, infoMethod );
      myMethodIL->Emit( OpCodes::Ret );
      MethodInfo^ myHelloMethodInfo = IMyInterface::typeid->GetMethod( "HelloMethod" );
      
      // Implement 'HelloMethod' of 'IMyInterface'.
      myNestedClassType->DefineMethodOverride( myHelloMethod, myHelloMethodInfo );
      
      // Create 'MyHelloWorld' type.
      Type^ myType = myHelloWorldType->CreateType();
      
      // Create 'MyNestedClass' type.
      return myNestedClassType->CreateType();
   }
};

int main()
{
   EmittedClass::Main();
}
// </Snippet2>
// </Snippet1>
