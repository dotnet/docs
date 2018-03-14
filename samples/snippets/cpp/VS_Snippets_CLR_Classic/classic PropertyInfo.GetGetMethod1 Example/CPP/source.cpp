
// <Snippet1>
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
   
   // Get the type and PropertyInfo for two separate properties.
   Type^ MyTypea = Type::GetType( "Myproperty" );
   PropertyInfo^ Mypropertyinfoa = MyTypea->GetProperty( "Caption" );
   Type^ MyTypeb = Type::GetType( "System.Reflection.MethodInfo" );
   PropertyInfo^ Mypropertyinfob = MyTypeb->GetProperty( "MemberType" );
   
   // Get and display the GetGetMethod method for each property.
   MethodInfo^ Mygetmethodinfoa = Mypropertyinfoa->GetGetMethod();
   Console::Write( "\nGetAccessor for {0} returns a {1}", Mypropertyinfoa->Name, Mygetmethodinfoa->ReturnType );
   MethodInfo^ Mygetmethodinfob = Mypropertyinfob->GetGetMethod();
   Console::Write( "\nGetAccessor for {0} returns a {1}", Mypropertyinfob->Name, Mygetmethodinfob->ReturnType );
   
   // Display the GetGetMethod without using the MethodInfo.
   Console::Write( "\n{0}.{1} GetGetMethod - {2}", MyTypea->FullName, Mypropertyinfoa->Name, Mypropertyinfoa->GetGetMethod() );
   Console::Write( "\n{0}.{1} GetGetMethod - {2}", MyTypeb->FullName, Mypropertyinfob->Name, Mypropertyinfob->GetGetMethod() );
   return 0;
}

// </Snippet1>
