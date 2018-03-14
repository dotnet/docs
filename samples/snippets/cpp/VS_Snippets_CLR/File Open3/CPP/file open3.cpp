// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   String^ path = "c:\\temp\\MyTest.txt";
   
   // Create the file if it does not exist.
   if (  !File::Exists( path ) )
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
   FileStream^ fs = File::Open( path, FileMode::Open, FileAccess::Read, FileShare::None );
   try
   {
      array<Byte>^b = gcnew array<Byte>(1024);
      UTF8Encoding^ temp = gcnew UTF8Encoding( true );
      while ( fs->Read( b, 0, b->Length ) > 0 )
      {
         Console::WriteLine( temp->GetString( b ) );
      }
      try
      {
         // Try to get another handle to the same file.
         FileStream^ fs2 = File::Open( path, FileMode::Open );
         try
         {
            // Do some task here.
         }
         finally
         {
            if ( fs2 )
                        delete (IDisposable^)fs2;
         }
      }
      catch ( Exception^ e ) 
      {
         Console::Write( "Opening the file twice is disallowed." );
         Console::WriteLine( ", as expected: {0}", e );
      }
   }
   finally
   {
      if ( fs )
            delete (IDisposable^)fs;
   }
}
// </Snippet1>
