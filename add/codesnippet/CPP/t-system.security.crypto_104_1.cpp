using namespace System;
using namespace System::IO;
using namespace System::Security::Cryptography;

ref class Members
{
public:
   [STAThread]
   static void Main()
   {
      String^ appPath = (String::Concat(
         System::IO::Directory::GetCurrentDirectory(), L"\\" ));
      
      // Insert your file names into this method call.
      EncodeFromFile( String::Concat( appPath, L"members.cpp" ),
         String::Concat( appPath, L"members.enc" ) );
      Console::WriteLine( L"This sample completed successfully; "
         L"press Enter to exit." );
      Console::ReadLine();
   }

private:
   // Read in the specified source file and write out an encoded target file.
   static void EncodeFromFile( String^ sourceFile, String^ targetFile )
   {
      // Verify members.cpp exists at the specified directory.
      if (  !File::Exists( sourceFile ) )
      {
         Console::Write( L"Unable to locate source file located at " );
         Console::WriteLine( L"{0}.", sourceFile );
         Console::Write( L"Please correct the path and run the " );
         Console::WriteLine( L"sample again." );
         return;
      }

      // Retrieve the input and output file streams.
      FileStream^ inputFileStream = gcnew FileStream(
         sourceFile,FileMode::Open,FileAccess::Read );
      FileStream^ outputFileStream = gcnew FileStream(
         targetFile,FileMode::Create,FileAccess::Write );

      // Create a new ToBase64Transform object to convert to base 64.
      ToBase64Transform^ base64Transform = gcnew ToBase64Transform;

      // Create a new byte array with the size of the output block size.
      array<Byte>^outputBytes = gcnew array<Byte>(
         base64Transform->OutputBlockSize);

      // Retrieve the file contents into a byte array.
      array<Byte>^inputBytes = gcnew array<Byte>(inputFileStream->Length);
      inputFileStream->Read( inputBytes, 0, inputBytes->Length );

      // Verify that multiple blocks can not be transformed.
      if (  !base64Transform->CanTransformMultipleBlocks )
      {
         // Initializie the offset size.
         int inputOffset = 0;

         // Iterate through inputBytes transforming by blockSize.
         int inputBlockSize = base64Transform->InputBlockSize;
         while ( inputBytes->Length - inputOffset > inputBlockSize )
         {
            base64Transform->TransformBlock(
               inputBytes,
               inputOffset,
               inputBytes->Length - inputOffset,
               outputBytes,
               0 );

            inputOffset += base64Transform->InputBlockSize;
            outputFileStream->Write(
               outputBytes,
               0,
               base64Transform->OutputBlockSize );
         }
         
         // Transform the final block of data.
         outputBytes = base64Transform->TransformFinalBlock(
            inputBytes,
            inputOffset,
            inputBytes->Length - inputOffset );
         outputFileStream->Write( outputBytes, 0, outputBytes->Length );
         Console::WriteLine( L"Created encoded file at {0}", targetFile );
      }

      // Determine if the current transform can be reused.
      if (  !base64Transform->CanReuseTransform )
      {
         // Free up any used resources.
         base64Transform->Clear();
      }

      // Close file streams.
      inputFileStream->Close();
      outputFileStream->Close();
   }
};

int main()
{
   Members::Main();
}

//
// This sample produces the following output:
//
// Created encoded file at C:\ConsoleApplication1\\membersvcs.enc
// This sample completed successfully; press Enter to exit.