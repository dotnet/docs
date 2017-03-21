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