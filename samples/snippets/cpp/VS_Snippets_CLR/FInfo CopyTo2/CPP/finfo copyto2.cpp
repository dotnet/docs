// <Snippet1>
using namespace System;
using namespace System::IO;

int main()
{
   String^ path = "c:\\MyTest.txt";
   String^ path2 = "c:\\MyTest.txttemp";
   FileInfo^ fi1 = gcnew FileInfo( path );
   FileInfo^ fi2 = gcnew FileInfo( path2 );
   try
   {
      // Create the file and clean up handles.
      FileStream^ fs = fi1->Create();
      if ( fs )
         delete (IDisposable^)fs;
      
      //Ensure that the target does not exist.
      fi2->Delete();
      
      //Copy the file.
      fi1->CopyTo( path2 );
      Console::WriteLine( "{0} was copied to {1}.", path, path2 );
      
      //Try to copy it again, which should succeed.
      fi1->CopyTo( path2, true );
      Console::WriteLine( "The second Copy operation succeeded, which is expected." );
   }
   catch ( Exception^ ) 
   {
      Console::WriteLine( "Double copying was not allowed, which is not expected." );
   }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//The second Copy operation succeeded, which is expected.
// </Snippet1>
