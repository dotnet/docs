
// <Snippet1>
using namespace System;
using namespace System::Reflection;
ref class MyClass1
{
private:
   String^ myMessage;

public:

   property String^ MyProperty1 
   {
      String^ get()
      {
         return myMessage;
      }

      void set( String^ value )
      {
         myMessage = value;
      }
   }
};

int main()
{
   try
   {
      Type^ myType = MyClass1::typeid;
      
      // Get the PropertyInfo Object* representing MyProperty1.
      PropertyInfo^ myStringProperties1 = myType->GetProperty( "MyProperty1", String::typeid );
      Console::WriteLine( "The name of the first property of MyClass1 is {0}.", myStringProperties1->Name );
      Console::WriteLine( "The type of the first property of MyClass1 is {0}.", myStringProperties1->PropertyType );
   }
   catch ( ArgumentNullException^ e ) 
   {
      Console::WriteLine( "ArgumentNullException : {0}", e->Message );
   }
   catch ( AmbiguousMatchException^ e ) 
   {
      Console::WriteLine( "AmbiguousMatchException : {0}", e->Message );
   }
   catch ( NullReferenceException^ e ) 
   {
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   //Output:
   //The name of the first property of MyClass1 is MyProperty1.
   //The type of the first property of MyClass1 is System.String.

}
// </Snippet1>
