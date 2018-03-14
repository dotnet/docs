// <Snippet1>
using namespace System;
using namespace System::IO;

int main()
{
   String^ path = "c:\\temp\\MyTest.txt";
   
   // This text is added only once to the file.
   if (  !File::Exists( path ) )
   {
      // Create a file to write to.
      StreamWriter^ sw = File::CreateText( path );
      try
      {
         sw->WriteLine( "Hello" );
         sw->WriteLine( "And" );
         sw->WriteLine( "Welcome" );
      }
      finally
      {
         if ( sw )
            delete (IDisposable^)sw;
      }
   }
   
   // This text is always added, making the file longer over time
   // if it is not deleted.
   StreamWriter^ sw = File::AppendText( path );
   try
   {
      sw->WriteLine( "This" );
      sw->WriteLine( "is Extra" );
      sw->WriteLine( "Text" );
   }
   finally
   {
      if ( sw )
         delete (IDisposable^)sw;
   }
   
   // Open the file to read from.
   StreamReader^ sr = File::OpenText( path );
   try
   {
      String^ s = "";
      while ( s = sr->ReadLine() )
      {
         Console::WriteLine( s );
      }
   }
   finally
   {
      if ( sr )
         delete (IDisposable^)sr;
   }
}
// </Snippet1>
