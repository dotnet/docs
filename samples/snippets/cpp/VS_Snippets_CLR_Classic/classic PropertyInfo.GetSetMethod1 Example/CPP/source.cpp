
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Define a property.
public ref class Myproperty
{
private:
   String^ caption;

public:

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
   
   // Get the type and PropertyInfo for two separate properties.
   Type^ MyTypea = Type::GetType( "Myproperty" );
   PropertyInfo^ Mypropertyinfoa = MyTypea->GetProperty( "Caption" );
   Type^ MyTypeb = Type::GetType( "System.Text.StringBuilder" );
   PropertyInfo^ Mypropertyinfob = MyTypeb->GetProperty( "Length" );
   
   // Get and display the GetSetMethod method for each property.
   MethodInfo^ Mygetmethodinfoa = Mypropertyinfoa->GetSetMethod();
   Console::Write( "\nSetAccessor for {0} returns a {1}", Mypropertyinfoa->Name, Mygetmethodinfoa->ReturnType );
   MethodInfo^ Mygetmethodinfob = Mypropertyinfob->GetSetMethod();
   Console::Write( "\nSetAccessor for {0} returns a {1}", Mypropertyinfob->Name, Mygetmethodinfob->ReturnType );
   
   // Display the GetSetMethod without using the MethodInfo.
   Console::Write( "\n\n{0}.{1} GetSetMethod - {2}", MyTypea->FullName, Mypropertyinfoa->Name, Mypropertyinfoa->GetSetMethod() );
   Console::Write( "\n{0}.{1} GetSetMethod - {2}", MyTypeb->FullName, Mypropertyinfob->Name, Mypropertyinfob->GetSetMethod() );
   return 0;
}

// </Snippet1>
