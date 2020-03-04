//<Snippet1>
using namespace System;

namespace SecurityLibrary
{
   public ref class BaseImplementation
   {
   public:
      virtual bool UserIsValidated()
      {
         return false;
      }
   };

   public ref class UseBaseImplementation
   {
   public:
      void SecurityDecision(BaseImplementation^ someImplementation)
      {
         if(someImplementation->UserIsValidated() == true)
         {
            Console::WriteLine("Account number & balance.");
         }
         else
         {
            Console::WriteLine("Please login.");
         }
      }
   };
}
//</Snippet1>
