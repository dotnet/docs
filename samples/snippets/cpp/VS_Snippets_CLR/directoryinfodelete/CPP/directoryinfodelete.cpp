
// <snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   // Make a reference to a directory.
   DirectoryInfo^ di = gcnew DirectoryInfo( "TempDir" );
   
   // Create the directory only if it does not already exist.
   if (  !di->Exists )
      di->Create();

   
   // Create a subdirectory in the directory just created.
   DirectoryInfo^ dis = di->CreateSubdirectory( "SubDir" );
   
   // Process that directory as required.
   // ...
   // Delete the subdirectory. The true indicates that if subdirectories
   // or files are in this directory, they are to be deleted as well.
   dis->Delete( true );
   
   // Delete the directory.
   di->Delete( true );
}

// </snippet1>
