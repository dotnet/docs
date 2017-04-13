
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
Type^ BuildAdderType()
{
   AppDomain^ myDomain = Thread::GetDomain();
   AssemblyName^ myAsmName = gcnew AssemblyName;
   myAsmName->Name = "AdderExceptionAsm";
   AssemblyBuilder^ myAsmBldr = myDomain->DefineDynamicAssembly( myAsmName, AssemblyBuilderAccess::Run );
   ModuleBuilder^ myModBldr = myAsmBldr->DefineDynamicModule( "AdderExceptionMod" );
   TypeBuilder^ myTypeBldr = myModBldr->DefineType( "Adder" );
   array<Type^>^adderParams = {int::typeid,int::typeid};
   
   // This method will add two numbers which are 100 or less. If either of the
   // passed integer vales are greater than 100, it will return the value of -1.
   MethodBuilder^ adderBldr = myTypeBldr->DefineMethod( "DoAdd", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Static), int::typeid, adderParams );
   ILGenerator^ adderIL = adderBldr->GetILGenerator();
   
   // In order to successfully branch, we need to create labels
   // representing the offset IL instruction block to branch to.
   // These labels, when the MarkLabel(Label) method is invoked,
   // will specify the IL instruction to branch to.
   Label failed = adderIL->DefineLabel();
   Label endOfMthd = adderIL->DefineLabel();
   
   // First, load argument 0 and the integer value of "100" onto the
   // stack. If arg0 > 100, branch to the label "failed", which is marked
   // as the address of the block that loads -1 onto the stack, bypassing
   // the addition.
   adderIL->Emit( OpCodes::Ldarg_0 );
   adderIL->Emit( OpCodes::Ldc_I4_S, 100 );
   adderIL->Emit( OpCodes::Bgt_S, failed );
   
   // Now, check to see if argument 1 was greater than 100. If it was,
   // branch to "failed." Otherwise, fall through and perform the addition,
   // branching unconditionally to the instruction at the label "endOfMthd".
   adderIL->Emit( OpCodes::Ldarg_1 );
   adderIL->Emit( OpCodes::Ldc_I4_S, 100 );
   adderIL->Emit( OpCodes::Bgt_S, failed );
   adderIL->Emit( OpCodes::Ldarg_0 );
   adderIL->Emit( OpCodes::Ldarg_1 );
   adderIL->Emit( OpCodes::Add_Ovf_Un );
   adderIL->Emit( OpCodes::Br_S, endOfMthd );
   
   // If this label is branched to (the failure case), load -1 onto the stack
   // and fall through to the return opcode.
   adderIL->MarkLabel( failed );
   adderIL->Emit( OpCodes::Ldc_I4_M1 );
   
   // The end of the method. If both values were less than 100, the
   // correct result will return. If one of the arguments was greater
   // than 100, the result will be -1.
   adderIL->MarkLabel( endOfMthd );
   adderIL->Emit( OpCodes::Ret );
   return myTypeBldr->CreateType();
}

int main()
{
   Type^ adderType = BuildAdderType();
   Object^ addIns = Activator::CreateInstance( adderType );
   array<Object^>^addParams = gcnew array<Object^>(2);
   Console::Write( "Enter an integer value: " );
   addParams[ 0 ] = Convert::ToInt32( Console::ReadLine() );
   Console::Write( "Enter another integer value: " );
   addParams[ 1 ] = Convert::ToInt32( Console::ReadLine() );
   Console::WriteLine( "---" );
   int adderResult =  safe_cast<int>(adderType->InvokeMember( "DoAdd", BindingFlags::InvokeMethod, nullptr, addIns, addParams ));
   if ( adderResult != -1 )
   {
      Console::WriteLine( " {0} + {1} = {2}", addParams[ 0 ], addParams[ 1 ], adderResult );
   }
   else
   {
      Console::WriteLine( "One of the integers to add was greater than 100!" );
   }
}
// </Snippet1>
