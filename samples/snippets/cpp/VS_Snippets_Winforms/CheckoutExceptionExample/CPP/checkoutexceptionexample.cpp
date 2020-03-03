#using <system.dll>

using namespace System;
using namespace System::ComponentModel::Design;

namespace MiscCompModSamples
{
   public ref class CheckoutExceptionExample
   {
   public:
      CheckoutExceptionExample()
      {
         //<Snippet1>
         // Throws a checkout exception with a message and error code.
         throw gcnew CheckoutException( "This is an example exception", 0 );
         //</Snippet1>
      }
   };
}
