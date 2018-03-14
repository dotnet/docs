
// <snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   // Create a reference to the current directory.
   DirectoryInfo^ di = gcnew DirectoryInfo( Environment::CurrentDirectory );
   
   // Create an array representing the files in the current directory.
   array<FileInfo^>^fi = di->GetFiles();
   Console::WriteLine( "The following files exist in the current directory:" );
   
   // Print out the names of the files in the current directory.
   Collections::IEnumerator^ myEnum = fi->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      FileInfo^ fiTemp = safe_cast<FileInfo^>(myEnum->Current);
      Console::WriteLine( fiTemp->Name );
   }
}

//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//The following files exist in the current directory:
//fileinfoname.exe
//fileinfoname.pdb
//newTemp.txt
// </snippet1>
