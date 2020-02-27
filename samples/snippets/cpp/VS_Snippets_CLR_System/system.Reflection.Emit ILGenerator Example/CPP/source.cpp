
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
Type^ DynamicDotProductGen()
{
   Type^ ivType = nullptr;
   array<Type^>^temp0 = {int::typeid,int::typeid,int::typeid};
   array<Type^>^ctorParams = temp0;
   AppDomain^ myDomain = Thread::GetDomain();
   AssemblyName^ myAsmName = gcnew AssemblyName;
   myAsmName->Name = "IntVectorAsm";
   AssemblyBuilder^ myAsmBuilder = myDomain->DefineDynamicAssembly( myAsmName, AssemblyBuilderAccess::RunAndSave );
   ModuleBuilder^ IntVectorModule = myAsmBuilder->DefineDynamicModule( "IntVectorModule", "Vector.dll" );
   TypeBuilder^ ivTypeBld = IntVectorModule->DefineType( "IntVector", TypeAttributes::Public );
   FieldBuilder^ xField = ivTypeBld->DefineField( "x", int::typeid, FieldAttributes::Private );
   FieldBuilder^ yField = ivTypeBld->DefineField( "y", int::typeid, FieldAttributes::Private );
   FieldBuilder^ zField = ivTypeBld->DefineField( "z", int::typeid, FieldAttributes::Private );
   Type^ objType = Type::GetType( "System.Object" );
   ConstructorInfo^ objCtor = objType->GetConstructor( gcnew array<Type^>(0) );
   ConstructorBuilder^ ivCtor = ivTypeBld->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, ctorParams );
   ILGenerator^ ctorIL = ivCtor->GetILGenerator();
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Call, objCtor );
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_1 );
   ctorIL->Emit( OpCodes::Stfld, xField );
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_2 );
   ctorIL->Emit( OpCodes::Stfld, yField );
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_3 );
   ctorIL->Emit( OpCodes::Stfld, zField );
   ctorIL->Emit( OpCodes::Ret );
   
   // This method will find the dot product of the stored vector
   // with another.
   array<Type^>^temp1 = {ivTypeBld};
   array<Type^>^dpParams = temp1;
   
   // Here, you create a MethodBuilder containing the
   // name, the attributes (public, static, private, and so on),
   // the return type (int, in this case), and a array of Type
   // indicating the type of each parameter. Since the sole parameter
   // is a IntVector, the very class you're creating, you will
   // pass in the TypeBuilder (which is derived from Type) instead of
   // a Type object for IntVector, avoiding an exception.
   // -- This method would be declared in C# as:
   //    public int DotProduct(IntVector aVector)
   MethodBuilder^ dotProductMthd = ivTypeBld->DefineMethod( "DotProduct", MethodAttributes::Public, int::typeid, dpParams );
   
   // A ILGenerator can now be spawned, attached to the MethodBuilder.
   ILGenerator^ mthdIL = dotProductMthd->GetILGenerator();
   
   // Here's the body of our function, in MSIL form. We're going to find the
   // "dot product" of the current vector instance with the passed vector
   // instance. For reference purposes, the equation is:
   // (x1 * x2) + (y1 * y2) + (z1 * z2) = the dot product
   // First, you'll load the reference to the current instance "this"
   // stored in argument 0 (ldarg.0) onto the stack. Ldfld, the subsequent
   // instruction, will pop the reference off the stack and look up the
   // field "x", specified by the FieldInfo token "xField".
   mthdIL->Emit( OpCodes::Ldarg_0 );
   mthdIL->Emit( OpCodes::Ldfld, xField );
   
   // That completed, the value stored at field "x" is now atop the stack.
   // Now, you'll do the same for the Object reference we passed as a
   // parameter, stored in argument 1 (ldarg.1). After Ldfld executed,
   // you'll have the value stored in field "x" for the passed instance
   // atop the stack.
   mthdIL->Emit( OpCodes::Ldarg_1 );
   mthdIL->Emit( OpCodes::Ldfld, xField );
   
   // There will now be two values atop the stack - the "x" value for the
   // current vector instance, and the "x" value for the passed instance.
   // You'll now multiply them, and push the result onto the evaluation stack.
   mthdIL->Emit( OpCodes::Mul_Ovf_Un );
   
   // Now, repeat this for the "y" fields of both vectors.
   mthdIL->Emit( OpCodes::Ldarg_0 );
   mthdIL->Emit( OpCodes::Ldfld, yField );
   mthdIL->Emit( OpCodes::Ldarg_1 );
   mthdIL->Emit( OpCodes::Ldfld, yField );
   mthdIL->Emit( OpCodes::Mul_Ovf_Un );
   
   // At this time, the results of both multiplications should be atop
   // the stack. You'll now add them and push the result onto the stack.
   mthdIL->Emit( OpCodes::Add_Ovf_Un );
   
   // Multiply both "z" field and push the result onto the stack.
   mthdIL->Emit( OpCodes::Ldarg_0 );
   mthdIL->Emit( OpCodes::Ldfld, zField );
   mthdIL->Emit( OpCodes::Ldarg_1 );
   mthdIL->Emit( OpCodes::Ldfld, zField );
   mthdIL->Emit( OpCodes::Mul_Ovf_Un );
   
   // Finally, add the result of multiplying the "z" fields with the
   // result of the earlier addition, and push the result - the dot product -
   // onto the stack.
   mthdIL->Emit( OpCodes::Add_Ovf_Un );
   
   // The "ret" opcode will pop the last value from the stack and return it
   // to the calling method. You're all done!
   mthdIL->Emit( OpCodes::Ret );
   ivType = ivTypeBld->CreateType();
   return ivType;
}

int main()
{
   Type^ IVType = nullptr;
   Object^ aVector1 = nullptr;
   Object^ aVector2 = nullptr;
   array<Type^>^temp2 = {int::typeid,int::typeid,int::typeid};
   array<Type^>^aVtypes = temp2;
   array<Object^>^temp3 = {10,10,10};
   array<Object^>^aVargs1 = temp3;
   array<Object^>^temp4 = {20,20,20};
   array<Object^>^aVargs2 = temp4;
   
   // Call the  method to build our dynamic class.
   IVType = DynamicDotProductGen();
   Console::WriteLine( "---" );
   ConstructorInfo^ myDTctor = IVType->GetConstructor( aVtypes );
   aVector1 = myDTctor->Invoke( aVargs1 );
   aVector2 = myDTctor->Invoke( aVargs2 );
   array<Object^>^passMe = gcnew array<Object^>(1);
   passMe[ 0 ] = dynamic_cast<Object^>(aVector2);
   Console::WriteLine( "(10, 10, 10) . (20, 20, 20) = {0}", IVType->InvokeMember( "DotProduct", BindingFlags::InvokeMethod, nullptr, aVector1, passMe ) );
}

// +++ OUTPUT +++
// ---
// (10, 10, 10) . (20, 20, 20) = 600
// </Snippet1>
