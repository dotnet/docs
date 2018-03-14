
//<snippet1>
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
   
   // Move the main directory. Note that the contents move with the directory.
   if (  !Directory::Exists( "NewTempDir" ) )
      di->MoveTo( "NewTempDir" );

   try
   {
      
      // Attempt to delete the subdirectory. Note that because it has been
      // moved, an exception is thrown.
      dis->Delete( true );
   }
   catch ( Exception^ ) 
   {
      
      // Handle this exception in some way, such as with the following code:
      // Console::WriteLine(S"That directory does not exist.");
   }

   
   // Point the DirectoryInfo reference to the new directory.
   //di = new DirectoryInfo(S"NewTempDir");
   // Delete the directory.
   //di->Delete(true);
}

// </snippet1>
