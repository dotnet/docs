
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   try
   {
      
      // Only get files that begin with the letter "c."
      array<String^>^dirs = Directory::GetFiles( "c:\\", "c*" );
      Console::WriteLine( "The number of files starting with c is {0}.", dirs->Length );
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
