
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   try
   {
      
      // Get the current directory.
      String^ path = Directory::GetCurrentDirectory();
      String^ target = "c:\\temp";
      Console::WriteLine( "The current directory is {0}", path );
      if (  !Directory::Exists( target ) )
      {
         Directory::CreateDirectory( target );
      }
      
      // Change the current directory.
      Environment::CurrentDirectory = target;
      if ( path->Equals( Directory::GetCurrentDirectory() ) )
      {
         Console::WriteLine( "You are in the temp directory." );
      }
      else
      {
         Console::WriteLine( "You are not in the temp directory." );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }

}

// </Snippet1>
