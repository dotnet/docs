#using <System.DLL>

using namespace System;

ref class Sample
{
private:
   void Method()
   {
      // <Snippet1>
      String^ str = "BBQ and Slaw";
      Console::WriteLine( str->PadLeft( 15 ) ); // Displays "   BBQ and Slaw".
      Console::WriteLine( str->PadLeft( 5 ) );  // Displays "BBQ and Slaw".
      // </Snippet1>
   }
};
