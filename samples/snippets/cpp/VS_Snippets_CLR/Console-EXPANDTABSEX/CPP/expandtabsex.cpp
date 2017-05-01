

// This sample takes a given input and replaces each
// occurence of the tab character with 4 space characters.
// It also takes two command-line arguements: input file name, & output file name.
// Usage:
//  EXPANDTABS inputfile.txt outputfile.txt
// System.Console.Read
// System.Console.WriteLine
// System.Console.Write
// System.Console.SetIn
// System.Console.SetOut
// System.Console.Error
// System.Console.Out
// <Snippet1>
using namespace System;
using namespace System::IO;

void main()
{
   const int tabSize = 4;
   array<String^>^args = Environment::GetCommandLineArgs();
   String^ usageText = "Usage: EXPANDTABSEX inputfile.txt outputfile.txt";
   StreamWriter^ writer = nullptr;
   
   if ( args->Length < 3 )
   {
      Console::WriteLine( usageText );
      return;
   }

   try
   {
      writer = gcnew StreamWriter( args[ 2 ] );
      Console::SetOut( writer );
      Console::SetIn( gcnew StreamReader( args[ 1 ] ) );
   }
   catch ( IOException^ e ) 
   {
      TextWriter^ errorWriter = Console::Error;
      errorWriter->WriteLine( e->Message );
      errorWriter->WriteLine( usageText );
      return;
   }

   int i;
   while ( (i = Console::Read()) != -1 )
   {
      Char c = (Char)i;
      if ( c == '\t' )
            Console::Write( ((String^)"")->PadRight( tabSize, ' ' ) );
      else
            Console::Write( c );
   }

   writer->Close();
   
   // Recover the standard output stream so that a 
   // completion message can be displayed.
   StreamWriter^ standardOutput = gcnew StreamWriter(Console::OpenStandardOutput());
   standardOutput->AutoFlush = true;
   Console::SetOut(standardOutput);
   Console::WriteLine( "EXPANDTABSEX has completed the processing of {0}.", args[ 0 ] );
   return;
}
// </Snippet1>
