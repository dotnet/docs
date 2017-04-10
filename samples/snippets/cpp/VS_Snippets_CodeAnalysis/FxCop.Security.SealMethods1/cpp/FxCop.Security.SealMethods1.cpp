//<Snippet1>
using namespace System;

namespace SecurityLibrary
{
   // Internal by default.
   interface class IValidate
   {
      bool UserIsValidated();
   };

   public ref class BaseImplementation : public IValidate
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
