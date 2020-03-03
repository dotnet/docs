
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Define one writable property and one not writable.
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
      String^ get()
      {
         return caption;
      }

   }

};

int main()
{
   Console::WriteLine( "\nReflection.PropertyInfo" );
   
   // Define two properties.
   Mypropertya^ mypropertya = gcnew Mypropertya;
   Mypropertyb^ mypropertyb = gcnew Mypropertyb;
   
   // Read and display the property.
   Console::Write( "\nMypropertya->Caption = {0}", mypropertya->Caption );
   Console::Write( "\nMypropertyb->Caption = {0}", mypropertyb->Caption );
   
   // Write to the property.
   mypropertya->Caption = "A- No Change";
   
   // Mypropertyb.Caption cannot be written to because
   // there is no set accessor.
   // Read and display the property.
   Console::Write( "\nMypropertya->Caption = {0}", mypropertya->Caption );
   Console::Write( "\nMypropertyb->Caption = {0}", mypropertyb->Caption );
   
   // Get the type and PropertyInfo.
   Type^ MyTypea = Type::GetType( "Mypropertya" );
   PropertyInfo^ Mypropertyinfoa = MyTypea->GetProperty( "Caption" );
   Type^ MyTypeb = Type::GetType( "Mypropertyb" );
   PropertyInfo^ Mypropertyinfob = MyTypeb->GetProperty( "Caption" );
   
   // Get and display the CanWrite property.
   Console::Write( "\nCanWrite a - {0}", Mypropertyinfoa->CanWrite );
   Console::Write( "\nCanWrite b - {0}", Mypropertyinfob->CanWrite );
   return 0;
}

// </Snippet1>
