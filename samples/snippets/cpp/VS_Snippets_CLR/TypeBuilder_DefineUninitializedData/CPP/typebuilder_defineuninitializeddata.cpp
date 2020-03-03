

// System::Reflection::Emit::TypeBuilder::DefineUninitializedData(string,int,FieldAttributes)
/*
The following program demonstrates the 'DefineUninitializedData'
method of 'TypeBuilder' class. It builds an assembly by defining 'MyHelloWorld' type and
it has 'MyGreeting' field. Then it displays the initial value of 'MyGreeting'
field to the console.
*/
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Runtime::InteropServices;
using namespace System::Security::Permissions;

public ref class Example
{
public:
   [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
   static void Main()
   {
      Type^ myHelloWorldType = CreateCallee( Thread::GetDomain() );
      Object^ myHelloWorldInstance = Activator::CreateInstance( myHelloWorldType );
      FieldInfo^ myGreetingFieldInfo = myHelloWorldType->GetField( "MyGreeting" );
      Object^ oval = Activator::CreateInstance( myGreetingFieldInfo->FieldType );
      IntPtr myIntPtr = Marshal::AllocHGlobal( 4 );
      Random^ rand = gcnew Random;
      int iTempSeed = rand->Next();
      array<Byte>^bINITBYTE = GetRandBytes( iTempSeed, 4 );
      IntPtr intptrTemp = myIntPtr;
      for ( int j = 0; j < 4; j++ )
      {
         Marshal::WriteByte( myIntPtr, bINITBYTE[ j ] );
         myIntPtr = (IntPtr)((int)myIntPtr + 1);

      }
      myIntPtr = intptrTemp;
      Object^ oValNew = Marshal::PtrToStructure( myIntPtr, myGreetingFieldInfo->FieldType );
      Marshal::FreeHGlobal( myIntPtr );
      myIntPtr = Marshal::AllocHGlobal( 4 );
      Object^ myObj = myGreetingFieldInfo->GetValue( myHelloWorldInstance );
      Marshal::StructureToPtr( myObj, myIntPtr, true );
      intptrTemp = myIntPtr;
      Console::WriteLine( "The value of 'MyGreeting' field : " );
      for ( int j = 0; j < 4; j++ )
      {
         Marshal::WriteByte( myIntPtr, bINITBYTE[ j ] );
         Console::WriteLine( bINITBYTE[ j ] );
         myIntPtr = (IntPtr)((int)myIntPtr + 1);

      }
   }


private:
   static array<Byte>^ GetRandBytes( int iRandSeed, int iSize )
   {
      array<Byte>^barr = gcnew array<Byte>(iSize);
      Random^ randTemp = gcnew Random( iRandSeed );
      randTemp->NextBytes( barr );
      return barr;
   }


   // Create the callee transient dynamic assembly.
   static Type^ CreateCallee( AppDomain^ myDomain )
   {
      
      // Create a simple name for the callee assembly.
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "EmittedClass";
      
      // Create the callee dynamic assembly.
      AssemblyBuilder^ myAssembly = myDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );
      
      // Create a dynamic module in the callee assembly.
      ModuleBuilder^ myModule = myAssembly->DefineDynamicModule( "EmittedModule" );
      
      // Define a public class named "MyHelloWorld"
      TypeBuilder^ myHelloWorldType = myModule->DefineType( "MyHelloWorld", TypeAttributes::Public );
      
      // Define a 'MyGreeting' field and initialize it.
      FieldBuilder^ myFieldBuilder = myHelloWorldType->DefineUninitializedData( "MyGreeting", 4, FieldAttributes::Public );
      
      // Create the 'MyHelloWorld' class.
      return (myHelloWorldType->CreateType());
   }

};

int main()
{
   Example::Main();
}

// </Snippet1>
