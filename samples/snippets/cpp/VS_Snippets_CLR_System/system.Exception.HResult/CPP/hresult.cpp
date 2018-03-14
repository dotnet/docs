
//<Snippet1>
// Example for the Exception::HResult property.
using namespace System;

namespace NDP_UE_CPP
{

   // Create the derived exception class.
   ref class SecondLevelException: public Exception
   {
   private:
      static int SecondLevelHResult = (int)0x81234567;

   public:

      // Set HResult for this exception, and include it in 
      // the exception message.
      SecondLevelException( String^ message, Exception^ inner )
         : Exception( String::Format( "(HRESULT:0x{1:X8}) {0}", message, SecondLevelHResult ), inner )
      {
         HResult = SecondLevelHResult;
      }

   };


   // This function forces a division by 0 and throws 
   // a second exception.
   void DivideBy0()
   {
      try
      {
         try
         {
            int zero = 0;
            int ecks = 1 / zero;
         }
         catch ( Exception^ ex ) 
         {
            throw gcnew SecondLevelException( "Forced a division by 0 and threw "
            "a second exception.",ex );
         }

      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( ex->ToString() );
      }

   }

}

int main()
{
   Console::WriteLine( "This example of Exception::HResult "
   "generates the following output.\n" );
   NDP_UE_CPP::DivideBy0();
}

/*
This example of Exception::HResult generates the following output.

NDP_UE_CPP.SecondLevelException: (HRESULT:0x81234567) Forced a division by 0 an
d threw a second exception. ---> System.DivideByZeroException: Attempted to div
ide by zero.
   at NDP_UE_CPP.DivideBy0()
   --- End of inner exception stack trace ---
   at NDP_UE_CPP.DivideBy0()
*/
//</Snippet1>
