
//<SNIPPET1>
// This sample shows the differences between dates from methods that use
//coordinated universal time (UTC) format and those that do not.
using namespace System;
using namespace System::IO;
int main()
{
   
   // Set the directory.
   String^ n = "C:\\test\\newdir";
   
   //Create two variables to use to set the time.
   DateTime dtime1 = DateTime(2002,1,3);
   DateTime dtime2 = DateTime(1999,1,1);
   
   //Create the directory.
   try
   {
      Directory::CreateDirectory( n );
   }
   catch ( IOException^ e ) 
   {
      Console::WriteLine( e );
   }

   
   //Set the creation and last access times to a variable DateTime value.
   Directory::SetCreationTime( n, dtime1 );
   Directory::SetLastAccessTimeUtc( n, dtime1 );
   
   // Print to console the results.
   Console::WriteLine( "Creation Date: {0}", Directory::GetCreationTime( n ) );
   Console::WriteLine( "UTC creation Date: {0}", Directory::GetCreationTimeUtc( n ) );
   Console::WriteLine( "Last write time: {0}", Directory::GetLastWriteTime( n ) );
   Console::WriteLine( "UTC last write time: {0}", Directory::GetLastWriteTimeUtc( n ) );
   Console::WriteLine( "Last access time: {0}", Directory::GetLastAccessTime( n ) );
   Console::WriteLine( "UTC last access time: {0}", Directory::GetLastAccessTimeUtc( n ) );
   
   //Set the last write time to a different value.
   Directory::SetLastWriteTimeUtc( n, dtime2 );
   Console::WriteLine( "Changed last write time: {0}", Directory::GetLastWriteTimeUtc( n ) );
}

// Obviously, since this sample deals with dates and times, the output will vary
// depending on when you run the executable. Here is one example of the output:
//Creation Date: 1/3/2002 12:00:00 AM
//UTC creation Date: 1/3/2002 8:00:00 AM
//Last write time: 12/31/1998 4:00:00 PM
//UTC last write time: 1/1/1999 12:00:00 AM
//Last access time: 1/2/2002 4:00:00 PM
//UTC last access time: 1/3/2002 12:00:00 AM
//Changed last write time: 1/1/1999 12:00:00 AM
//</SNIPPET1>
