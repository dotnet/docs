
// <Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
Type^ DynamicPointTypeGen()
{
   Type^ pointType = nullptr;
   array<Type^>^temp0 = {int::typeid,int::typeid,int::typeid};
   array<Type^>^ctorParams = temp0;
   AppDomain^ myDomain = Thread::GetDomain();
   AssemblyName^ myAsmName = gcnew AssemblyName;
   myAsmName->Name = "MyDynamicAssembly";
   AssemblyBuilder^ myAsmBuilder = myDomain->DefineDynamicAssembly( myAsmName, AssemblyBuilderAccess::RunAndSave );
   ModuleBuilder^ pointModule = myAsmBuilder->DefineDynamicModule( "PointModule", "Point.dll" );
   TypeBuilder^ pointTypeBld = pointModule->DefineType( "Point", TypeAttributes::Public );
   FieldBuilder^ xField = pointTypeBld->DefineField( "x", int::typeid, FieldAttributes::Public );
   FieldBuilder^ yField = pointTypeBld->DefineField( "y", int::typeid, FieldAttributes::Public );
   FieldBuilder^ zField = pointTypeBld->DefineField( "z", int::typeid, FieldAttributes::Public );
   Type^ objType = Type::GetType( "System.Object" );
   ConstructorInfo^ objCtor = objType->GetConstructor( gcnew array<Type^>(0) );
   ConstructorBuilder^ pointCtor = pointTypeBld->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, ctorParams );
   ILGenerator^ ctorIL = pointCtor->GetILGenerator();
   
   // NOTE: ldarg.0 holds the "this" reference - ldarg.1, ldarg.2, and ldarg.3
   // hold the actual passed parameters. ldarg.0 is used by instance methods
   // to hold a reference to the current calling bject instance. Static methods
   // do not use arg.0, since they are not instantiated and hence no reference
   // is needed to distinguish them.
   ctorIL->Emit( OpCodes::Ldarg_0 );
   
   // Here, we wish to create an instance of System::Object by invoking its
   // constructor, as specified above.
   ctorIL->Emit( OpCodes::Call, objCtor );
   
   // Now, we'll load the current instance in arg 0, along
   // with the value of parameter "x" stored in arg 1, into stfld.
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_1 );
   ctorIL->Emit( OpCodes::Stfld, xField );
   
   // Now, we store arg 2 "y" in the current instance with stfld.
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_2 );
   ctorIL->Emit( OpCodes::Stfld, yField );
   
   // Last of all, arg 3 "z" gets stored in the current instance.
   ctorIL->Emit( OpCodes::Ldarg_0 );
   ctorIL->Emit( OpCodes::Ldarg_3 );
   ctorIL->Emit( OpCodes::Stfld, zField );
   
   // Our work complete, we return.
   ctorIL->Emit( OpCodes::Ret );
   
   // Now, let's create three very simple methods so we can see our fields.
   array<String^>^temp1 = {"GetX","GetY","GetZ"};
   array<String^>^mthdNames = temp1;
   System::Collections::IEnumerator^ myEnum = mthdNames->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ mthdName = safe_cast<String^>(myEnum->Current);
      MethodBuilder^ getFieldMthd = pointTypeBld->DefineMethod( mthdName, MethodAttributes::Public, int::typeid, nullptr );
      ILGenerator^ mthdIL = getFieldMthd->GetILGenerator();
      mthdIL->Emit( OpCodes::Ldarg_0 );
      if ( mthdName->Equals( "GetX" ) )
            mthdIL->Emit( OpCodes::Ldfld, xField );
      else
      if ( mthdName->Equals( "GetY" ) )
            mthdIL->Emit( OpCodes::Ldfld, yField );
      else
      if ( mthdName->Equals( "GetZ" ) )
            mthdIL->Emit( OpCodes::Ldfld, zField );



      mthdIL->Emit( OpCodes::Ret );
   }

   pointType = pointTypeBld->CreateType();
   
   // Let's save it, just for posterity.
   myAsmBuilder->Save( "Point.dll" );
   return pointType;
}

int main()
{
   Type^ myDynamicType = nullptr;
   Object^ aPoint = nullptr;
   array<Type^>^temp2 = {int::typeid,int::typeid,int::typeid};
   array<Type^>^aPtypes = temp2;
   array<Object^>^temp3 = {4,5,6};
   array<Object^>^aPargs = temp3;
   
   // Call the  method to build our dynamic class.
   myDynamicType = DynamicPointTypeGen();
   Console::WriteLine( "Some information about my new Type '{0}':", myDynamicType->FullName );
   Console::WriteLine( "Assembly: '{0}'", myDynamicType->Assembly );
   Console::WriteLine( "Attributes: '{0}'", myDynamicType->Attributes );
   Console::WriteLine( "Module: '{0}'", myDynamicType->Module );
   Console::WriteLine( "Members: " );
   System::Collections::IEnumerator^ myEnum = myDynamicType->GetMembers()->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      MemberInfo^ member = safe_cast<MemberInfo^>(myEnum->Current);
      Console::WriteLine( "-- {0} {1};", member->MemberType, member->Name );
   }

   Console::WriteLine( "---" );
   
   // Let's take a look at the constructor we created.
   ConstructorInfo^ myDTctor = myDynamicType->GetConstructor( aPtypes );
   Console::WriteLine( "Constructor: {0};", myDTctor );
   Console::WriteLine( "---" );
   
   // Now, we get to use our dynamically-created class by invoking the constructor.
   aPoint = myDTctor->Invoke( aPargs );
   Console::WriteLine( "aPoint is type {0}.", aPoint->GetType() );
   
   // Finally, let's reflect on the instance of our new type - aPoint - and
   // make sure everything proceeded according to plan.
   Console::WriteLine( "aPoint.x = {0}", myDynamicType->InvokeMember( "GetX", BindingFlags::InvokeMethod, nullptr, aPoint, gcnew array<Object^>(0) ) );
   Console::WriteLine( "aPoint.y = {0}", myDynamicType->InvokeMember( "GetY", BindingFlags::InvokeMethod, nullptr, aPoint, gcnew array<Object^>(0) ) );
   Console::WriteLine( "aPoint.z = {0}", myDynamicType->InvokeMember( "GetZ", BindingFlags::InvokeMethod, nullptr, aPoint, gcnew array<Object^>(0) ) );
   
   // +++ OUTPUT +++
   // Some information about my new Type 'Point':
   // Assembly: 'MyDynamicAssembly, Version=0.0.0.0'
   // Attributes: 'AutoLayout, AnsiClass, NotPublic, Public'
   // Module: 'PointModule'
   // Members:
   // -- Field x;
   // -- Field y;
   // -- Field z;
   // -- Method GetHashCode;
   // -- Method Equals;
   // -- Method ToString;
   // -- Method GetType;
   // -- Constructor .ctor;
   // ---
   // Constructor: Void .ctor(Int32, Int32, Int32);
   // ---
   // aPoint is type Point.
   // aPoint.x = 4
   // aPoint.y = 5
   // aPoint.z = 6
}

// </Snippet1>
