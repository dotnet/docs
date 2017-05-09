
using namespace System;
// <Snippet1>
using namespace System::Runtime::InteropServices;

[ComVisible(false)]
ref class MyClass
{
private:
   int myProperty;

public:
   MyClass()
   {
      
      //Insert code here.
   }


   [ComVisible(false)]
   int MyMethod( String^ param )
   {
      return 0;
   }

   bool MyOtherMethod()
   {
      return true;
   }


   property int MyProperty 
   {

      [ComVisible(false)]
      int get()
      {
         return myProperty;
      }

   }

};

// </Snippet1>
