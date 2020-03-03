
// <Snippet1>
// <Snippet2>
using namespace System;
using namespace System::Reflection;
using namespace System::Security;
public ref class MyFieldClassA
{
public:
   String^ field;
   MyFieldClassA()
   {
      field = "A Field";
   }


   property String^ Field 
   {
      String^ get()
      {
         return field;
      }

      void set( String^ value )
      {
         if ( field != value )
         {
            field = value;
         }
      }

   }

};

public ref class MyFieldClassB
{
public:
   String^ field;
   MyFieldClassB()
   {
      field = "B Field";
   }


   property String^ Field 
   {
      String^ get()
      {
         return field;
      }

      void set( String^ value )
      {
         if ( field != value )
         {
            field = value;
         }
      }

   }

};

int main()
{
   try
   {
      MyFieldClassB^ myFieldObjectB = gcnew MyFieldClassB;
      MyFieldClassA^ myFieldObjectA = gcnew MyFieldClassA;
      Type^ myTypeA = Type::GetType( "MyFieldClassA" );
      FieldInfo^ myFieldInfo = myTypeA->GetField( "field" );
      Type^ myTypeB = Type::GetType( "MyFieldClassB" );
      FieldInfo^ myFieldInfo1 = myTypeB->GetField( "field", static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance) );
      Console::WriteLine( "The value of the field is : {0} ", myFieldInfo->GetValue( myFieldObjectA ) );
      Console::WriteLine( "The value of the field is : {0} ", myFieldInfo1->GetValue( myFieldObjectB ) );
   }
   catch ( SecurityException^ e ) 
   {
      Console::WriteLine( "Exception Raised!" );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( ArgumentNullException^ e ) 
   {
      Console::WriteLine( "Exception Raised!" );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception Raised!" );
      Console::WriteLine( "Message : {0}", e->Message );
   }

}

// </Snippet2>
// </Snippet1>
