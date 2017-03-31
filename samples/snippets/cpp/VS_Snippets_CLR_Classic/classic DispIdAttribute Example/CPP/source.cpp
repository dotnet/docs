
// <Snippet1>
using namespace System::Runtime::InteropServices;
public ref class MyClass
{
public:
   MyClass(){}


   [DispId(8)]
   void MyMethod(){}

   int MyOtherMethod()
   {
      return 0;
   }


   [DispId(9)]
   bool MyField;
};

// </Snippet1>
