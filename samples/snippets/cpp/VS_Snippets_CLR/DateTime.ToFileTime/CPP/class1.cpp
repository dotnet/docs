
using namespace System;

//<Snippet1>
int main()
{
   System::Console::WriteLine( "Enter the file path:" );
   String^ filePath = System::Console::ReadLine();
   if ( System::IO::File::Exists( filePath ) )
   {
      System::DateTime fileCreationDateTime = System::IO::File::GetCreationTime( filePath );
      __int64 fileCreationFileTime = fileCreationDateTime.ToFileTime();
      System::Console::WriteLine( "{0} in file time is {1}.", fileCreationDateTime, fileCreationFileTime );
   }
   else
   {
      System::Console::WriteLine( "{0} is an invalid file", filePath );
   }
}

//</Snippet1>
