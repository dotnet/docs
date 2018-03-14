// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   String^ path = "c:\\temp\\MyTest.txt";
   
   // Delete the file if it exists.
   if ( File::Exists( path ) )
   {
      File::Delete( path );
   }
   
   // Create the file.
   FileStream^ fs = File::Create( path, 1024 );
   try
   {
      array<Byte>^info = (gcnew UTF8Encoding( true ))->GetBytes( "This is some text in the file." );
      
      // Add some information to the file.
      fs->Write( info, 0, info->Length );
   }
   finally
   {
      if ( fs )
            delete (IDisposable^)fs;
   }

   // Open the stream and read it back.
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
