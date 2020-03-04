
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   // Specify the directories you want to manipulate.
   DirectoryInfo^ di = gcnew DirectoryInfo( "c:\\MyDir" );
   try
   {
      
      // Determine whether the directory exists.
      if ( di->Exists )
      {
         
         // Indicate that the directory already exists.
         Console::WriteLine( "That path exists already." );
         return 0;
      }
      
      // Try to create the directory.
      di->Create();
      Console::WriteLine( "The directory was created successfully." );
      
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
