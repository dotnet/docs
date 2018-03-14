#using <System.DLL>

using namespace System;
ref class Sample
{
private:
   void Method()
   {
      
      // <Snippet1>
      String^ str = "BBQ and Slaw";
      Console::Write( "|" );
      Console::Write( str->PadRight( 15 ) );
      Console::WriteLine( "|" ); // Displays "|BBQ and Slaw   |".
      Console::Write( "|" );
      Console::Write( str->PadRight( 5 ) );
      Console::WriteLine( "|" ); // Displays "|BBQ and Slaw|".
      // </Snippet1>
   }
};
