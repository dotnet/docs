
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Make a field.
public ref class Myfield
{
private:
   String^ field;

public:
   Myfield()
      : field( "a private field" )
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
   Myfield^ myfield = gcnew Myfield;
   
   // Get the Type and FieldInfo.
   Type^ MyType = Type::GetType( "Myfield" );
   FieldInfo^ Myfieldinfo = MyType->GetField( "field", static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance) );
   
   // Get and display the MemberType.
   Console::Write( "\n{0}.", MyType->FullName );
   Console::Write( "{0} - ", Myfieldinfo->Name );
   Console::Write( "{0};", myfield->Field );
   MemberTypes Mymembertypes = Myfieldinfo->MemberType;
   Console::Write( "MemberType is a {0}.", Mymembertypes );
   return 0;
}

// </Snippet1>
