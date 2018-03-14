
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   // Specify the directory you want to manipulate.
   String^ path = "c:\\MyDir";
   try
   {
      
      // Determine whether the directory exists.
      if ( Directory::Exists( path ) )
      {
         Console::WriteLine( "That path exists already." );
         return 0;
      }
      
      // Try to create the directory.
      DirectoryInfo^ di = Directory::CreateDirectory( path );
      Console::WriteLine( "The directory was created successfully at {0}.", Directory::GetCreationTime( path ) );
      
      // Delete the directory.
      di->Delete();
      Console::WriteLine( "The directory was deleted successfully." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }

}

// </Snippet1>
