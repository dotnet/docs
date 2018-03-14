// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Globalization;

public ref class Example
{
private:
   String^ myString;

public:
   Example()
   {
      myString = "Old value";
   }

   property String^ StringProperty 
   {
      String^ get()
      {
         return myString;
      }
   }
};

int main()
{
    Example^ myObject = gcnew Example;
    Type^ myType = Example::typeid;
    FieldInfo^ myFieldInfo = myType->GetField( "myString", 
        BindingFlags::NonPublic | BindingFlags::Instance);
      
    // Display the string before applying SetValue to the field.
    Console::WriteLine( "\nThe field value of myString is \"{0}\".", 
        myFieldInfo->GetValue( myObject ) );
    // Display the SetValue signature used to set the value of a field.
    Console::WriteLine( "Applying SetValue(Object, Object)." );

    // Change the field value using the SetValue method. 
    myFieldInfo->SetValue( myObject, "New value" );     
    // Display the string after applying SetValue to the field.
    Console::WriteLine( "The field value of mystring is \"{0}\".", 
        myFieldInfo->GetValue(myObject));
}
/* This code produces the following output:

The field value of myString is "Old value".
Applying SetValue(Object, Object).
The field value of mystring is "New value".
 */
// </Snippet1>
