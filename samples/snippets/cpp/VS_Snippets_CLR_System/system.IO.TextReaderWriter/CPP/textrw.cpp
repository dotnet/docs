
// <Snippet1>
using namespace System;
using namespace System::IO;

// <Snippet4>
void WriteText( TextWriter^ textWriter )
{
   textWriter->Write(  "Invalid file path characters are: " );
   textWriter->Write( Path::InvalidPathChars );
   textWriter->Write( Char::Parse( "." ) );
}


// </Snippet4>
// <Snippet5>
void ReadText( TextReader^ textReader )
{
   Console::WriteLine( "From {0} - {1}", textReader->GetType()->Name, textReader->ReadToEnd() );
}


// </Snippet5>
int main()
{
   
   // <Snippet2>
   TextWriter^ stringWriter = gcnew StringWriter;
   TextWriter^ streamWriter = gcnew StreamWriter(  "InvalidPathChars.txt" );
   
   // </Snippet2>
   WriteText( stringWriter );
   WriteText( streamWriter );
   streamWriter->Close();
   
   // <Snippet3>
   TextReader^ stringReader = gcnew StringReader( stringWriter->ToString() );
   TextReader^ streamReader = gcnew StreamReader(  "InvalidPathChars.txt" );
   
   // </Snippet3>
   ReadText( stringReader );
   ReadText( streamReader );
   streamReader->Close();
}

// </Snippet1>
