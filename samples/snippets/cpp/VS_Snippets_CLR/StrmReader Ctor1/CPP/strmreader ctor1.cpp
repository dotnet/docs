// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   String^ path = "c:\\temp\\MyTest.txt";
   try
   {
      if ( File::Exists( path ) )
      {
         File::Delete( path );
      }
      StreamWriter^ sw = gcnew StreamWriter( path );
      try
      {
         sw->WriteLine( "This" );
         sw->WriteLine( "is some text" );
         sw->WriteLine( "to test" );
         sw->WriteLine( "Reading" );
      }
      finally
      {
         delete sw;
      }

      FileStream^ fs = gcnew FileStream( path,FileMode::Open );
      try
      {
         StreamReader^ sr = gcnew StreamReader( fs );
         try
         {
            while ( sr->Peek() >= 0 )
            {
               Console::WriteLine( sr->ReadLine() );
            }
         }
         finally
         {
            delete sr;
         }
      }
      finally
      {
         delete fs;
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }
}
// </Snippet1>
