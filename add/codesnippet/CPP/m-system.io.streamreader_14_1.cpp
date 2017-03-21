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

