// <Snippet1>
using namespace System;
using namespace System::IO;

int main()
{
   FileInfo^ fi = gcnew FileInfo( "c:\\MyTest.txt" );
   
   // This text is added only once to the file.
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
   
   // This text will always be added, making the file longer over time
   // if it is not deleted.
   StreamWriter^ sw = fi->AppendText();
   try
   {
      sw->WriteLine( "This" );
      sw->WriteLine( "is Extra" );
      sw->WriteLine( "Text" );
   }
   finally
   {
      if ( sw )
         delete (IDisposable^)sw;
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
//This
//is Extra
//Text
//
//When you run this application a second time, you will see the following output:
//
//Hello
//And
//Welcome
//This
//is Extra
//Text
//This
//is Extra
//Text
// </Snippet1>
