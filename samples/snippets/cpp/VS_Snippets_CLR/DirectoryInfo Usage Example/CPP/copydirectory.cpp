
// <snippet1>
using namespace System;
using namespace System::IO;

// Copy a source directory to a target directory.
void CopyDirectory( String^ SourceDirectory, String^ TargetDirectory )
{
   DirectoryInfo^ source = gcnew DirectoryInfo( SourceDirectory );
   DirectoryInfo^ target = gcnew DirectoryInfo( TargetDirectory );
   
   //Determine whether the source directory exists.
   if (  !source->Exists )
      return;

   if (  !target->Exists )
      target->Create();

   
   //Copy files.
   array<FileInfo^>^sourceFiles = source->GetFiles();
   for ( int i = 0; i < sourceFiles->Length; ++i )
      File::Copy( sourceFiles[ i ]->FullName, String::Concat( target->FullName, "\\", sourceFiles[ i ]->Name ), true );
   
   //Copy directories.
   array<DirectoryInfo^>^sourceDirectories = source->GetDirectories();
   for ( int j = 0; j < sourceDirectories->Length; ++j )
      CopyDirectory( sourceDirectories[ j ]->FullName, String::Concat( target->FullName, "\\", sourceDirectories[ j ]->Name ) );
}

int main()
{
   CopyDirectory( "D:\\Tools", "D:\\NewTools" );
}

// </snippet1>
