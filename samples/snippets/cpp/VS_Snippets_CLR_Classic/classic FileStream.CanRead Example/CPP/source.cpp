
// <Snippet1>
using namespace System;
using namespace System::IO;
int main( void )
{
   FileStream^ fs = gcnew FileStream( "MyFile.txt",FileMode::OpenOrCreate,FileAccess::Read );
   if ( fs->CanRead && fs->CanWrite )
   {
      Console::WriteLine( "MyFile.txt can be both written to and read from." );
   }
   else
   {
      Console::WriteLine( "MyFile.txt is not writable" );
   }

   return 0;
}

// </Snippet1>
