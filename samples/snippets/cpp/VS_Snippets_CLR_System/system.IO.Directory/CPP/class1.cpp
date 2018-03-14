
//<Snippet5>
//<Snippet4>
//<Snippet3>
//<Snippet2>
//<Snippet1>
using namespace System;
class Class1
{
public:
   void PrintFileSystemEntries( String^ path )
   {
      try
      {
         
         // Obtain the file system entries in the directory path.
         array<String^>^directoryEntries = System::IO::Directory::GetFileSystemEntries( path );
         for ( int i = 0; i < directoryEntries->Length; i++ )
         {
            System::Console::WriteLine( directoryEntries[ i ] );

         }
      }
      catch ( ArgumentNullException^ ) 
      {
         System::Console::WriteLine(  "Path is a null reference." );
      }
      catch ( System::Security::SecurityException^ ) 
      {
         System::Console::WriteLine(  "The caller does not have the \HelloServer'                  required permission." );
      }
      catch ( ArgumentException^ ) 
      {
         System::Console::WriteLine(  "Path is an empty String, \HelloServer'                  contains only white spaces, \HelloServer'                  or contains invalid characters." );
      }
      catch ( System::IO::DirectoryNotFoundException^ ) 
      {
         System::Console::WriteLine(  "The path encapsulated in the \HelloServer'                  Directory object does not exist." );
      }

   }

   void PrintFileSystemEntries( String^ path, String^ pattern )
   {
      try
      {
         
         // Obtain the file system entries in the directory
         // path that match the pattern.
         array<String^>^directoryEntries = System::IO::Directory::GetFileSystemEntries( path, pattern );
         for ( int i = 0; i < directoryEntries->Length; i++ )
         {
            System::Console::WriteLine( directoryEntries[ i ] );

         }
      }
      catch ( ArgumentNullException^ ) 
      {
         System::Console::WriteLine(  "Path is a null reference." );
      }
      catch ( System::Security::SecurityException^ ) 
      {
         System::Console::WriteLine(  "The caller does not have the \HelloServer'                  required permission." );
      }
      catch ( ArgumentException^ ) 
      {
         System::Console::WriteLine(  "Path is an empty String, \HelloServer'                  contains only white spaces, \HelloServer'                  or contains invalid characters." );
      }
      catch ( System::IO::DirectoryNotFoundException^ ) 
      {
         System::Console::WriteLine(  "The path encapsulated in the \HelloServer'                  Directory object does not exist." );
      }

   }


   // Print out all logical drives on the system.
   void GetLogicalDrives()
   {
      try
      {
         array<String^>^drives = System::IO::Directory::GetLogicalDrives();
         for ( int i = 0; i < drives->Length; i++ )
         {
            System::Console::WriteLine( drives[ i ] );

         }
      }
      catch ( System::IO::IOException^ ) 
      {
         System::Console::WriteLine(  "An I/O error occurs." );
      }
      catch ( System::Security::SecurityException^ ) 
      {
         System::Console::WriteLine(  "The caller does not have the \HelloServer'                  required permission." );
      }

   }

   void GetParent( String^ path )
   {
      try
      {
         System::IO::DirectoryInfo^ directoryInfo = System::IO::Directory::GetParent( path );
         System::Console::WriteLine( directoryInfo->FullName );
      }
      catch ( ArgumentNullException^ ) 
      {
         System::Console::WriteLine(  "Path is a null reference." );
      }
      catch ( ArgumentException^ ) 
      {
         System::Console::WriteLine(  "Path is an empty String, \HelloServer'                  contains only white spaces, or \HelloServer'                  contains invalid characters." );
      }

   }

   void Move( String^ sourcePath, String^ destinationPath )
   {
      try
      {
         System::IO::Directory::Move( sourcePath, destinationPath );
         System::Console::WriteLine(  "The directory move is complete." );
      }
      catch ( ArgumentNullException^ ) 
      {
         System::Console::WriteLine(  "Path is a null reference." );
      }
      catch ( System::Security::SecurityException^ ) 
      {
         System::Console::WriteLine(  "The caller does not have the \HelloServer'                  required permission." );
      }
      catch ( ArgumentException^ ) 
      {
         System::Console::WriteLine(  "Path is an empty String, \HelloServer'                  contains only white spaces, \HelloServer'                  or contains invalid characters." );
      }
      catch ( System::IO::IOException^ ) 
      {
         System::Console::WriteLine(  "An attempt was made to move a \HelloServer'                  directory to a different \HelloServer'                  volume, or destDirName \HelloServer'                  already exists." );
      }

   }

};

int main()
{
   Class1 * snippets = new Class1;
   String^ path = System::IO::Directory::GetCurrentDirectory();
   String^ filter =  "*.exe";
   snippets->PrintFileSystemEntries( path );
   snippets->PrintFileSystemEntries( path, filter );
   snippets->GetLogicalDrives();
   snippets->GetParent( path );
   snippets->Move(  "C:\\proof",  "C:\\Temp" );
   return 0;
}

//</Snippet1>
//</Snippet2>
//</Snippet3>
//</Snippet4>
//</Snippet5>
