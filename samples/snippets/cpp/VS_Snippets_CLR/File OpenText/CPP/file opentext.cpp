// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;
int main()
{
   String^ path = "c:\\temp\\MyTest.txt";
   
   if ( !File::Exists( path ) )
   {
      // Create the file.
      FileStream^ fs = File::Create( path );
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
