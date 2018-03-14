// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   String^ path = "c:\\MyTest.txt";
   FileInfo^ fi = gcnew FileInfo( path );
   
   // Delete the file if it exists.
   if ( fi->Exists )
   {
      fi->Delete();
   }
   
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

   //Open the stream and read it back.
   StreamReader^ sr = fi->OpenText();
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

//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//This is some text in the file.
// </Snippet1>
