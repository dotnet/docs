// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   String^ path = "c:\\temp\\MyTest.txt";

   // Open the stream and write to it.
   {
      FileStream^ fs = File::OpenWrite( path );
      try
      {
         array<Byte>^info = (gcnew UTF8Encoding( true ))->
            GetBytes( "This is to test the OpenWrite method." );

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
      FileStream^ fs = File::OpenRead( path );
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
            delete(IDisposable^)fs;
      }
   }
}
// </Snippet1>
