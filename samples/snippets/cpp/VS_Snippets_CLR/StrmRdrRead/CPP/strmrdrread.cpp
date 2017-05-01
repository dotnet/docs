
//<Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   //Create a FileInfo instance representing an existing text file.
   FileInfo^ MyFile = gcnew FileInfo( "c:\\csc.txt" );
   
   //Instantiate a StreamReader to read from the text file.
   StreamReader^ sr = MyFile->OpenText();
   
   //Read a single character.
   int FirstChar = sr->Read();
   
   //Display the ASCII number of the character read in both decimal and hexadecimal format.
   Console::WriteLine( "The ASCII number of the first character read is {0:D} in decimal and {1:X} in hexadecimal.", FirstChar, FirstChar );
   
   //
   sr->Close();
}

//</Snippet1>    
