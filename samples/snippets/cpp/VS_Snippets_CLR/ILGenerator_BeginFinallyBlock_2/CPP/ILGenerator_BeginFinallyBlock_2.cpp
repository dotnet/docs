
// System::Reflection::Emit::ILGenerator.BeginExceptFilterBlock()
// System::Reflection::Emit::ILGenerator.BeginFinallyBlock()
/*
   The following program demonstrates the 'BeginExceptFilterBlock()' method and
   'BeginFinallyBlock()' of 'ILGenerator' class. Exception is raised by passing
   two integer values which are out of range, the same is caught in the
   'BeginExceptionBlock' which is non-filtered and then emits the MSIL
   instructions in 'BeginExceptFilterBlock' and 'BeginFinallyBlock'.
*/
// <Snippet1>
// <Snippet2>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class ILGenerator_BeginFinallyBlock
{
public:
   static Type^ AddType()
   {
      // Create an assembly.
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "AdderExceptionAsm";

      // Create dynamic assembly.
      AppDomain^ myAppDomain = Thread::GetDomain();
      AssemblyBuilder^ myAssemblyBuilder = myAppDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );

      // Create a dynamic module.
      ModuleBuilder^ myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "AdderExceptionMod" );
      TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "Adder" );
      array<Type^>^adderParams = {int::typeid,int::typeid};

      // Define method to add two numbers.
      MethodBuilder^ myMethodBuilder = myTypeBuilder->DefineMethod( "DoAdd", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Static), int::typeid, adderParams );
      ILGenerator^ myAdderIL = myMethodBuilder->GetILGenerator();

      // Create constructor.
      array<Type^>^type1 = {String::typeid};
      ConstructorInfo^ myConstructorInfo = OverflowException::typeid->GetConstructor( type1 );
      MethodInfo^ myExToStrMI = OverflowException::typeid->GetMethod( "ToString" );
      array<Type^>^type2 = {String::typeid,Object::typeid};
      MethodInfo^ myWriteLineMI = Console::typeid->GetMethod( "WriteLine", type2 );

      // Declare local variable.
      LocalBuilder^ myLocalBuilder1 = myAdderIL->DeclareLocal( int::typeid );
      LocalBuilder^ myLocalBuilder2 = myAdderIL->DeclareLocal( OverflowException::typeid );

      // Define label.
      Label myFailedLabel = myAdderIL->DefineLabel();
      Label myEndOfMethodLabel = myAdderIL->DefineLabel();

      // Begin exception block.
      Label myLabel = myAdderIL->BeginExceptionBlock();
      myAdderIL->Emit( OpCodes::Ldarg_0 );
      myAdderIL->Emit( OpCodes::Ldc_I4_S, 10 );
      myAdderIL->Emit( OpCodes::Bgt_S, myFailedLabel );
      myAdderIL->Emit( OpCodes::Ldarg_1 );
      myAdderIL->Emit( OpCodes::Ldc_I4_S, 10 );
      myAdderIL->Emit( OpCodes::Bgt_S, myFailedLabel );
      myAdderIL->Emit( OpCodes::Ldarg_0 );
      myAdderIL->Emit( OpCodes::Ldarg_1 );
      myAdderIL->Emit( OpCodes::Add_Ovf_Un );
      myAdderIL->Emit( OpCodes::Stloc_S, myLocalBuilder1 );
      myAdderIL->Emit( OpCodes::Br_S, myEndOfMethodLabel );
      myAdderIL->MarkLabel( myFailedLabel );
      myAdderIL->Emit( OpCodes::Ldstr, "Cannot accept values over 10 for add." );
      myAdderIL->Emit( OpCodes::Newobj, myConstructorInfo );
      myAdderIL->Emit( OpCodes::Stloc_S, myLocalBuilder2 );
      myAdderIL->Emit( OpCodes::Ldloc_S, myLocalBuilder2 );

      // Throw the exception.
      myAdderIL->ThrowException( OverflowException::typeid );

      // Call 'BeginExceptFilterBlock'.
      myAdderIL->BeginExceptFilterBlock();
      myAdderIL->EmitWriteLine( "Except filter block called." );

      // Call catch block.
      myAdderIL->BeginCatchBlock( nullptr );

      // Call other catch block.
      myAdderIL->BeginCatchBlock( OverflowException::typeid );
      myAdderIL->Emit( OpCodes::Ldstr, "{0}" );
      myAdderIL->Emit( OpCodes::Ldloc_S, myLocalBuilder2 );
      myAdderIL->EmitCall( OpCodes::Callvirt, myExToStrMI, nullptr );
      myAdderIL->EmitCall( OpCodes::Call, myWriteLineMI, nullptr );
      myAdderIL->Emit( OpCodes::Ldc_I4_M1 );
      myAdderIL->Emit( OpCodes::Stloc_S, myLocalBuilder1 );

      // Call finally block.
      myAdderIL->BeginFinallyBlock();
      myAdderIL->EmitWriteLine( "Finally block called." );

      // End the exception block.
      myAdderIL->EndExceptionBlock();
      myAdderIL->MarkLabel( myEndOfMethodLabel );
      myAdderIL->Emit( OpCodes::Ldloc_S, myLocalBuilder1 );
      myAdderIL->Emit( OpCodes::Ret );
      return myTypeBuilder->CreateType();
   }
};

int main()
{
   Type^ myAddType = ILGenerator_BeginFinallyBlock::AddType();
   Object^ myObject1 = Activator::CreateInstance( myAddType );
   array<Object^>^myObject2 = {15,15};
   myAddType->InvokeMember( "DoAdd", BindingFlags::InvokeMethod, nullptr, myObject1, myObject2 );
}
// </Snippet2>
// </Snippet1>
