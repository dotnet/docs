//<Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

int main()
{
   AppDomain^ myDomain = Thread::GetDomain();
   AssemblyName^ myAsmName = gcnew AssemblyName;
   myAsmName->Name = "AdderExceptionAsm";
   AssemblyBuilder^ myAsmBldr = myDomain->DefineDynamicAssembly( myAsmName, 
      AssemblyBuilderAccess::RunAndSave );
   ModuleBuilder^ myModBldr = myAsmBldr->DefineDynamicModule( myAsmName->Name,
      myAsmName->Name + ".dll" );
   TypeBuilder^ myTypeBldr = myModBldr->DefineType( "Adder" );
   array<Type^>^adderParams = {int::typeid,int::typeid};
   
   // This method will add two numbers which are 100 or less. If either of the
   // passed integer vales are greater than 100, it will throw an exception.
   MethodBuilder^ adderBldr = myTypeBldr->DefineMethod( "DoAdd", 
      static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Static), 
      int::typeid, adderParams );
   ILGenerator^ adderIL = adderBldr->GetILGenerator();
   
   // Types and methods used in the code to throw, catch, and
   // display OverflowException. Note that if the catch block were
   // for a more general type, such as Exception, we would need 
   // a MethodInfo for that type's ToString method.
   // 
   Type^ overflow = OverflowException::typeid;
   ConstructorInfo^ exCtorInfo = overflow->GetConstructor( 
      gcnew array<Type^> { String::typeid });
   MethodInfo^ exToStrMI = overflow->GetMethod( "ToString" );
   MethodInfo^ writeLineMI = Console::typeid->GetMethod( "WriteLine", 
      gcnew array<Type^> { String::typeid, Object::typeid } );

   LocalBuilder^ tmp1 = adderIL->DeclareLocal( int::typeid );
   LocalBuilder^ tmp2 = adderIL->DeclareLocal( overflow );

   // In order to successfully branch, we need to create labels
   // representing the offset IL instruction block to branch to.
   // These labels, when the MarkLabel(Label) method is invoked,
   // will specify the IL instruction to branch to.
   //
   Label failed = adderIL->DefineLabel();
   Label endOfMthd = adderIL->DefineLabel();

   // Begin the try block.
   Label exBlock = adderIL->BeginExceptionBlock();
   
   // First, load argument 0 and the integer value of S"100" onto the
   // stack. If arg0 > 100, branch to the label S"failed", which is marked
   // as the address of the block that throws an exception.
   adderIL->Emit( OpCodes::Ldarg_0 );
   adderIL->Emit( OpCodes::Ldc_I4_S, 100 );
   adderIL->Emit( OpCodes::Bgt_S, failed );
   
   // Now, check to see if argument 1 was greater than 100. If it was,
   // branch to S"failed." Otherwise, fall through and perform the addition,
   // branching unconditionally to the instruction at the label S"endOfMthd".
   adderIL->Emit( OpCodes::Ldarg_1 );
   adderIL->Emit( OpCodes::Ldc_I4_S, 100 );
   adderIL->Emit( OpCodes::Bgt_S, failed );

   adderIL->Emit( OpCodes::Ldarg_0 );
   adderIL->Emit( OpCodes::Ldarg_1 );
   adderIL->Emit( OpCodes::Add_Ovf_Un );
   // Store the result of the addition.
   adderIL->Emit( OpCodes::Stloc_S, tmp1 );
   adderIL->Emit( OpCodes::Br_S, endOfMthd );
   
   // If one of the arguments was greater than 100, we need to throw an
   // exception. We'll use "OverflowException" with a customized message.
   // First, we load our message onto the stack, and then create a new
   // exception Object using the constructor overload that accepts a
   // String* message.
   adderIL->MarkLabel( failed );
   adderIL->Emit( OpCodes::Ldstr, "Cannot accept values over 100 for add." );
   adderIL->Emit( OpCodes::Newobj, exCtorInfo );
   
   // We're going to need to refer to that exception Object later, so let's
   // store it in a temporary variable. Since the store function pops the
   // the value/reference off the stack, and we'll need it to throw the
   // exception, we will subsequently load it back onto the stack as well.
   adderIL->Emit( OpCodes::Stloc_S, tmp2 );
   adderIL->Emit( OpCodes::Ldloc_S, tmp2 );
   
   // Throw the exception now on the stack.
   adderIL->ThrowException( overflow );
   
   // Start the catch block for OverflowException.
   //
   adderIL->BeginCatchBlock( overflow );
   
   // When we enter the catch block, the thrown exception 
   // is on the stack. Store it, then load the format string
   // for WriteLine. 
   //
   adderIL->Emit(OpCodes::Stloc_S, tmp2);
   adderIL->Emit(OpCodes::Ldstr, "Caught {0}");

   // Push the thrown exception back on the stack, then 
   // call its ToString() method. Note that if this catch block
   // were for a more general exception type, like Exception,
   // it would be necessary to use the ToString for that type.
   //
   adderIL->Emit(OpCodes::Ldloc_S, tmp2);
   adderIL->EmitCall(OpCodes::Callvirt, exToStrMI, nullptr);
      
   // The format string and the return value from ToString() are
   // now on the stack. Call WriteLine(string, object).
   //
   adderIL->EmitCall( OpCodes::Call, writeLineMI, nullptr );
   
   // Since our function has to return an integer value, we'll load -1 onto
   // the stack to indicate an error, and store it in local variable tmp1.
   adderIL->Emit( OpCodes::Ldc_I4_M1 );
   adderIL->Emit( OpCodes::Stloc_S, tmp1 );
   
   // End the exception handling block.
   adderIL->EndExceptionBlock();
   
   // The end of the method. If no exception was thrown, the correct value
   // will be saved in tmp1. If an exception was thrown, tmp1 will be equal
   // to -1. Either way, we'll load the value of tmp1 onto the stack and return.
   adderIL->MarkLabel( endOfMthd );
   adderIL->Emit( OpCodes::Ldloc_S, tmp1 );
   adderIL->Emit( OpCodes::Ret );

   Type^ adderType = myTypeBldr->CreateType();

   Object^ addIns = Activator::CreateInstance( adderType );

   array<Object^>^addParams = gcnew array<Object^>(2);

   Console::Write( "Enter an integer value: " );
   addParams[ 0 ] = Convert::ToInt32( Console::ReadLine() );

   Console::Write( "Enter another integer value: " );
   addParams[ 1 ] = Convert::ToInt32( Console::ReadLine() );

   Console::WriteLine( "If either integer was > 100, an exception will be thrown." );

   Console::WriteLine( "---" );
   Console::WriteLine( " {0} + {1} = {2}", addParams[ 0 ], addParams[ 1 ], adderType->InvokeMember( "DoAdd", BindingFlags::InvokeMethod, nullptr, addIns, addParams ) );
}

/* This code produces output similar to the following:

Enter an integer value: 24
Enter another integer value: 101
If either integer was > 100, an exception will be thrown.
---
Caught System.OverflowException: Arithmetic operation resulted in an overflow.
   at Adder.DoAdd(Int32 , Int32 )
 24 + 101 = -1
 */
//</Snippet1>
