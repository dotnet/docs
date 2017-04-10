
// <snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   // Open an existing file, or create a new one.
   FileInfo^ fi = gcnew FileInfo( "temp.txt" );
   
   // Determine the full path of the file just created.
   DirectoryInfo^ di = fi->Directory;
   
   // Figure out what other entries are in that directory.
   array<FileSystemInfo^>^fsi = di->GetFileSystemInfos();
   Console::WriteLine( "The directory '{0}' contains the following files and directories:", di->FullName );
   
   // Print the names of all the files and subdirectories of that directory.
   Collections::IEnumerator^ myEnum = fsi->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      FileSystemInfo^ info = safe_cast<FileSystemInfo^>(myEnum->Current);
      Console::WriteLine( info->Name );
   }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//The directory 'C:\Visual Studio 2005\release' contains the following files 
//and directories:
//fileinfodirectory.exe
//fileinfodirectory.pdb
//newTemp.txt
//
// </snippet1>
