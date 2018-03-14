
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Define three properties: one read-write, one default,
// and one read only. 
// Define a read-write property.
public ref class Aproperty
{
private:
   String^ caption;

public:
   Aproperty()
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


// Define a default property.
public ref class Bproperty
{
private:
   String^ caption;

public:
   Bproperty()
      : caption( "B Default caption" )
   {}

public:
   property String^ Item
   {
      String^ get()
      {
         return "1";
      }

   }

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


// Define a read-only property.
public ref class Cproperty
{
private:
   String^ caption;

public:
   Cproperty()
      : caption( "C Default caption" )
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
   Console::WriteLine( "\nReflection.PropertyAttributes" );
   
   // Determine whether a property exists, and change its value.
   Aproperty^ Mypropertya = gcnew Aproperty;
   Bproperty^ Mypropertyb = gcnew Bproperty;
   Cproperty^ Mypropertyc = gcnew Cproperty;
   Console::Write( "\n1. Mypropertya->Caption = {0}", Mypropertya->Caption );
   Console::Write( "\n1. Mypropertyb->Caption = {0}", Mypropertyb->Caption );
   Console::Write( "\n1. Mypropertyc->Caption = {0}", Mypropertyc->Caption );
   
   // Only Mypropertya can be changed, as Mypropertyb is read-only.
   Mypropertya->Caption = "A- This is changed.";
   Mypropertyb->Caption = "B- This is changed.";
   
   // Note that Mypropertyc is not changed because it is read only
   Console::Write( "\n\n2. Mypropertya->Caption = {0}", Mypropertya->Caption );
   Console::Write( "\n2. Mypropertyb->Caption = {0}", Mypropertyb->Caption );
   Console::Write( "\n2. Mypropertyc->Caption = {0}", Mypropertyc->Caption );
   
   // Get the PropertyAttributes enumeration of the property.
   // Get the type.
   Type^ MyTypea = Type::GetType( "Aproperty" );
   Type^ MyTypeb = Type::GetType( "Bproperty" );
   Type^ MyTypec = Type::GetType( "Cproperty" );

   // Get the property attributes.
   PropertyInfo^ Mypropertyinfoa = MyTypea->GetProperty( "Caption" );
   PropertyAttributes Myattributesa = Mypropertyinfoa->Attributes;
   PropertyInfo^ Mypropertyinfob = MyTypeb->GetProperty( "Item" );
   PropertyAttributes Myattributesb = Mypropertyinfob->Attributes;
   PropertyInfo^ Mypropertyinfoc = MyTypec->GetProperty( "Caption" );
   PropertyAttributes Myattributesc = Mypropertyinfoc->Attributes;

   // Display the property attributes value.
   Console::Write( "\n\na- {0}", Myattributesa );
   Console::Write( "\nb- {0}", Myattributesb );
   Console::Write( "\nc- {0}", Myattributesc );
   return 0;
}

// This example displays the following output to the console
//
// Reflection.PropertyAttributes
//
// 1. Mypropertya.Caption = A Default caption
// 1. Mypropertyb.Caption = B Default caption
// 1. Mypropertyc.Caption = C Default caption
//
// 2. Mypropertya.Caption = A- This is changed.
// 2. Mypropertyb.Caption = B- This is changed.
// 2. Mypropertyc.Caption = C Default caption
//
// a- None
// b- None
// c- None
// </Snippet1>
