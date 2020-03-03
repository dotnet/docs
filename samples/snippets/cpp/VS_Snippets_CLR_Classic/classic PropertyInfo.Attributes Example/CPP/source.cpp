
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class Myproperty
{
private:
   String^ caption;

public:
   Myproperty()
      : caption( "Default caption" )
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

int main()
{
   Console::WriteLine( "\nReflection.PropertyInfo" );
   
   // Define a property.
   Myproperty^ myproperty = gcnew Myproperty;
   Console::Write( "\nMyproperty->Caption = {0}", myproperty->Caption );
   
   // Get the type and PropertyInfo.
   Type^ MyType = Type::GetType( "Myproperty" );
   PropertyInfo^ Mypropertyinfo = MyType->GetProperty( "Caption" );
   
   // Get and display the attributes property.
   PropertyAttributes Myattributes = Mypropertyinfo->Attributes;
   Console::Write( "\nPropertyAttributes - {0}", Myattributes );
   return 0;
}
// The example displays the following output:
//       Reflection.PropertyInfo
//
//       Myproperty.Caption = Default caption
//       PropertyAttributes - None
// </Snippet1>
