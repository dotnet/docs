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

      StreamReader^ sr = gcnew StreamReader( path );
      try
      {
         //This is an arbitrary size for this example.
         array<Char>^c = nullptr;
         while ( sr->Peek() >= 0 )
         {
            c = gcnew array<Char>(5);
            sr->Read( c, 0, c->Length );
            
            //The output will look odd, because
            //only five characters are read at a time.
            Console::WriteLine( c );
         }
      }
      finally
      {
         delete sr;
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The process failed: {0}", e );
   }
}
// </Snippet1>
