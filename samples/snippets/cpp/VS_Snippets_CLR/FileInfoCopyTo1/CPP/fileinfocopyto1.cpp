
// <snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   try
   {
      
      // Create a reference to a file, which might or might not exist.
      // If it does not exist, it is not yet created.
      FileInfo^ fi = gcnew FileInfo( "temp.txt" );
      
      // Create a writer, ready to add entries to the file.
      StreamWriter^ sw = fi->AppendText();
      sw->WriteLine( "Add as many lines as you like..." );
      sw->WriteLine( "Add another line to the output..." );
      sw->Flush();
      sw->Close();
      
      // Get the information out of the file and display it.
      StreamReader^ sr = gcnew StreamReader( fi->OpenRead() );
      Console::WriteLine( "This is the information in the first file:" );
      while ( sr->Peek() != -1 )
            Console::WriteLine( sr->ReadLine() );
      
      // Copy this file to another file. The file will not be overwritten if it already exists.
      FileInfo^ newfi = fi->CopyTo( "newTemp.txt" );
      
      // Get the information out of the new file and display it.* sr = new StreamReader(newfi->OpenRead());
      Console::WriteLine( "{0}This is the information in the second file:", Environment::NewLine );
      while ( sr->Peek() != -1 )
            Console::WriteLine( sr->ReadLine() );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//This is the information in the first file:
//Add as many lines as you like...
//Add another line to the output...
//
//This is the information in the second file:

// </snippet1>
