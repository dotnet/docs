
// System.Reflection.Emit.ILGenerator.BeginFaultBlock()
/*
The following program demonstrates the 'BeginFaultBlock()' method of 'ILGenerator'
class. Exception is raised by passing two integer values which are out of range,
the same is caught in the 'BeginExceptionBlock' which is non-filtered. First it
checks for the exception thrown in the 'BeginFaultBlock' and then emits the MSIL
instructions in 'BeginExceptFilterBlock'. 
*/
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

Type^ AddType()
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
   array<Type^>^myAdderParams = {int::typeid,int::typeid};

   // Method to add two numbers.
   MethodBuilder^ myMethodBuilder = myTypeBuilder->DefineMethod( "DoAdd", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Static), int::typeid, myAdderParams );
   ILGenerator^ myAdderIL = myMethodBuilder->GetILGenerator();

   // Create constructor.
   array<Type^>^temp0 = {String::typeid};
   ConstructorInfo^ myConstructorInfo = OverflowException::typeid->GetConstructor( temp0 );
   MethodInfo^ myExToStrMI = OverflowException::typeid->GetMethod( "ToString" );
   array<Type^>^temp1 = {String::typeid,Object::typeid};
   MethodInfo^ myWriteLineMI = Console::typeid->GetMethod( "WriteLine", temp1 );

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
   myAdderIL->Emit( OpCodes::Ldstr, "Cannot accept values over 10 for addition." );
   myAdderIL->Emit( OpCodes::Newobj, myConstructorInfo );
   myAdderIL->Emit( OpCodes::Stloc_S, myLocalBuilder2 );
   myAdderIL->Emit( OpCodes::Ldloc_S, myLocalBuilder2 );

   // Call fault block.
   myAdderIL->BeginFaultBlock();
   Console::WriteLine( "Fault block called." );

   //Throw exception.
   myAdderIL->ThrowException( NotSupportedException::typeid );

   // Call finally block.
   myAdderIL->BeginFinallyBlock();
   myAdderIL->Emit( OpCodes::Ldstr, "{0}" );
   myAdderIL->Emit( OpCodes::Ldloc_S, myLocalBuilder2 );
   myAdderIL->EmitCall( OpCodes::Callvirt, myExToStrMI, nullptr );
   myAdderIL->EmitCall( OpCodes::Call, myWriteLineMI, nullptr );
   myAdderIL->Emit( OpCodes::Ldc_I4_M1 );
   myAdderIL->Emit( OpCodes::Stloc_S, myLocalBuilder1 );

   // End exception block.
   myAdderIL->EndExceptionBlock();
   myAdderIL->MarkLabel( myEndOfMethodLabel );
   myAdderIL->Emit( OpCodes::Ldloc_S, myLocalBuilder1 );
   myAdderIL->Emit( OpCodes::Ret );
   return myTypeBuilder->CreateType();
}

int main()
{
   Type^ myAddType = AddType();
   Object^ myObject1 = Activator::CreateInstance( myAddType );
   array<Object^>^myObject2 = {11,12};

   // Invoke member.
   myAddType->InvokeMember( "DoAdd", BindingFlags::InvokeMethod, nullptr, myObject1, myObject2 );
}
// </Snippet1>
