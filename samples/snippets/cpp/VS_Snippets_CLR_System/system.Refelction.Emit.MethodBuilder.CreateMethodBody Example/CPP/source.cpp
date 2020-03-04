
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
class MethodBodyDemo
{
public:

   // This class will demonstrate how to create a method body using
   // the MethodBuilder::CreateMethodBody(Byte[], int) method.
   static Type^ BuildDynType()
   {
      Type^ addType = nullptr;
      AppDomain^ currentDom = Thread::GetDomain();
      AssemblyName^ myAsmName = gcnew AssemblyName;
      myAsmName->Name = "MyDynamicAssembly";
      AssemblyBuilder^ myAsmBldr = currentDom->DefineDynamicAssembly( myAsmName, AssemblyBuilderAccess::RunAndSave );
      
      // The dynamic assembly space has been created.  Next, create a module
      // within it.  The type Point will be reflected into this module.
      ModuleBuilder^ myModuleBldr = myAsmBldr->DefineDynamicModule( "MyModule" );
      TypeBuilder^ myTypeBldr = myModuleBldr->DefineType( "Adder" );
      array<Type^>^temp0 = {int::typeid,int::typeid};
      MethodBuilder^ myMthdBldr = myTypeBldr->DefineMethod( "DoAdd", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Static), int::typeid, temp0 );
      
      // Build the array of Bytes holding the MSIL instructions.
      
      /* 02h is the opcode for ldarg.0 */
      /* 03h is the opcode for ldarg.1 */
      /* 58h is the opcode for add     */
      /* 2Ah is the opcode for ret     */
      array<Byte>^temp1 = {0x02,0x03,0x58,0x2A};
      array<Byte>^ILcodes = temp1;
      myMthdBldr->CreateMethodBody( ILcodes, ILcodes->Length );
      addType = myTypeBldr->CreateType();
      return addType;
   }

};

int main()
{
   Type^ myType = MethodBodyDemo::BuildDynType();
   Console::WriteLine( "---" );
   Console::Write( "Enter the first integer to add: " );
   int aVal = Convert::ToInt32( Console::ReadLine() );
   Console::Write( "Enter the second integer to add: " );
   int bVal = Convert::ToInt32( Console::ReadLine() );
   Object^ adderInst = Activator::CreateInstance( myType, gcnew array<Object^>(0) );
   array<Object^>^temp1 = {aVal,bVal};
   Console::WriteLine( "The value of adding {0} to {1} is: {2}.", aVal, bVal, myType->InvokeMember( "DoAdd", BindingFlags::InvokeMethod, nullptr, adderInst, temp1 ) );
}

// </Snippet1>
