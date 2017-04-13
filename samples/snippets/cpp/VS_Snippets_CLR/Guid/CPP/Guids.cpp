
//<Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;

// Guid for the interface IMyInterface.
[Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")]
public interface class IMyInterface
{
public:
   void MyMethod();
};


// Guid for the coclass MyTestClass.
[Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8")]
public ref class MyTestClass: public IMyInterface
{
public:
   virtual void MyMethod(){}
};

int main()
{
   Attribute^ IMyInterfaceAttribute = Attribute::GetCustomAttribute( IMyInterface::typeid, GuidAttribute::typeid );

   // The Value property of GuidAttribute returns a string. 
   System::Console::WriteLine( String::Concat(  "IMyInterface Attribute: ", (dynamic_cast<GuidAttribute^>(IMyInterfaceAttribute))->Value ) );

   // Using the string to create a guid.
   Guid myGuid1 = Guid(dynamic_cast<GuidAttribute^>(IMyInterfaceAttribute)->Value);

   // Using a byte array to create a guid.
   Guid myGuid2 = Guid(myGuid1.ToByteArray());

   // Equals is overridden to perform a value comparison.
   if ( myGuid1.Equals( myGuid2 ) )
      System::Console::WriteLine(  "myGuid1 equals myGuid2" );
   else
      System::Console::WriteLine(  "myGuid1 not equals myGuid2" );

   // Equality operator can also be used to determine if two guids have same value.
   if ( myGuid1 == myGuid2 )
      System::Console::WriteLine(  "myGuid1 == myGuid2" );
   else
      System::Console::WriteLine(  "myGuid1 != myGuid2" );
}
// The example displays the following output:
//       IMyInterface Attribute: F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4
//       myGuid1 equals myGuid2
//       myGuid1 == myGuid2
// </Snippet1>
