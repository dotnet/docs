#using <system.dll>
#using <system.design.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::ComponentModel::Design::Serialization;

namespace CodeDomSerializerExceptionExample
{
   ref class CodeDomSerializerExceptionExample
   {
   private:
      [STAThread]
      static void Main()
      {
         //<Snippet1>
         throw gcnew CodeDomSerializerException( "This exception was raised as an example.", gcnew CodeLinePragma( "Example.txt", 20 ) );
         //</Snippet1>
      }
   };
}
