// <Snippet1>
using namespace System;
using namespace System::IO;

int main()
{
   String^ path = "c:\\MyTest.txt";
   FileInfo^ fi = gcnew FileInfo( path );
   if (  !fi->Exists )
   {
      //Create a file to write to.
      StreamWriter^ sw = fi->CreateText();
      try
      {
         sw->WriteLine( "Hello" );
         sw->WriteLine( "And" );
         sw->WriteLine( "Welcome" );
      }
      finally
      {
         if ( sw )
            delete (IDisposable^)sw;
      }
   }

   //Open the file to read from.
   StreamReader^ sr = fi->OpenText();
   try
   {
      String^ s = "";
      while ( s = sr->ReadLine() )
      {
         Console::WriteLine( s );
      }
   }
   finally
   {
      if ( sr )
         delete (IDisposable^)sr;
   }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//Hello
//And
//Welcome
// </Snippet1>
