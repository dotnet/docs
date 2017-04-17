// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   // Create a temporary file, and put some data into it.
   String^ path = Path::GetTempFileName();
   FileStream^ fs = File::Open( path, FileMode::Open, FileAccess::Write, FileShare::None );
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
   fs = File::Open( path, FileMode::Open );
   try
   {
      array<Byte>^b = gcnew array<Byte>(1024);
      UTF8Encoding^ temp = gcnew UTF8Encoding( true );
      while ( fs->Read( b, 0, b->Length ) > 0 )
      {
         Console::WriteLine( temp->GetString( b ) );
      }
   }
   finally
   {
      if ( fs )
            delete (IDisposable^)fs;
   }
}
// </Snippet1>
