
// <Snippet1>
using namespace System;
using namespace System::Reflection;

ref class MyClass
{
private:
   String^ myField;

public:
   array<String^>^myArray;
   MyClass()
   {
      myField = "Microsoft";
      array<String^>^s = {"New York","New Jersey"};
      myArray = s;
   }

   property String^ GetField 
   {
      String^ get()
      {
         return myField;
      }
   }
};

int main()
{
   try
   {
      // Gets the type of MyClass.
      Type^ myType = MyClass::typeid;

      // Gets the field information of MyClass.
      array<FieldInfo^>^myFields = myType->GetFields( static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Public | BindingFlags::Instance) );
      Console::WriteLine( "\nDisplaying whether the fields of {0} are private or not:\n", myType );
      for ( int i = 0; i < myFields->Length; i++ )
      {
         // Check whether the field is private or not. 
         if ( myFields[ i ]->IsPrivate )
                  Console::WriteLine( " {0} is a private field.", myFields[ i ]->Name );
         else
                  Console::WriteLine( " {0} is not a private field.", myFields[ i ]->Name );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0} ", e->Message );
   }
}
// </Snippet1>
