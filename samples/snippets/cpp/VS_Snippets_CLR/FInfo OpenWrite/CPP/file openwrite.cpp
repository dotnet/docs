// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   String^ path = "c:\\Temp\\MyTest.txt";
   FileInfo^ fi = gcnew FileInfo( path );

   // Open the stream for writing.
   {
      FileStream^ fs = fi->OpenWrite();
      try
      {
         array<Byte>^info = (gcnew UTF8Encoding( true ))->GetBytes( "This is to test the OpenWrite method." );
         
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
   {
      FileStream^ fs = fi->OpenRead();
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
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//This is to test the OpenWrite method.
//
//
//
//
//
//
//
//
//
//
//
//
// </Snippet1>
