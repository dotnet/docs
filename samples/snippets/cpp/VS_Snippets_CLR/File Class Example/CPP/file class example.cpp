// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   String^ path = "c:\\temp\\MyTest.txt";
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
                  delete (IDisposable^)(sw);
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
            delete (IDisposable^)(sr);
   }

   try
   {
      String^ path2 = String::Concat( path, "temp" );
      
      // Ensure that the target does not exist.
      File::Delete( path2 );
      
      // Copy the file.
      File::Copy( path, path2 );
      Console::WriteLine( "{0} was copied to {1}.", path, path2 );
      
      // Delete the newly created file.
      File::Delete( path2 );
      Console::WriteLine( "{0} was successfully deleted.", path2 );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }
}
// </Snippet1>
