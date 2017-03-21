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