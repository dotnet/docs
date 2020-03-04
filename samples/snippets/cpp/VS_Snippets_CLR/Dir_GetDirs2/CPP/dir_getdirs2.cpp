
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   try
   {
      
      // Only get subdirectories that begin with the letter "p."
      array<String^>^dirs = Directory::GetDirectories( "c:\\", "p*" );
      Console::WriteLine( "The number of directories starting with p is {0}.", dirs->Length );
      Collections::IEnumerator^ myEnum = dirs->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Console::WriteLine( myEnum->Current );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }

}

// </Snippet1>
