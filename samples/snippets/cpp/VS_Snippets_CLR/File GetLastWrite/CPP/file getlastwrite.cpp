
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   try
   {
      String^ path = "c:\\Temp\\MyTest.txt";
      if (  !File::Exists( path ) )
      {
         File::Create( path );
      }
      else
      {
         
         // Take an action that will affect the write time.
         File::SetLastWriteTime( path, DateTime(1985,4,3) );
      }
      
      // Get the creation time of a well-known directory.
      DateTime dt = File::GetLastWriteTime( path );
      Console::WriteLine( "The last write time for this file was {0}.", dt );
      
      // Update the last write time.
      File::SetLastWriteTime( path, DateTime::Now );
      dt = File::GetLastWriteTime( path );
      Console::WriteLine( "The last write time for this file was {0}.", dt );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }

}

// </Snippet1>
