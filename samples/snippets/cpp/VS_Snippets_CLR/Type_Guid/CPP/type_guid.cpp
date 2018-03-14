
// <Snippet1>
using namespace System;
ref class MyGetTypeFromCLSID
{
public:
   ref class MyClass1
   {
   public:
      void MyMethod1(){}
   };
};

int main()
{
   
   // Get the type corresponding to the class MyClass.
   Type^ myType = MyGetTypeFromCLSID::MyClass1::typeid;
   
   // Get the Object* of the Guid.
   Guid myGuid = (Guid)myType->GUID;
   Console::WriteLine( "The name of the class is {0}", myType );
   Console::WriteLine( "The ClassId of MyClass is {0}", myType->GUID );
}
// </Snippet1>
