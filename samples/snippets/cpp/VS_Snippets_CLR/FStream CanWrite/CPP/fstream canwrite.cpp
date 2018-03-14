// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;

int main()
{
   String^ path = "c:\\temp\\MyTest.txt";
   
   // Ensure that the file is readonly.
   File::SetAttributes( path, static_cast<FileAttributes>(File::GetAttributes( path ) | FileAttributes::ReadOnly) );
   
   //Create the file.
   FileStream^ fs = gcnew FileStream( path,FileMode::OpenOrCreate,FileAccess::Read );
   try
   {
      if ( fs->CanWrite )
      {
         Console::WriteLine( "The stream for file {0} is writable.", path );
      }
      else
      {
         Console::WriteLine( "The stream for file {0} is not writable.", path );
      }
   }
   finally
   {
      if ( fs )
         delete (IDisposable^)fs;
   }
}
// </Snippet1>
