
//<snippet1>
using namespace System;
using namespace System::IO;
ref class StreamReaderSample: public TextReader
{
public:

   //</snippet1> 
   StreamReaderSample()
   {
      printInfo();
      usePeek();
      usePosition();
      useNull();
      useReadLine();
      useReadToEnd();
   }


private:

   //All Overloaded Constructors for StreamReader
   //<snippet2> 
   void getNewStreamReader()
   {
      
      //Get a new StreamReader in ASCII format from a
      //file using a buffer and byte order mark detection
      StreamReader^ srAsciiFromFileFalse512 = gcnew StreamReader(  "C:\\Temp\\Test.txt",System::Text::Encoding::ASCII,false,512 );
      
      //Get a new StreamReader in ASCII format from a
      //file with byte order mark detection = false
      StreamReader^ srAsciiFromFileFalse = gcnew StreamReader(  "C:\\Temp\\Test.txt",System::Text::Encoding::ASCII,false );
      
      //Get a new StreamReader in ASCII format from a file 
      StreamReader^ srAsciiFromFile = gcnew StreamReader(  "C:\\Temp\\Test.txt",System::Text::Encoding::ASCII );
      
      //Get a new StreamReader from a
      //file with byte order mark detection = false
      StreamReader^ srFromFileFalse = gcnew StreamReader(  "C:\\Temp\\Test.txt",false );
      
      //Get a new StreamReader from a file
      StreamReader^ srFromFile = gcnew StreamReader(  "C:\\Temp\\Test.txt" );
      
      //Get a new StreamReader in ASCII format from a
      //FileStream with byte order mark detection = false and a buffer
      StreamReader^ srAsciiFromStreamFalse512 = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ),System::Text::Encoding::ASCII,false,512 );
      
      //Get a new StreamReader in ASCII format from a
      //FileStream with byte order mark detection = false
      StreamReader^ srAsciiFromStreamFalse = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ),System::Text::Encoding::ASCII,false );
      
      //Get a new StreamReader in ASCII format from a FileStream
      StreamReader^ srAsciiFromStream = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ),System::Text::Encoding::ASCII );
      
      //Get a new StreamReader from a
      //FileStream with byte order mark detection = false
      StreamReader^ srFromStreamFalse = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ),false );
      
      //Get a new StreamReader from a FileStream
      StreamReader^ srFromStream = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ) );
   }


   //</snippet2>
   //<snippet3> 
   void printInfo()
   {
      
      //</snippet3>
      //<snippet4>  
      StreamReader^ srEncoding = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ),System::Text::Encoding::ASCII );
      Console::WriteLine(  "Encoding: {0}", srEncoding->CurrentEncoding->EncodingName );
      srEncoding->Close();
      
      //</snippet4> 
   }

   void usePeek()
   {
      
      //<snippet5> 
      StreamReader^ srPeek = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ),System::Text::Encoding::ASCII );
      
      // set the file pointer to the beginning
      srPeek->BaseStream->Seek( 0, SeekOrigin::Begin );
      
      // cycle while there is a next char
      while ( srPeek->Peek() > -1 )
      {
         Console::Write( srPeek->ReadLine() );
      }

      srPeek->Close();
      
      //</snippet5>
   }

   void usePosition()
   {
      
      //<snippet6> 
      StreamReader^ srRead = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ),System::Text::Encoding::ASCII );
      
      // set the file pointer to the beginning
      srRead->BaseStream->Seek( 0, SeekOrigin::Begin );
      srRead->BaseStream->Position = 0;
      while ( srRead->BaseStream->Position < srRead->BaseStream->Length )
      {
         array<__wchar_t>^buffer = gcnew array<__wchar_t>(1);
         srRead->Read( buffer, 0, 1 );
         Console::Write( buffer[ 0 ].ToString() );
         srRead->BaseStream->Position = srRead->BaseStream->Position + 1;
      }

      srRead->DiscardBufferedData();
      srRead->Close();
      
      //</snippet6>
   }

   void useNull()
   {
      
      //<snippet7> 
      StreamReader^ srNull = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ),System::Text::Encoding::ASCII );
      if (  !srNull->Equals( StreamReader::Null ) )
      {
         srNull->BaseStream->Seek( 0, SeekOrigin::Begin );
         Console::WriteLine( srNull->ReadToEnd() );
      }

      srNull->Close();
      
      //</snippet7>
   }

   void useReadLine()
   {
      
      //<snippet8> 
      StreamReader^ srReadLine = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ),System::Text::Encoding::ASCII );
      srReadLine->BaseStream->Seek( 0, SeekOrigin::Begin );
      while ( srReadLine->Peek() > -1 )
      {
         Console::WriteLine( srReadLine->ReadLine() );
      }

      srReadLine->Close();
      
      //</snippet8> 
   }

   void useReadToEnd()
   {
      
      //<snippet9> 
      StreamReader^ srReadToEnd = gcnew StreamReader( File::OpenRead(  "C:\\Temp\\Test.txt" ),System::Text::Encoding::ASCII );
      srReadToEnd->BaseStream->Seek( 0, SeekOrigin::Begin );
      Console::WriteLine( srReadToEnd->ReadToEnd() );
      srReadToEnd->Close();
      
      //</snippet9>
      //<snippet10> 
   }

   //</snippet10>
   //<snippet11> 
};


//</snippet11>
void main( int argc )
{
   StreamReaderSample^ srs = gcnew StreamReaderSample;
}
