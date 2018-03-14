
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

// The Point class is the class we will reflect on and copy into our
// dynamic assembly. The public static function PointMain() will be used
// as our entry point.
//
// We are constructing the type seen here dynamically, and will write it
// out into a .exe file for later execution from the command-line.
// ---
// __gc class Point {
// 
// private:
//    int  x;
//    int  y;
// 
// public:
//    Point(int ix, int iy) {
// 
//       this->x = ix;
//       this->y = iy;
// 
//    }
// 
//    int DotProduct (Point* p) {
// 
//       return ((this->x * p->x) + (this->y * p->y));
// 
//   }
// 
//    static void PointMain() {
// 
//       Console::Write(S"Enter the 'x' value for point 1: ");
//       int x1 = Convert::ToInt32(Console::ReadLine());
// 
//       Console::Write(S"Enter the 'y' value for point 1: ");
//       int y1 = Convert::ToInt32(Console::ReadLine());
// 
//       Console::Write(S"Enter the 'x' value for point 2: ");
//       int x2 = Convert::ToInt32(Console::ReadLine());
// 
//       Console::Write(S"Enter the 'y' value for point 2: ");
//       int y2 = Convert::ToInt32(Console::ReadLine());
// 
//       Point* p1 = new Point(x1, y1);
//       Point* p2 = new Point(x2, y2);
// 
//       Console::WriteLine(S"( {0}, {1}) . ( {2}, {3}) = {4}.",
//          __box(x1), __box(y1), __box(x2), __box(y2), p1->DotProduct(p2));
// 
//    }
// 
// };
// ---
Type^ BuildDynAssembly()
{
   Type^ pointType = nullptr;
   AppDomain^ currentDom = Thread::GetDomain();
   Console::Write( "Please enter a name for your new assembly: " );
   StringBuilder^ asmFileNameBldr = gcnew StringBuilder;
   asmFileNameBldr->Append( Console::ReadLine() );
   asmFileNameBldr->Append( ".exe" );
   String^ asmFileName = asmFileNameBldr->ToString();
   AssemblyName^ myAsmName = gcnew AssemblyName;
   myAsmName->Name = "MyDynamicAssembly";
   AssemblyBuilder^ myAsmBldr = currentDom->DefineDynamicAssembly( myAsmName, AssemblyBuilderAccess::RunAndSave );
   
   // We've created a dynamic assembly space - now, we need to create a module
   // within it to reflect the type Point into.
   ModuleBuilder^ myModuleBldr = myAsmBldr->DefineDynamicModule( asmFileName, asmFileName );
   TypeBuilder^ myTypeBldr = myModuleBldr->DefineType( "Point" );
   FieldBuilder^ xField = myTypeBldr->DefineField( "x", int::typeid, FieldAttributes::Private );
   FieldBuilder^ yField = myTypeBldr->DefineField( "y", int::typeid, FieldAttributes::Private );
   
   // Build the constructor.
   Type^ objType = Type::GetType( "System.Object" );
   ConstructorInfo^ objCtor = objType->GetConstructor( gcnew array<Type^>(0) );
   array<Type^>^temp4 = {int::typeid,int::typeid};
   array<Type^>^ctorParams = temp4;
   ConstructorBuilder^ pointCtor = myTypeBldr->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, ctorParams );
   ILGenerator^ ctorIL = pointCtor->GetILGenerator();
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Call, objCtor );
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_1 );
   ctorIL->Emit( OpCodes::Stfld, xField );
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_2 );
   ctorIL->Emit( OpCodes::Stfld, yField );
   ctorIL->Emit( OpCodes::Ret );
   
   // Build the DotProduct method.
   Console::WriteLine( "Constructor built." );
   array<Type^>^temp0 = {myTypeBldr};
   MethodBuilder^ pointDPBldr = myTypeBldr->DefineMethod( "DotProduct", MethodAttributes::Public, int::typeid, temp0 );
   ILGenerator^ dpIL = pointDPBldr->GetILGenerator();
   dpIL->Emit( OpCodes::Ldarg_0 );
   dpIL->Emit( OpCodes::Ldfld, xField );
   dpIL->Emit( OpCodes::Ldarg_1 );
   dpIL->Emit( OpCodes::Ldfld, xField );
   dpIL->Emit( OpCodes::Mul_Ovf_Un );
   dpIL->Emit( OpCodes::Ldarg_0 );
   dpIL->Emit( OpCodes::Ldfld, yField );
   dpIL->Emit( OpCodes::Ldarg_1 );
   dpIL->Emit( OpCodes::Ldfld, yField );
   dpIL->Emit( OpCodes::Mul_Ovf_Un );
   dpIL->Emit( OpCodes::Add_Ovf_Un );
   dpIL->Emit( OpCodes::Ret );
   
   // Build the PointMain method.
   Console::WriteLine( "DotProduct built." );
   MethodBuilder^ pointMainBldr = myTypeBldr->DefineMethod( "PointMain", static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Static), void::typeid, nullptr );
   pointMainBldr->InitLocals = true;
   ILGenerator^ pmIL = pointMainBldr->GetILGenerator();
   
   // We have four methods that we wish to call, and must represent as
   // MethodInfo tokens:
   // - void Console::WriteLine(String*)
   // - String* Console::ReadLine()
   // - int Convert::Int32(String*)
   // - void Console::WriteLine(String*, Object*[])
   array<Type^>^temp1 = {String::typeid};
   MethodInfo^ writeMI = Console::typeid->GetMethod( "Write", temp1 );
   MethodInfo^ readLineMI = Console::typeid->GetMethod( "ReadLine", gcnew array<Type^>(0) );
   array<Type^>^temp2 = {String::typeid};
   MethodInfo^ convertInt32MI = Convert::typeid->GetMethod( "ToInt32", temp2 );
   array<Type^>^temp5 = {String::typeid,array<Object^>::typeid};
   array<Type^>^wlParams = temp5;
   MethodInfo^ writeLineMI = Console::typeid->GetMethod( "WriteLine", wlParams );
   
   // Although we could just refer to the local variables by
   // index (short ints for Ldloc/Stloc, bytes for LdLoc_S/Stloc_S),
   // this time, we'll use LocalBuilders for clarity and to
   // demonstrate their usage and syntax.
   LocalBuilder^ x1LB = pmIL->DeclareLocal( int::typeid );
   LocalBuilder^ y1LB = pmIL->DeclareLocal( int::typeid );
   LocalBuilder^ x2LB = pmIL->DeclareLocal( int::typeid );
   LocalBuilder^ y2LB = pmIL->DeclareLocal( int::typeid );
   LocalBuilder^ point1LB = pmIL->DeclareLocal( myTypeBldr );
   LocalBuilder^ point2LB = pmIL->DeclareLocal( myTypeBldr );
   LocalBuilder^ tempObjArrLB = pmIL->DeclareLocal( array<Object^>::typeid );
   pmIL->Emit( OpCodes::Ldstr, "Enter the 'x' value for point 1: " );
   pmIL->EmitCall( OpCodes::Call, writeMI, nullptr );
   pmIL->EmitCall( OpCodes::Call, readLineMI, nullptr );
   pmIL->EmitCall( OpCodes::Call, convertInt32MI, nullptr );
   pmIL->Emit( OpCodes::Stloc, x1LB );
   pmIL->Emit( OpCodes::Ldstr, "Enter the 'y' value for point 1: " );
   pmIL->EmitCall( OpCodes::Call, writeMI, nullptr );
   pmIL->EmitCall( OpCodes::Call, readLineMI, nullptr );
   pmIL->EmitCall( OpCodes::Call, convertInt32MI, nullptr );
   pmIL->Emit( OpCodes::Stloc, y1LB );
   pmIL->Emit( OpCodes::Ldstr, "Enter the 'x' value for point 2: " );
   pmIL->EmitCall( OpCodes::Call, writeMI, nullptr );
   pmIL->EmitCall( OpCodes::Call, readLineMI, nullptr );
   pmIL->EmitCall( OpCodes::Call, convertInt32MI, nullptr );
   pmIL->Emit( OpCodes::Stloc, x2LB );
   pmIL->Emit( OpCodes::Ldstr, "Enter the 'y' value for point 2: " );
   pmIL->EmitCall( OpCodes::Call, writeMI, nullptr );
   pmIL->EmitCall( OpCodes::Call, readLineMI, nullptr );
   pmIL->EmitCall( OpCodes::Call, convertInt32MI, nullptr );
   pmIL->Emit( OpCodes::Stloc, y2LB );
   pmIL->Emit( OpCodes::Ldloc, x1LB );
   pmIL->Emit( OpCodes::Ldloc, y1LB );
   pmIL->Emit( OpCodes::Newobj, pointCtor );
   pmIL->Emit( OpCodes::Stloc, point1LB );
   pmIL->Emit( OpCodes::Ldloc, x2LB );
   pmIL->Emit( OpCodes::Ldloc, y2LB );
   pmIL->Emit( OpCodes::Newobj, pointCtor );
   pmIL->Emit( OpCodes::Stloc, point2LB );
   pmIL->Emit( OpCodes::Ldstr, "( {0}, {1}) . ( {2}, {3}) = {4}." );
   pmIL->Emit( OpCodes::Ldc_I4_5 );
   pmIL->Emit( OpCodes::Newarr, Object::typeid );
   pmIL->Emit( OpCodes::Stloc, tempObjArrLB );
   pmIL->Emit( OpCodes::Ldloc, tempObjArrLB );
   pmIL->Emit( OpCodes::Ldc_I4_0 );
   pmIL->Emit( OpCodes::Ldloc, x1LB );
   pmIL->Emit( OpCodes::Box, int::typeid );
   pmIL->Emit( OpCodes::Stelem_Ref );
   pmIL->Emit( OpCodes::Ldloc, tempObjArrLB );
   pmIL->Emit( OpCodes::Ldc_I4_1 );
   pmIL->Emit( OpCodes::Ldloc, y1LB );
   pmIL->Emit( OpCodes::Box, int::typeid );
   pmIL->Emit( OpCodes::Stelem_Ref );
   pmIL->Emit( OpCodes::Ldloc, tempObjArrLB );
   pmIL->Emit( OpCodes::Ldc_I4_2 );
   pmIL->Emit( OpCodes::Ldloc, x2LB );
   pmIL->Emit( OpCodes::Box, int::typeid );
   pmIL->Emit( OpCodes::Stelem_Ref );
   pmIL->Emit( OpCodes::Ldloc, tempObjArrLB );
   pmIL->Emit( OpCodes::Ldc_I4_3 );
   pmIL->Emit( OpCodes::Ldloc, y2LB );
   pmIL->Emit( OpCodes::Box, int::typeid );
   pmIL->Emit( OpCodes::Stelem_Ref );
   pmIL->Emit( OpCodes::Ldloc, tempObjArrLB );
   pmIL->Emit( OpCodes::Ldc_I4_4 );
   pmIL->Emit( OpCodes::Ldloc, point1LB );
   pmIL->Emit( OpCodes::Ldloc, point2LB );
   pmIL->EmitCall( OpCodes::Callvirt, pointDPBldr, nullptr );
   pmIL->Emit( OpCodes::Box, int::typeid );
   pmIL->Emit( OpCodes::Stelem_Ref );
   pmIL->Emit( OpCodes::Ldloc, tempObjArrLB );
   pmIL->EmitCall( OpCodes::Call, writeLineMI, nullptr );
   pmIL->Emit( OpCodes::Ret );
   Console::WriteLine( "PointMain (entry point) built." );
   pointType = myTypeBldr->CreateType();
   Console::WriteLine( "Type completed." );
   myAsmBldr->SetEntryPoint( pointMainBldr );
   myAsmBldr->Save( asmFileName );
   Console::WriteLine( "Assembly saved as ' {0}'.", asmFileName );
   Console::WriteLine( "Type ' {0}' at the prompt to run your new dynamically generated dot product calculator.", asmFileName );
   
   // After execution, this program will have generated and written to disk,
   // in the directory you executed it from, a program named
   // <name_you_entered_here>.exe. You can run it by typing
   // the name you gave it during execution, in the same directory where
   // you executed this program.
   return pointType;
}

int main()
{
   Type^ myType = BuildDynAssembly();
   Console::WriteLine( "---" );
   
   // Let's invoke the type 'Point' created in our dynamic assembly.
   array<Object^>^temp3 = {nullptr,nullptr};
   Object^ ptInstance = Activator::CreateInstance( myType, temp3 );
   myType->InvokeMember( "PointMain", BindingFlags::InvokeMethod, nullptr, ptInstance, gcnew array<Object^>(0) );
}

// </Snippet1>
