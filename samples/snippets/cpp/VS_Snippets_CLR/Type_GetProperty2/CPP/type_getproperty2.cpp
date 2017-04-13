
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
      // Get Type object of MyClass.
      Type^ myType = MyClass::typeid;
      
      // Get the PropertyInfo by passing the property name and specifying the BindingFlags.
      PropertyInfo^ myPropInfo = myType->GetProperty( "MyProperty", static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance) );
      
      // Display Name propety to console.
      Console::WriteLine( "{0} is a property of MyClass.", myPropInfo->Name );
   }
   catch ( NullReferenceException^ e ) 
   {
      Console::WriteLine( "MyProperty does not exist in MyClass. {0}", e->Message );
   }
}
// </Snippet1>
