#using <system.dll>

using namespace System;
using namespace System::ComponentModel;

namespace WarningEx
{
   public ref class WarningEx_Doc
   {
   public:
      static void Main()
      {
         //<snippet1>
         WarningException^ myEx = gcnew WarningException( "This is a warning" );
         Console::WriteLine( myEx->Message );
         Console::WriteLine( myEx->ToString() );
         //</snippet1>
      }
   };
}

int main()
{
   WarningEx::WarningEx_Doc::Main();
}
