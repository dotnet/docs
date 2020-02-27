// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   String^ path = "c:\\temp\\MyTest.txt";
   if ( !File::Exists( path ) )
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
