
// <Snippet1>
using namespace System;
using namespace System::Reflection;
ref class MyClass
{
private:
   int myProperty;

public:

   property int MyProperty 
   {
      // Declare MyProperty.
      int get()
      {
         return myProperty;
      }

      void set( int value )
      {
         myProperty = value;
      }
   }
};

int main()
{
   try
   {
      // Get the Type object corresponding to MyClass.
      Type^ myType = MyClass::typeid;
      
      // Get the PropertyInfo object by passing the property name.
      PropertyInfo^ myPropInfo = myType->GetProperty( "MyProperty" );
      
      // Display the property name.
      Console::WriteLine( "The {0} property exists in MyClass.", myPropInfo->Name );
   }
   catch ( NullReferenceException^ e ) 
   {
      Console::WriteLine( "The property does not exist in MyClass. {0}", e->Message );
   }
}
// </Snippet1>
