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
   FileStream^ fs = fi->Open( FileMode::Open, FileAccess::Read );
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
         //Try to write to the file.
         fs->Write( b, 0, b->Length );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Writing was disallowed, as expected: {0}", e );
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
//Writing was disallowed, as expected: System.NotSupportedException: Stream does 
//not support writing.
//   at System.IO.__Error.WriteNotSupported()
//   at System.IO.FileStream.Write(Byte[] array, Int32 offset, Int32 count)
//   at main() in c:\documents and settings\MyComputer\my documents\
//visual studio 2005\projects\finfo open2\finfo open2\
//cpp_console_application.cpp:line 46
// </Snippet1>
