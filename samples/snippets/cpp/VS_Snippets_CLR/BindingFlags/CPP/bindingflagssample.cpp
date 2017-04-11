// <snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Reflection;
using namespace System::IO;

//namespace BindingFlagsSnippet {
public ref class TestClass
{
public:
   String^ Name;

private:
   array<Object^>^ values;
   int methodCalled;

public:

   property Object^ Item [int]
   {
      Object^ get( int index )
      {
         return values[ index ];
      }

      void set( int index, Object^ value )
      {
         values[ index ] = value;
      }
   }

   property Object^ Value
   {
      Object^ get()
      {
         return "the value";
      }
   }

   TestClass() 
   {
      Name = "initialName";
      values = gcnew array<Object^> {(int^)0,1,2,3,4,5,6,7,8,9};
      methodCalled = 0;
   }
   
   TestClass(String^ initName)
   {
      Name = initName;
      values = gcnew array<Object^> {(int^)0,1,2,3,4,5,6,7,8,9};
      methodCalled = 0;
   }

   static void SayHello()
   {
      Console::WriteLine( "Hello" );
   }

   void AddUp()
   {
      methodCalled++;
      Console::WriteLine( "AddUp Called {0} times", methodCalled );
   }

   static double ComputeSum( double d1, double d2 )
   {
      return d1 + d2;
   }

   static void PrintName( String^ firstName, String^ lastName )
   {
      Console::WriteLine( "{0},{1}", lastName, firstName );
   }

   void PrintTime()
   {
      Console::WriteLine( DateTime::Now );
   }

   void Swap( interior_ptr<int> a, interior_ptr<int> b )
   {
      int x =  *a;
       *a =  *b;
       *b = x;
   }
};


[DefaultMemberAttribute("PrintTime")]
public ref class TestClass2
{
public:
   void PrintTime()
   {
      Console::WriteLine( DateTime::Now );
   }

};

public ref class Base
{
private:
    static int BaseOnlyPrivate = 0;
protected:
    static int BaseOnly = 0;
};

public ref class Derived : Base
{
public:
    static int DerivedOnly = 0;
};

public ref class MostDerived : Derived {};

