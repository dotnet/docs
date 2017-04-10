
// <Snippet1>
using namespace System;
using namespace System::IO;
void main()
{
   try
   {
      String^ path = "c:\\MyDir";
      if (  !Directory::Exists( path ) )
      {
         Directory::CreateDirectory( path );
      }
      else
      {
         
         // Take an action that will affect the write time.
         Directory::SetLastWriteTime( path, DateTime(1985,4,3) );
      }
      
      // Get the last write time of a well-known directory.
      DateTime dt = Directory::GetLastWriteTime( path );
      Console::WriteLine( "The last write time for this directory was {0}", dt );
      
      //Update the last write time.
      Directory::SetLastWriteTime( path, DateTime::Now );
      dt = Directory::GetLastWriteTime( path );
      Console::WriteLine( "The last write time for this directory was {0}", dt );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }

}

// </Snippet1>
