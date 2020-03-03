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
   void MyMethod( int i ){}
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
         // Display the attribute if it is of type MyAttribute.
         if ( myMembers[ i ]->IsDefined( MyAttribute::typeid, false ) )
         {
            array<Object^>^myAttributes = myMembers[ i ]->GetCustomAttributes( MyAttribute::typeid, false );
            Console::WriteLine( "\nThe attributes of type MyAttribute for the member {0} are: \n", myMembers[ i ] );
            for ( int j = 0; j < myAttributes->Length; j++ )

               // Display the value associated with the attribute.
               Console::WriteLine( "The value of the attribute is : \"{0}\"",
                        (safe_cast<MyAttribute^>(myAttributes[ j ]))->Name );
         }
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "An exception occurred: {0}", e->Message );
   }
}
// </Snippet1>
