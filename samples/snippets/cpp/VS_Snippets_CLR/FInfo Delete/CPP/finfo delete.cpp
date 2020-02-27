// <Snippet1>
using namespace System;
using namespace System::IO;

int main()
{
   String^ path = "c:\\MyTest.txt";
   FileInfo^ fi1 = gcnew FileInfo( path );
   try
   {
      StreamWriter^ sw = fi1->CreateText();
      if ( sw )
         delete (IDisposable^)sw;

      String^ path2 = String::Concat( path, "temp" );
      FileInfo^ fi2 = gcnew FileInfo( path2 );
      
      //Ensure that the target does not exist.
      fi2->Delete();
      
      //Copy the file.
      fi1->CopyTo( path2 );
      Console::WriteLine( "{0} was copied to {1}.", path, path2 );
      
      //Delete the newly created file.
      fi2->Delete();
      Console::WriteLine( "{0} was successfully deleted.", path2 );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//c:\MyTest.txt was copied to c:\MyTest.txttemp.
//c:\MyTest.txttemp was successfully deleted.
// </Snippet1>
