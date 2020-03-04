// <Snippet1>
using namespace System;
using namespace System::Reflection;

// Define a custom attribute with one named parameter.

[AttributeUsage(AttributeTargets::All)]
public ref class MyAttribute: public Attribute
{
private:
   String^ myName;

public:
   MyAttribute( String^ name )
   {
      myName = name;
   }

   property String^ Name 
   {
      String^ get()
      {
         return myName;
      }
   }
};

// Define a class that has the custom attribute associated with one of its members.
public ref class MyClass1
{
public:

   [MyAttribute("This is an example attribute.")]
   void MyMethod( int i )
   {
      return;
   }
};

int main()
{
   try
   {
      // Get the type of MyClass1.
      Type^ myType = MyClass1::typeid;

      // Get the members associated with MyClass1.
      array<MemberInfo^>^myMembers = myType->GetMembers();

      // Display the attributes for each of the members of MyClass1.
      for ( int i = 0; i < myMembers->Length; i++ )
      {
         array<Object^>^myAttributes = myMembers[ i ]->GetCustomAttributes( true );
         if ( myAttributes->Length > 0 )
         {
            Console::WriteLine( "\nThe attributes for the member {0} are: \n", myMembers[ i ] );
            for ( int j = 0; j < myAttributes->Length; j++ )
               Console::WriteLine( "The type of the attribute is {0}.", myAttributes[ j ] );
         }
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "An exception occurred: {0}", e->Message );
   }
}
// </Snippet1>
