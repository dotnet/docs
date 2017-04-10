
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Make two fields.
// private
public ref class Myfielda
{
private:
   String^ SomeField;

public:
   Myfielda()
      : SomeField( "private field" )
   {}


   property String^ Field 
   {
      String^ get()
      {
         return SomeField;
      }

   }

};


// public
public ref class Myfieldb
{
public:
   String^ SomeField;
   Myfieldb()
      : SomeField( "public field" )
   {}


   property String^ Field 
   {
      String^ get()
      {
         return SomeField;
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
   FieldInfo^ Myfieldinfoa = MyTypea->GetField( "SomeField", static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance) );
   Type^ MyTypeb = Type::GetType( "Myfieldb" );
   FieldInfo^ Myfieldinfob = MyTypeb->GetField( "SomeField" );
   
   // Get and display the IsPublic and IsPrivate property values.
   Console::Write( "\n{0}.", MyTypea->FullName );
   Console::Write( "{0} - ", Myfieldinfoa->Name );
   Console::Write( "{0}", myfielda->Field );
   Console::Write( "\n   IsPublic = {0}", Myfieldinfoa->IsPublic );
   Console::Write( "\n   IsPrivate = {0}", Myfieldinfoa->IsPrivate );
   Console::Write( "\n{0}.", MyTypeb->FullName );
   Console::Write( "{0} - ", Myfieldinfob->Name );
   Console::Write( "{0};", myfieldb->Field );
   Console::Write( "\n   IsPublic = {0}", Myfieldinfob->IsPublic );
   Console::Write( "\n   IsPrivate = {0}", Myfieldinfob->IsPrivate );
   return 0;
}

// </Snippet1>
