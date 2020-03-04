
// <Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;
public ref class MyClassThatNeedsToRegister
{
public:

   [ComRegisterFunctionAttribute]
   static void RegisterFunction( Type^ t )
   {
      
      //Insert code here.
   }


   [ComUnregisterFunctionAttribute]
   static void UnregisterFunction( Type^ t )
   {
      
      //Insert code here.
   }

};

// </Snippet1>
