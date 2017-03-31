
// <Snippet1>
using namespace System;
using namespace System::Reflection;

//Make two fields, one public and one read-only.
public ref class Myfielda
{
public:
   String^ field;
   Myfielda()
      : field( "A - public field" )
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
   String^ const field;

public:
   Myfieldb()
      : field( "B - readonly field" )
   {}


   property String^ Field 
   {
      String^ get()
      {
         return field;
      }

   }

};

int main()
{
   Console::WriteLine( "\nReflection.FieldInfo" );
   Myfielda^ myfielda = gcnew Myfielda;
   Myfieldb^ myfieldb = gcnew Myfieldb;
   
   //Get the Type and FieldInfo.
   Type^ MyTypea = Type::GetType( "Myfielda" );
   FieldInfo^ Myfieldinfoa = MyTypea->GetField( "field", static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance) );
   Type^ MyTypeb = Type::GetType( "Myfieldb" );
   FieldInfo^ Myfieldinfob = MyTypeb->GetField( "field", static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance) );
   
   //Modify the fields.
   //Note that Myfieldb is not modified, as it is
   //read-only (IsInitOnly is True).
   myfielda->field = "A- modified";
   
   //Myfieldb.field = "B- modified";
   //For the first field, get and display the name, field, and IsInitOnly state.
   Console::Write( "\n{0} - {1}, IsInitOnly = {2} ", MyTypea->FullName, Myfieldinfoa->GetValue( myfielda ), Myfieldinfoa->IsInitOnly );
   
   //For the second field get and display the name, field, and IsInitOnly state.
   Console::Write( "\n{0} - {1}, IsInitOnly = {2} ", MyTypeb->FullName, Myfieldinfob->GetValue( myfieldb ), Myfieldinfob->IsInitOnly );
   return 0;
}

// </Snippet1>
