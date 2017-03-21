using namespace System;
using namespace System::Reflection;

// Define a property.
public ref class Myproperty
{
private:
   String^ caption;

public:
   Myproperty()
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

int main()
{
   Console::WriteLine( "\nReflection.PropertyInfo" );
   
   // Get the type and PropertyInfo.
   Type^ MyType = Type::GetType( "Myproperty" );
   PropertyInfo^ Mypropertyinfo = MyType->GetProperty( "Caption" );
   
   // Get the public GetAccessors method.
   array<MethodInfo^>^Mymethodinfoarray = Mypropertyinfo->GetAccessors( true );
   Console::Write( "\nThere are {0} accessors (public).", Mymethodinfoarray->Length );
   return 0;
}