void main()
{
   array<Object^>^ noArguments;

   // BindingFlags::InvokeMethod
   // Call a static method.
   Type^ t = TestClass::typeid;
   Console::WriteLine();
   Console::WriteLine( "Invoking a static method." );
   Console::WriteLine( "-------------------------" );
   t->InvokeMember( "SayHello", BindingFlags::InvokeMethod | BindingFlags::Public | BindingFlags::Static, 
         nullptr, nullptr, noArguments );

   // BindingFlags::InvokeMethod
   // Call an instance method.
   TestClass^ c = gcnew TestClass;
   Console::WriteLine();
   Console::WriteLine( "Invoking an instance method." );
   Console::WriteLine( "----------------------------" );
   c->GetType()->InvokeMember( "AddUp", BindingFlags::InvokeMethod, nullptr, c, noArguments );
   c->GetType()->InvokeMember( "AddUp", BindingFlags::InvokeMethod, nullptr, c, noArguments );

   // BindingFlags::InvokeMethod
   // Call a method with parameters.
   array<Object^>^args = {100.09,184.45};
   Object^ result;
   Console::WriteLine();
   Console::WriteLine( "Invoking a method with parameters." );
   Console::WriteLine( "---------------------------------" );
   result = t->InvokeMember( "ComputeSum", BindingFlags::InvokeMethod, nullptr, nullptr, args );
   Console::WriteLine( " {0} + {1} = {2}", args[ 0 ], args[ 1 ], result );

   // BindingFlags::GetField, SetField
   Console::WriteLine();
   Console::WriteLine( "Invoking a field (getting and setting.)" );
   Console::WriteLine( "--------------------------------------" );

   // Get a field value.
   result = t->InvokeMember( "Name", BindingFlags::GetField, nullptr, c, noArguments );
   Console::WriteLine( "Name == {0}", result );

   // Set a field.
   array<Object^>^obj2 = {"NewName"};
   t->InvokeMember( "Name", BindingFlags::SetField, nullptr, c, obj2 );
   result = t->InvokeMember( "Name", BindingFlags::GetField, nullptr, c, noArguments );
   Console::WriteLine( "Name == {0}", result );
   Console::WriteLine();
   Console::WriteLine( "Invoking an indexed property (getting and setting.)" );
   Console::WriteLine( "--------------------------------------------------" );

   // BindingFlags::GetProperty
   // Get an indexed property value.
   int index = 3;
   array<Object^>^obj3 = {index};
   result = t->InvokeMember( "Item", BindingFlags::GetProperty, nullptr, c, obj3 );
   Console::WriteLine( "Item->Item[ {0}] == {1}", index, result );

   // BindingFlags::SetProperty
   // Set an indexed property value.
   index = 3;
   array<Object^>^obj4 = {index,"NewValue"};
   t->InvokeMember( "Item", BindingFlags::SetProperty, nullptr, c, obj4 );
   result = t->InvokeMember( "Item", BindingFlags::GetProperty, nullptr, c, obj3 );
   Console::WriteLine( "Item->Item[ {0}] == {1}", index, result );
   Console::WriteLine();
   Console::WriteLine( "Getting a field or property." );
   Console::WriteLine( "----------------------------" );

   // BindingFlags::GetField
   // Get a field or property.
   result = t->InvokeMember( "Name", static_cast<BindingFlags>(BindingFlags::GetField | 
       BindingFlags::GetProperty), nullptr, c, noArguments );
   Console::WriteLine( "Name == {0}", result );

   // BindingFlags::GetProperty
   result = t->InvokeMember( "Value", static_cast<BindingFlags>(BindingFlags::GetField | 
       BindingFlags::GetProperty), nullptr, c, noArguments );
   Console::WriteLine( "Value == {0}", result );
   Console::WriteLine();
   Console::WriteLine( "Invoking a method with named parameters." );
   Console::WriteLine( "---------------------------------------" );

   // BindingFlags::InvokeMethod
   // Call a method using named parameters.
   array<Object^>^argValues = {"Mouse","Micky"};
   array<String^>^argNames = {"lastName","firstName"};
   t->InvokeMember( "PrintName", BindingFlags::InvokeMethod, nullptr, nullptr, argValues, nullptr, 
       nullptr, argNames );
   Console::WriteLine();
   Console::WriteLine( "Invoking a default member of a type." );
   Console::WriteLine( "------------------------------------" );

   // BindingFlags::Default
   // Call the default member of a type.
   Type^ t3 = TestClass2::typeid;
   t3->InvokeMember( "", static_cast<BindingFlags>(BindingFlags::InvokeMethod | BindingFlags::Default), 
        nullptr, gcnew TestClass2, noArguments );

   // BindingFlags::Static, NonPublic, and Public
   // Invoking a member with ref parameters.
   Console::WriteLine();
   Console::WriteLine( "Invoking a method with ref parameters." );
   Console::WriteLine( "--------------------------------------" );
   MethodInfo^ m = t->GetMethod( "Swap" );
   args = gcnew array<Object^>(2);
   args[ 0 ] = 1;
   args[ 1 ] = 2;
   m->Invoke( gcnew TestClass, args );
   Console::WriteLine( "{0}, {1}", args[ 0 ], args[ 1 ] );

   // BindingFlags::CreateInstance
   // Creating an instance with a parameterless constructor.
   Console::WriteLine();
   Console::WriteLine( "Creating an instance with a parameterless constructor." );
   Console::WriteLine( "------------------------------------------------------" );
   Object^ obj = t->InvokeMember( "TestClass", static_cast<BindingFlags>(BindingFlags::Public | 
       BindingFlags::Instance | BindingFlags::CreateInstance), nullptr, nullptr, noArguments );
   Console::WriteLine("Instance of {0} created.", obj->GetType()->Name);

   // Creating an instance with a constructor that has parameters.
   Console::WriteLine();
   Console::WriteLine( "Creating an instance with a constructor that has parameters." );
   Console::WriteLine( "------------------------------------------------------------" );
   obj = t->InvokeMember( "TestClass", static_cast<BindingFlags>(BindingFlags::Public | 
       BindingFlags::Instance | BindingFlags::CreateInstance), nullptr, nullptr, 
       gcnew array<Object^> { "Hello, World!" } );
   Console::WriteLine("Instance of {0} created with initial value '{1}'.", obj->GetType()->Name, 
       obj->GetType()->InvokeMember("Name", BindingFlags::GetField, nullptr, obj, noArguments));

   // BindingFlags::DeclaredOnly
   Console::WriteLine();
   Console::WriteLine( "DeclaredOnly instance members." );
   Console::WriteLine( "------------------------------" );
   array<System::Reflection::MemberInfo^>^memInfo = t->GetMembers( BindingFlags::DeclaredOnly | 
       BindingFlags::Instance | BindingFlags::Public);
   for ( int i = 0; i < memInfo->Length; i++ )
   {
      Console::WriteLine( memInfo[ i ]->Name );

   }

   // BindingFlags::IgnoreCase
   Console::WriteLine();
   Console::WriteLine( "Using IgnoreCase and invoking the PrintName method." );
   Console::WriteLine( "---------------------------------------------------" );
   t->InvokeMember( "printname", static_cast<BindingFlags>(BindingFlags::IgnoreCase | 
                BindingFlags::Static | BindingFlags::Public | BindingFlags::InvokeMethod), 
                nullptr, nullptr, gcnew array<Object^> {"Brad","Smith"});

   // BindingFlags::FlattenHierarchy
   Console::WriteLine();
   Console::WriteLine( "Using FlattenHierarchy to get inherited static protected and public members." );
   Console::WriteLine( "----------------------------------------------------------------------------" );
   array<FieldInfo^>^ finfos = MostDerived::typeid->GetFields(BindingFlags::NonPublic | 
         BindingFlags::Public | BindingFlags::Static | BindingFlags::FlattenHierarchy);
   for each (FieldInfo^ finfo in finfos)
   {
       Console::WriteLine("{0} defined in {1}.", finfo->Name, finfo->DeclaringType->Name);
   }

   Console::WriteLine();
   Console::WriteLine("Without FlattenHierarchy." );
   Console::WriteLine("-------------------------");
   finfos = MostDerived::typeid->GetFields(BindingFlags::NonPublic | BindingFlags::Public |
         BindingFlags::Static);
   for each (FieldInfo^ finfo in finfos)
   {
       Console::WriteLine("{0} defined in {1}.", finfo->Name, finfo->DeclaringType->Name);
   }
};

