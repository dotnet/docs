
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   try
   {
      DirectoryInfo^ di = gcnew DirectoryInfo( "c:\\" );
      
      // Get only subdirectories that contain the letter "p."
      array<DirectoryInfo^>^dirs = di->GetDirectories( "*p*" );
      Console::WriteLine( "The number of directories containing the letter p is {0}.", dirs->Length );
      Collections::IEnumerator^ myEnum = dirs->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DirectoryInfo^ diNext = safe_cast<DirectoryInfo^>(myEnum->Current);
         Console::WriteLine( "The number of files in {0} is {1}", diNext, diNext->GetFiles()->Length );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }

}

// </Snippet1>
