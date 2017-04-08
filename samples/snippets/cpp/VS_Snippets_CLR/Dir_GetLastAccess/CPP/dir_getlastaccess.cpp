
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   try
   {
      String^ path = "c:\\MyDir";
      if (  !Directory::Exists( path ) )
      {
         Directory::CreateDirectory( path );
      }
      Directory::SetLastAccessTime( path, DateTime(1985,5,4) );
      
      // Get the creation time of a well-known directory.
      DateTime dt = Directory::GetLastAccessTime( path );
      Console::WriteLine( "The last access time for this directory was {0}", dt );
      
      // Update the last access time.
      Directory::SetLastAccessTime( path, DateTime::Now );
      dt = Directory::GetLastAccessTime( path );
      Console::WriteLine( "The last access time for this directory was {0}", dt );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }

}

// </Snippet1>
