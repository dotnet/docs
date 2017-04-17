// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   String^ path = "c:\\MyTest.txt";
   FileInfo^ fi = gcnew FileInfo( path );
   
   // Delete the file if it exists.
   if (  !fi->Exists )
   {
      //Create the file.
      FileStream^ fs = fi->Create();
      try
      {
         array<Byte>^info = (gcnew UTF8Encoding( true ))->GetBytes( "This is some text in the file." );
         
         //Add some information to the file.
         fs->Write( info, 0, info->Length );
      }
      finally
      {
         if ( fs )
            delete (IDisposable^)fs;
      }
   }

   //Open the stream and read it back.
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
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//This is some text in the file.
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
//
// </Snippet1>
