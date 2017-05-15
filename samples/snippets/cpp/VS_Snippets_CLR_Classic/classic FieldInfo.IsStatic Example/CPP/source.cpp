
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Make two fields.
public ref class Myfielda
{
private:
   String^ field;

public:
   Myfielda()
      : field( "A private field" )
   {}


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

public ref class Myfieldb
{
private:
   static String^ field = "B static field";

public:

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
   Console::WriteLine( "\nReflection.FieldInfo" );
   Myfielda^ myfielda = gcnew Myfielda;
   Myfieldb^ myfieldb = gcnew Myfieldb;
   
   // Get the Type and FieldInfo.
   Type^ MyTypea = Type::GetType( "Myfielda" );
   FieldInfo^ Myfieldinfoa = MyTypea->GetField( "field", static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance) );
   Type^ MyTypeb = Type::GetType( "Myfieldb" );
   FieldInfo^ Myfieldinfob = MyTypeb->GetField( "field", static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Static) );
   
   // For the first field, get and display the name, field, and IsStatic property value.
   Console::Write( "\n{0} - ", MyTypea->FullName );
   Console::Write( "{0}; ", Myfieldinfoa->GetValue( myfielda ) );
   Console::Write( "IsStatic - {0}", Myfieldinfoa->IsStatic );
   
   // For the second field get and display the name, field, and IsStatic property value.
   Console::Write( "\n{0} - ", MyTypeb->FullName );
   Console::Write( "{0}; ", Myfieldinfob->GetValue( myfieldb ) );
   Console::Write( "IsStatic - {0}", Myfieldinfob->IsStatic );
   return 0;
}

// </Snippet1>
