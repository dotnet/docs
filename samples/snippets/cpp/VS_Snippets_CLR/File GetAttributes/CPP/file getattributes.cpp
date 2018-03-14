
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
      File::Create( path );
   }

   if ( (File::GetAttributes( path ) & FileAttributes::Hidden) == FileAttributes::Hidden )
   {
      
      // Show the file.
      File::SetAttributes(path, File::GetAttributes( path ) & ~FileAttributes::Hidden);
      Console::WriteLine( "The {0} file is no longer hidden.", path );
   }
   else
   {
      
      // Hide the file.
      File::SetAttributes( path, static_cast<FileAttributes>(File::GetAttributes( path ) | FileAttributes::Hidden) );
      Console::WriteLine( "The {0} file is now hidden.", path );
   }
}

// </Snippet1>
