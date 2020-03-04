
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// This sample class has a field, constructor, method, and property.
ref class MyType
{
private:
   Int32 myField;

public:
   MyType( interior_ptr<Int32> x )
   {
       *x *= 5;
   }

   virtual String^ ToString() override
   {
      return myField.ToString();
   }

   property Int32 MyProp 
   {
      Int32 get()
      {
         return myField;
      }

      void set( Int32 value )
      {
         if ( value < 1 )
                  throw gcnew ArgumentOutOfRangeException( "value",value,"value must be > 0" );

         myField = value;
      }
   }
};

int main()
{
   Type^ t = MyType::typeid;

   // Create an instance of a type.
   array<Object^>^args = {8};
   Console::WriteLine( "The value of x before the constructor is called is {0}.", args[ 0 ] );
   Object^ obj = t->InvokeMember( nullptr, static_cast<BindingFlags>(BindingFlags::DeclaredOnly | BindingFlags::Public | BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::CreateInstance), nullptr, nullptr, args );
   Console::WriteLine( "Type: {0}", obj->GetType() );
   Console::WriteLine( "The value of x after the constructor returns is {0}.", args[ 0 ] );

   // Read and write to a field.
   array<Object^>^obj5 = {5};
   t->InvokeMember( "myField", static_cast<BindingFlags>(BindingFlags::DeclaredOnly | BindingFlags::Public | BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::SetField), nullptr, obj, obj5 );
   Int32 v = safe_cast<Int32>(t->InvokeMember( "myField", static_cast<BindingFlags>(BindingFlags::DeclaredOnly | BindingFlags::Public | BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::GetField), nullptr, obj, nullptr ));
   Console::WriteLine( "myField: {0}", v );

   // Call a method.
   String^ s = safe_cast<String^>(t->InvokeMember( "ToString", static_cast<BindingFlags>(BindingFlags::DeclaredOnly | BindingFlags::Public | BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::InvokeMethod), nullptr, obj, nullptr ));
   Console::WriteLine( "ToString: {0}", s );

   // Read and write a property. First, attempt to assign an
   // invalid value; then assign a valid value; finally, get
   // the value.
   try
   {
      // Assign the value zero to MyProp. The Property Set 
      // throws an exception, because zero is an invalid value.
      // InvokeMember catches the exception, and throws 
      // TargetInvocationException. To discover the real cause
      // you must catch TargetInvocationException and examine
      // the inner exception. 
      array<Object^>^obj0 = {(int^)0};
      t->InvokeMember( "MyProp", static_cast<BindingFlags>(BindingFlags::DeclaredOnly | BindingFlags::Public | BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::SetProperty), nullptr, obj, obj0 );
   }
   catch ( TargetInvocationException^ e ) 
   {
      // If the property assignment failed for some unexpected
      // reason, rethrow the TargetInvocationException.
      if ( e->InnerException->GetType() != ArgumentOutOfRangeException::typeid )
            throw;

      Console::WriteLine( "An invalid value was assigned to MyProp." );
   }

   array<Object^>^obj2 = {2};
   t->InvokeMember( "MyProp", static_cast<BindingFlags>(BindingFlags::DeclaredOnly | BindingFlags::Public | BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::SetProperty), nullptr, obj, obj2 );
   v =  safe_cast<Int32>(t->InvokeMember( "MyProp", static_cast<BindingFlags>(BindingFlags::DeclaredOnly | BindingFlags::Public | BindingFlags::NonPublic | BindingFlags::Instance | BindingFlags::GetProperty), nullptr, obj, nullptr ));
   Console::WriteLine( "MyProp: {0}", v );
}
// </Snippet1>