/* This example produces output similar to the following:

Invoking a static method.
-------------------------
Hello

Invoking an instance method.
----------------------------
AddUp Called 1 times
AddUp Called 2 times

Invoking a method with parameters.
---------------------------------
 100.09 + 184.45 = 284.54

Invoking a field (getting and setting.)
--------------------------------------
Name == initialName
Name == NewName

Invoking an indexed property (getting and setting.)
--------------------------------------------------
Item->Item[ 3] == 3
Item->Item[ 3] == NewValue

Getting a field or property.
----------------------------
Name == NewName
Value == the value

Invoking a method with named parameters.
---------------------------------------
Mouse,Micky

Invoking a default member of a type.
------------------------------------
12/23/2009 4:19:06 PM

Invoking a method with ref parameters.
--------------------------------------
2, 1

Creating an instance with a parameterless constructor.
------------------------------------------------------
Instance of TestClass created.

Creating an instance with a constructor that has parameters.
------------------------------------------------------------
Instance of TestClass created with initial value 'Hello, World!'.

DeclaredOnly instance members.
------------------------------
get_Item
set_Item
get_Value
AddUp
PrintTime
Swap
.ctor
.ctor
Value
Item
Name
methodCalled

Using IgnoreCase and invoking the PrintName method.
---------------------------------------------------
Smith,Brad

Using FlattenHierarchy to get inherited static protected and public members.
----------------------------------------------------------------------------
DerivedOnly defined in Derived.
BaseOnly defined in Base.

Without FlattenHierarchy.
-------------------------

 */
// </snippet1>
