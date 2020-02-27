using namespace System;
using namespace System::IO;

ref class Coder
{
private:
   String^ inputFileName;
   String^ outputFileName;

public:
   Coder( String^ inFile, String^ outFile )
   {
      inputFileName = (String^)(inFile->Clone());
      outputFileName = (String^)(outFile->Clone());
   }

   //<Snippet1>
public:
   void EncodeWithString()
   {
      FileStream^ inFile;
      array<Byte>^ binaryData;

      try
      {
         inFile = gcnew FileStream( inputFileName,
                                    FileMode::Open,
                                    FileAccess::Read );
         binaryData = gcnew array<Byte>((int)(inFile->Length));
         long bytesRead = inFile->Read( binaryData, 0,
                                        (int)inFile->Length );
         inFile->Close();
      }
      catch ( Exception^ exp ) 
      {
         // Error creating stream or reading from it.
         Console::WriteLine( " {0}", exp->Message );
         return;
      }
      
      // Convert the binary input into Base64 UUEncoded output.
      String^ base64String;
      try
      {
         base64String = Convert::ToBase64String( binaryData,
                                                 0,
                                                 binaryData->Length );
      }
      catch ( ArgumentNullException^ ) 
      {
         Console::WriteLine( "Binary data array is null." );
         return;
      }
      
      // Write the UUEncoded version to the output file.
      StreamWriter^ outFile;
      try
      {
         outFile = gcnew StreamWriter( outputFileName,
                                       false,
                                       Text::Encoding::ASCII );
         outFile->Write( base64String );
         outFile->Close();
      }
      catch ( Exception^ exp ) 
      {
         
         // Error creating stream or writing to it.
         Console::WriteLine( " {0}", exp->Message );
      }
   }
   //</Snippet1>

   //<Snippet2>
public:
   void EncodeWithCharArray()
   {
      FileStream^ inFile;
      array<Byte>^binaryData;

      try
      {
         inFile = gcnew FileStream( inputFileName,
                                    FileMode::Open,
                                    FileAccess::Read );
         binaryData = gcnew array<Byte>((int)(inFile->Length));
         long bytesRead = inFile->Read( binaryData, 0,
                                        (int)inFile->Length );
         inFile->Close();
      }
      catch ( Exception^ exp ) 
      {
         // Error creating stream or reading from it.
         Console::WriteLine( "{0}", exp->Message );
         return;
      }
      
      // Convert the binary input into Base64 UUEncoded output.
      // Each 3 Byte sequence in the source data becomes a 4 Byte
      // sequence in the character array. 
      long arrayLength = (long)((4.0 / 3.0) * binaryData->Length);
      
      // If array length is not divisible by 4, go up to the next
      // multiple of 4.
      if ( arrayLength % 4 != 0 )
      {
         arrayLength += 4 - arrayLength % 4;
      }

      array<Char>^ base64CharArray = gcnew array<Char>(arrayLength);
      try
      {
         Convert::ToBase64CharArray( binaryData,
                                     0,
                                     binaryData->Length,
                                     base64CharArray, 0 );
      }
      catch ( ArgumentNullException^ ) 
      {
         Console::WriteLine( "Binary data array is null." );
         return;
      }
      catch ( ArgumentOutOfRangeException^ ) 
      {
         Console::WriteLine( "Char Array is not large enough." );
         return;
      }
      
      // Write the UUEncoded version to the output file.
      StreamWriter^ outFile;
      try
      {
         outFile = gcnew StreamWriter( outputFileName,
                                       false,
                                       Text::Encoding::ASCII );
         outFile->Write( base64CharArray );
         outFile->Close();
      }
      catch ( Exception^ exp ) 
      {
         // Error creating stream or writing to it.
         Console::WriteLine( " {0}", exp->Message );
      }
   }
   //</Snippet2>

   //<Snippet3>
public:
   void DecodeWithCharArray()
   {
      StreamReader^ inFile;
      array<Char>^base64CharArray;
      try
      {
         inFile = gcnew StreamReader( inputFileName,
                                      Text::Encoding::ASCII );
         base64CharArray = gcnew array<Char>((int)(inFile->BaseStream->Length));
         inFile->Read( base64CharArray, 0, (int)inFile->BaseStream->Length );
         inFile->Close();
      }
      catch ( Exception^ exp ) 
      {
         
         // Error creating stream or reading from it.
         Console::WriteLine( "{0}", exp->Message );
         return;
      }
      
      // Convert the Base64 UUEncoded input into binary output.
      array<Byte>^binaryData;
      try
      {
         binaryData = Convert::FromBase64CharArray( base64CharArray,
                                                    0,
                                                    base64CharArray->Length );
      }
      catch ( ArgumentNullException^ ) 
      {
         Console::WriteLine( "Base 64 character array is null." );
         return;
      }
      catch ( FormatException^ ) 
      {
         Console::WriteLine( "Base 64 Char Array length is not " +
            "4 or is not an even multiple of 4." );
         return;
      }
      
      // Write out the decoded data.
      FileStream^ outFile;
      try
      {
         outFile = gcnew FileStream( outputFileName,
                                     FileMode::Create,
                                     FileAccess::Write );
         outFile->Write( binaryData, 0, binaryData->Length );
         outFile->Close();
      }
      catch ( Exception^ exp ) 
      {
         // Error creating stream or writing to it.
         Console::WriteLine( "{0}", exp->Message );
      }
   }
   //</Snippet3>

   //<Snippet4>
public:
   void DecodeWithString()
   {
      StreamReader^ inFile;
      String^ base64String;
      try
      {
         array<Char>^base64CharArray;
         inFile = gcnew StreamReader( inputFileName,
                                      Text::Encoding::ASCII );
         base64CharArray = gcnew array<Char>((int)(inFile->BaseStream->Length));
         inFile->Read( base64CharArray, 0, (int)inFile->BaseStream->Length );
         base64String = gcnew String( base64CharArray );
      }
      catch ( Exception^ exp ) 
      {
         // Error creating stream or reading from it.
         Console::WriteLine( "{0}", exp->Message );
         return;
      }
      
      // Convert the Base64 UUEncoded input into binary output.
      array<Byte>^binaryData;
      try
      {
         binaryData = Convert::FromBase64String( base64String );
      }
      catch ( ArgumentNullException^ ) 
      {
         Console::WriteLine( "Base 64 String^ is null." );
         return;
      }
      catch ( FormatException^ ) 
      {
         Console::WriteLine( "Base 64 String^ length is not " +
            "4 or is not an even multiple of 4." );
         return;
      }
      
      // Write out the decoded data.
      FileStream^ outFile;
      try
      {
         outFile = gcnew FileStream( outputFileName,
                                     FileMode::Create,
                                     FileAccess::Write );
         outFile->Write( binaryData, 0, binaryData->Length );
         outFile->Close();
      }
      catch ( Exception^ exp ) 
      {
         // Error creating stream or writing to it.
         Console::WriteLine( "{0}", exp->Message );
      }
   }
   //</Snippet4>
};

void main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   if ( args->Length != 5 )
   {
      Console::WriteLine( "Usage: UUCodeC -d | -e " +
         "-s | -c inputFile outputFile" );
      return;
   }

   String^ inputFileName = args[ 3 ];
   String^ outputFileName = args[ 4 ];
   Coder^ coder = gcnew Coder( inputFileName,outputFileName );
	
   if ( args[ 1 ] == "-d" )
   {
      if ( args[ 2 ] == "-s" )
      {
         coder->DecodeWithString();
      }
      else if ( args[ 2 ] == "-c" )
      {
         coder->DecodeWithCharArray();
      }
      else
      {
         Console::WriteLine( "Second arg must be -s or -c" );
         return;
      }
   }
   else
   if ( args[ 1 ] == "-e" )
   {
      if ( args[ 2 ] == "-s" )
      {
         coder->EncodeWithString();
      }
      else if ( args[ 2 ] == "-c" )
      {
         coder->EncodeWithCharArray();
      }
      else
      {
         Console::WriteLine( "Second arg must be -s or -c" );
         return;
      }
   }
   else
   {
      Console::WriteLine( "First arg must be -d or -e" );
   }
}
