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

   //Create the file.
   FileStream^ fs = File::Create( path );
   try
   {
      if ( fs->CanSeek )
      {
         Console::WriteLine( "The stream connected to {0} is seekable.", path );
      }
      else
      {
         Console::WriteLine( "The stream connected to {0} is not seekable.", path );
      }
   }
   finally
   {
      if ( fs )
         delete (IDisposable^)fs;
   }
}
// </Snippet1>
