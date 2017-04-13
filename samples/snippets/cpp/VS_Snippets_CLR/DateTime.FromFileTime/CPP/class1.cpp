using namespace System;
using namespace System::IO;

// This function takes a file's creation time as an unsigned long,
// and returns its age.
//<Snippet1>
System::TimeSpan FileAge( long fileCreationTime )
{
   System::DateTime now = System::DateTime::Now;
   try
   {
      System::DateTime fCreationTime =
         System::DateTime::FromFileTime( fileCreationTime );
      System::TimeSpan fileAge = now.Subtract( fCreationTime );
      return fileAge;
   }
   catch ( ArgumentOutOfRangeException^ ) 
   {
      // fileCreationTime is not valid, so re-throw the exception.
      throw;
   }
}
//</Snippet1>

void main()
{
   System::Console::WriteLine( "Enter a file's path" );
   String^ filePath = System::Console::ReadLine();
   System::IO::FileInfo^ fInfo;
   try
   {
      fInfo = gcnew System::IO::FileInfo( filePath );
   }
   catch ( Exception^ ) 
   {
      System::Console::WriteLine( "Error opening {0}", filePath );
      return;
   }

   long fileTime = System::Convert::ToInt64(
         fInfo->CreationTime.ToFileTime() );
   System::TimeSpan fileAge = FileAge( fileTime );
   System::Console::WriteLine( " {0}", fileAge );
}
