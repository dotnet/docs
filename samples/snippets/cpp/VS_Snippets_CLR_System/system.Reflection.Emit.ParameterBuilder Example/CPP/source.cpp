
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
Type^ BuildCustomerDataType()
{
   AppDomain^ myDomain = Thread::GetDomain();
   AssemblyName^ myAsmName = gcnew AssemblyName;
   myAsmName->Name = "MyDynamicAssembly";
   AssemblyBuilder^ myAsmBuilder = myDomain->DefineDynamicAssembly( myAsmName, AssemblyBuilderAccess::Run );
   ModuleBuilder^ myModBuilder = myAsmBuilder->DefineDynamicModule( "MyMod" );
   TypeBuilder^ myTypeBuilder = myModBuilder->DefineType( "CustomerData", TypeAttributes::Public );
   FieldBuilder^ customerNameBldr = myTypeBuilder->DefineField( "customerName", String::typeid, FieldAttributes::Private );
   FieldBuilder^ acctIDBldr = myTypeBuilder->DefineField( "acctID", String::typeid, FieldAttributes::Private );
   FieldBuilder^ balanceAmtBldr = myTypeBuilder->DefineField( "balanceAmt", double::typeid, FieldAttributes::Private );
   array<Type^>^temp0 = {String::typeid,String::typeid,double::typeid};
   ConstructorBuilder^ myCtorBuilder = myTypeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::HasThis, temp0 );
   ILGenerator^ ctorIL = myCtorBuilder->GetILGenerator();
   Type^ objType = Type::GetType( "System.Object" );
   ConstructorInfo^ objCtor = objType->GetConstructor( gcnew array<Type^>(0) );
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Call, objCtor );
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_1 );
   ctorIL->Emit( OpCodes::Stfld, customerNameBldr );
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_2 );
   ctorIL->Emit( OpCodes::Stfld, acctIDBldr );
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_3 );
   ctorIL->Emit( OpCodes::Stfld, balanceAmtBldr );
   ctorIL->Emit( OpCodes::Ret );
   
   // This method will take an amount from a static pool and add it to the balance.
   // Note that we are passing the first parameter, fundsPool, by reference. Therefore,
   // we need to inform the MethodBuilder to expect a ref, by declaring the first
   // parameter's type to be System::Double& (a reference to a double).
   array<Type^>^temp4 = {Type::GetType( "System.Double&" ),double::typeid};
   MethodBuilder^ myMthdBuilder = myTypeBuilder->DefineMethod( "AddFundsFromPool", MethodAttributes::Public, double::typeid, temp4 );
   ParameterBuilder^ poolRefBuilder = myMthdBuilder->DefineParameter( 1, ParameterAttributes::Out, "fundsPool" );
   ParameterBuilder^ amountFromPoolBuilder = myMthdBuilder->DefineParameter( 2, ParameterAttributes::In, "amountFromPool" );
   ILGenerator^ mthdIL = myMthdBuilder->GetILGenerator();
   mthdIL->Emit( OpCodes::Ldarg_1 );
   mthdIL->Emit( OpCodes::Ldarg_1 );
   mthdIL->Emit( OpCodes::Ldind_R8 );
   mthdIL->Emit( OpCodes::Ldarg_2 );
   mthdIL->Emit( OpCodes::Sub );
   mthdIL->Emit( OpCodes::Stind_R8 );
   mthdIL->Emit( OpCodes::Ldarg_0 );
   mthdIL->Emit( OpCodes::Ldarg_0 );
   mthdIL->Emit( OpCodes::Ldfld, balanceAmtBldr );
   mthdIL->Emit( OpCodes::Ldarg_2 );
   mthdIL->Emit( OpCodes::Add );
   mthdIL->Emit( OpCodes::Stfld, balanceAmtBldr );
   mthdIL->Emit( OpCodes::Ldarg_0 );
   mthdIL->Emit( OpCodes::Ldfld, balanceAmtBldr );
   mthdIL->Emit( OpCodes::Ret );
   return myTypeBuilder->CreateType();
}

int main()
{
   Type^ custType = nullptr;
   Object^ custObj = nullptr;
   array<Type^>^custArgTypes = {String::typeid,String::typeid,double::typeid};
   
   // Call the method to build our dynamic class.
   custType = BuildCustomerDataType();
   Console::WriteLine( "---" );
   ConstructorInfo^ myCustCtor = custType->GetConstructor( custArgTypes );
   double initialBalance = 100.00;
   array<Object^>^temp5 = {"Joe Consumer","5678-XYZ",initialBalance};
   custObj = myCustCtor->Invoke( temp5 );
   array<MemberInfo^>^myMemberInfo = custType->GetMember( "AddFundsFromPool" );
   double thePool = 1000.00;
   Console::WriteLine( "The pool is currently ${0}", thePool );
   Console::WriteLine( "The original balance of the account instance is ${0}", initialBalance );
   double amountFromPool = 50.00;
   Console::WriteLine( "The amount to be subtracted from the pool and added to the account is ${0}", amountFromPool );
   Console::WriteLine( "---" );
   Console::WriteLine( "Calling {0} ...", myMemberInfo[ 0 ] );
   Console::WriteLine( "---" );
   array<Object^>^passMe = {thePool,amountFromPool};
   Console::WriteLine( "The new balance in the account instance is ${0}", custType->InvokeMember( "AddFundsFromPool", BindingFlags::InvokeMethod, nullptr, custObj, passMe ) );
   thePool = safe_cast<double>(passMe[ 0 ]);
   Console::WriteLine( "The new amount in the pool is ${0}", thePool );
}
// </Snippet1>
