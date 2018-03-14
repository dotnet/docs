
// <snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   // Make a reference to a directory.
   DirectoryInfo^ di = gcnew DirectoryInfo( "c:\\" );
   
   // Get a reference to each file in that directory.
   array<FileInfo^>^fiArr = di->GetFiles();
   
   // Display the names of the files.
   Collections::IEnumerator^ myEnum = fiArr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      FileInfo^ fri = safe_cast<FileInfo^>(myEnum->Current);
      Console::WriteLine( fri->Name );
   }
}

// </snippet1>
