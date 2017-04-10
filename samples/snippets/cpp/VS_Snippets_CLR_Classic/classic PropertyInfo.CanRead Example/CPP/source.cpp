
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Define one readable property and one not readable.
public ref class Mypropertya
{
private:
   String^ caption;

public:
   Mypropertya()
      : caption( "A Default caption" )
   {}


   property String^ Caption 
   {
      String^ get()
      {
         return caption;
      }

      void set( String^ value )
      {
         if ( caption != value )
         {
            caption = value;
         }
      }

   }

};

public ref class Mypropertyb
{
private:
   String^ caption;

public:
   Mypropertyb()
      : caption( "B Default caption" )
   {}


   property String^ Caption 
   {
      void set( String^ value )
      {
         if ( caption != value )
         {
            caption = value;
         }
      }

   }

};

int main()
{
   Console::WriteLine( "\nReflection.PropertyInfo" );
   
   // Define two properties.
   Mypropertya^ mypropertya = gcnew Mypropertya;
   Mypropertyb^ mypropertyb = gcnew Mypropertyb;
   Console::Write( "\nMypropertya->Caption = {0}", mypropertya->Caption );
   
   // Mypropertyb.Caption cannot be read, because
   // there is no get accessor.
   // Get the type and PropertyInfo.
   Type^ MyTypea = Type::GetType( "Mypropertya" );
   PropertyInfo^ Mypropertyinfoa = MyTypea->GetProperty( "Caption" );
   Type^ MyTypeb = Type::GetType( "Mypropertyb" );
   PropertyInfo^ Mypropertyinfob = MyTypeb->GetProperty( "Caption" );
   
   // Get and display the CanRead property.
   Console::Write( "\nCanRead a - {0}", Mypropertyinfoa->CanRead );
   Console::Write( "\nCanRead b - {0}", Mypropertyinfob->CanRead );
   return 0;
}

// </Snippet1>
