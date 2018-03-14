
// <snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   // Make a reference to a directory.
   DirectoryInfo^ di = gcnew DirectoryInfo( "c:\\" );
   
   // Get a reference to each directory in that directory.
   array<DirectoryInfo^>^diArr = di->GetDirectories();
   
   // Display the names of the directories.
   Collections::IEnumerator^ myEnum = diArr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      DirectoryInfo^ dri = safe_cast<DirectoryInfo^>(myEnum->Current);
      Console::WriteLine( dri->Name );
   }
}

// </snippet1>
