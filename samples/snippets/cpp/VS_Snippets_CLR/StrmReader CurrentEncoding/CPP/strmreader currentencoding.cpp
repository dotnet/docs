// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   String^ path = "c:\\temp\\MyTest.txt";
   try
   {
      if ( File::Exists( path ) )
      {
         File::Delete( path );
      }

      //Use an encoding other than the default (UTF8).
      StreamWriter^ sw = gcnew StreamWriter( path,false,gcnew UnicodeEncoding );
      try
      {
         sw->WriteLine( "This" );
         sw->WriteLine( "is some text" );
         sw->WriteLine( "to test" );
         sw->WriteLine( "Reading" );
      }
      finally
      {
         delete sw;
      }

      StreamReader^ sr = gcnew StreamReader( path,true );
      try
      {
         while ( sr->Peek() >= 0 )
         {
            Console::Write( (Char)sr->Read() );
         }

         //Test for the encoding after reading, or at least
         //after the first read.
         Console::WriteLine( "The encoding used was {0}.", sr->CurrentEncoding );
         Console::WriteLine();
      }
      finally
      {
         delete sr;
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }
}
// </Snippet1>
