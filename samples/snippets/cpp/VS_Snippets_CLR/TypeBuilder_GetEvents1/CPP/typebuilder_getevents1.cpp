
// System::Reflection::Emit::TypeBuilder.GetEvents(BindingFlags)
/*
The program demonstrates the 'GetEvents' method of the 'TypeBuilder' class.
It builds an assembly by defining 'HelloWorld' type and creates a 'Click' and
'MouseUp' events on the type. Then displays all events to the Console.
*/

// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

ref class MyApplication
{
private:
   delegate void MyEvent( Object^ temp );

public:

   // Create the callee transient dynamic assembly.
   static TypeBuilder^ CreateCallee( AppDomain^ myDomain )
   {
      AssemblyName^ assemblyName = gcnew AssemblyName;
      assemblyName->Name = "EmittedAssembly";
      
      // Create the callee dynamic assembly.
      AssemblyBuilder^ myAssembly = myDomain->DefineDynamicAssembly( assemblyName, AssemblyBuilderAccess::Run );
      
      // Create a dynamic module
      ModuleBuilder^ myModule = myAssembly->DefineDynamicModule( "EmittedModule" );
      
      // Define a public class named "HelloWorld" in the assembly.
      TypeBuilder^ helloWorldClass = myModule->DefineType( "HelloWorld", TypeAttributes::Public );
      array<Type^>^typeArray = gcnew array<Type^>(1);
      typeArray[ 0 ] = Object::typeid;
      MethodBuilder^ myMethod1 = helloWorldClass->DefineMethod( "OnClick", MethodAttributes::Public, void::typeid, typeArray );
      ILGenerator^ methodIL1 = myMethod1->GetILGenerator();
      methodIL1->Emit( OpCodes::Ret );
      MethodBuilder^ myMethod2 = helloWorldClass->DefineMethod( "OnMouseUp", MethodAttributes::Public, void::typeid, typeArray );
      ILGenerator^ methodIL2 = myMethod2->GetILGenerator();
      methodIL2->Emit( OpCodes::Ret );
      
      // Create the events.
      EventBuilder^ myEvent1 = helloWorldClass->DefineEvent( "Click", EventAttributes::None, MyEvent::typeid );
      myEvent1->SetRaiseMethod( myMethod1 );
      EventBuilder^ myEvent2 = helloWorldClass->DefineEvent( "MouseUp", EventAttributes::None, MyEvent::typeid );
      myEvent2->SetRaiseMethod( myMethod2 );
      helloWorldClass->CreateType();
      return (helloWorldClass);
   }
};

int main()
{
   TypeBuilder^ helloWorldClass = MyApplication::CreateCallee( Thread::GetDomain() );
   array<EventInfo^>^info = helloWorldClass->GetEvents( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance) );
   Console::WriteLine( "'HelloWorld' type has following events :" );
   for ( int i = 0; i < info->Length; i++ )
      Console::WriteLine( info[ i ]->Name );
   return 0;
}
// </Snippet1>
