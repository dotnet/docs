

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlTextReader^ reader = nullptr;
   String^ filename = "binary.xml";
   try
   {
      reader = gcnew XmlTextReader( filename );
      reader->WhitespaceHandling = WhitespaceHandling::None;
      
      // Read the file. Stop at the Base64 element.
      while ( reader->Read() )
      {
         if ( "Base64" == reader->Name )
                  break;
      }
      
      // Read the Base64 data. Write the decoded 
      // bytes to the console.
      Console::WriteLine( "Reading Base64... " );
      int base64len = 0;
      array<Byte>^base64 = gcnew array<Byte>(1000);
      do
      {
         base64len = reader->ReadBase64( base64, 0, 50 );
         for ( int i = 0; i < base64len; i++ )
            Console::Write( base64[ i ] );
      }
      while ( reader->Name->Equals( "Base64" ) );
      
      // Read the BinHex data. Write the decoded 
      // bytes to the console.
      Console::WriteLine( "\r\nReading BinHex..." );
      int binhexlen = 0;
      array<Byte>^binhex = gcnew array<Byte>(1000);
      do
      {
         binhexlen = reader->ReadBinHex( binhex, 0, 50 );
         for ( int i = 0; i < binhexlen; i++ )
            Console::Write( binhex[ i ] );
      }
      while ( reader->Name->Equals( "BinHex" ) );
   }
   finally
   {
      Console::WriteLine();
      Console::WriteLine( "Processing of the file {0} complete.", filename );
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
