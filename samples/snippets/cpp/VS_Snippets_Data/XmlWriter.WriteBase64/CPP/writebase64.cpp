

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Text;
ref class TestBase64
{
private:
   static int bufferSize = 4096;

public:

   // Use the WriteBase64 method to create an XML document.  The object  
   // passed by the user is encoded and included in the document.
   void EncodeXmlFile( String^ xmlFileName, FileStream^ fileOld )
   {
      array<Byte>^buffer = gcnew array<Byte>(bufferSize);
      int readByte = 0;
      XmlTextWriter^ xw = gcnew XmlTextWriter( xmlFileName,Encoding::UTF8 );
      xw->WriteStartDocument();
      xw->WriteStartElement( "root" );

      // Create a Char writer.
      BinaryReader^ br = gcnew BinaryReader( fileOld );

      // Set the file pointer to the end.
      try
      {
         do
         {
            readByte = br->Read( buffer, 0, bufferSize );
            xw->WriteBase64( buffer, 0, readByte );
         }
         while ( bufferSize <= readByte );
      }
      catch ( Exception^ ex ) 
      {
         EndOfStreamException^ ex1 = gcnew EndOfStreamException;
         if ( ex1->Equals( ex ) )
                  Console::WriteLine( "We are at end of file" );
         else
                  Console::WriteLine( ex );
      }

      xw->WriteEndElement();
      xw->WriteEndDocument();
      xw->Flush();
      xw->Close();
   }

   // Use the ReadBase64 method to decode the new XML document 
   // and generate the original object.
   void DecodeOrignalObject( String^ xmlFileName, FileStream^ fileNew )
   {
      array<Byte>^buffer = gcnew array<Byte>(bufferSize);
      int readByte = 0;

      // Create a file to write the bmp back.
      BinaryWriter^ bw = gcnew BinaryWriter( fileNew );
      XmlTextReader^ tr = gcnew XmlTextReader( xmlFileName );
      tr->MoveToContent();
      Console::WriteLine( tr->Name );
      do
      {
         readByte = tr->ReadBase64( buffer, 0, bufferSize );
         bw->Write( buffer, 0, readByte );
      }
      while ( readByte >= bufferSize );

      bw->Flush();
   }

   // Compare the two files.
   bool CompareResult( FileStream^ fileOld, FileStream^ fileNew )
   {
      int readByteOld = 0;
      int readByteNew = 0;
      int count;
      int readByte = 0;
      array<Byte>^bufferOld = gcnew array<Byte>(bufferSize);
      array<Byte>^bufferNew = gcnew array<Byte>(bufferSize);
      BinaryReader^ binaryReaderOld = gcnew BinaryReader( fileOld );
      BinaryReader^ binaryReaderNew = gcnew BinaryReader( fileNew );
      binaryReaderOld->BaseStream->Seek( 0, SeekOrigin::Begin );
      binaryReaderNew->BaseStream->Seek( 0, SeekOrigin::Begin );
      do
      {
         readByteOld = binaryReaderOld->Read( bufferOld, 0, bufferSize );
         readByteNew = binaryReaderNew->Read( bufferNew, 0, bufferSize );
         if ( readByteOld != readByteNew )
                  return false;

         for ( count = 0; count < bufferSize; ++count )
            if ( bufferOld[ count ] != bufferNew[ count ] )
                        return false;
      }
      while ( count < readByte );

      return true;
   }

   // Display the usage statement.
   void Usage()
   {
      Console::WriteLine( "TestBase64 sourceFile, targetFile \n" );
      Console::WriteLine( "For example: TestBase64 winlogon.bmp, target.bmp\n" );
   }
};

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   TestBase64^ testBase64 = gcnew TestBase64;

   // Check that the usage is correct.
   if ( args->Length < 3 )
   {
      testBase64->Usage();
      return 1;
   }

   FileStream^ fileOld = gcnew FileStream( args[ 1 ],FileMode::OpenOrCreate,FileAccess::Read,FileShare::Read );
   testBase64->EncodeXmlFile( "temp.xml", fileOld );
   FileStream^ fileNew = gcnew FileStream( args[ 2 ],FileMode::Create,FileAccess::ReadWrite,FileShare::ReadWrite );
   testBase64->DecodeOrignalObject( "temp.xml", fileNew );

   // Compare the two files.
   if ( testBase64->CompareResult( fileOld, fileNew ) )
      Console::WriteLine( "The recreated binary file {0} is the same as {1}", args[ 2 ], args[ 1 ] );
   else
      Console::WriteLine( "The recreated binary file {0} is not the same as {1}", args[ 2 ], args[ 1 ] );

   fileOld->Flush();
   fileNew->Flush();
   fileOld->Close();
   fileNew->Close();
   return 0;
}
//</snippet1>
