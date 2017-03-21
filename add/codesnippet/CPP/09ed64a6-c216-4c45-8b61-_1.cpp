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