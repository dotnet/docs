
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   try
   {
      // Create an instance of StreamReader to read from a file.
      StreamReader^ sr = gcnew StreamReader( "TestFile.txt" );
      try
      {
         String^ line;
         
         // Read and display lines from the file until the end of 
         // the file is reached.
         while ( line = sr->ReadLine() )
         {
            Console::WriteLine( line );
         }
      }
      finally
      {
         if ( sr )
            delete (IDisposable^)sr;
      }
   }
   catch ( Exception^ e ) 
   {
      // Let the user know what went wrong.
      Console::WriteLine( "The file could not be read:" );
      Console::WriteLine( e->Message );
   }
}
// </Snippet1>
