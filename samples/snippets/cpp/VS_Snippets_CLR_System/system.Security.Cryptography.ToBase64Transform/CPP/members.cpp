// This sample demonstrates how to use each member of the ToBase64Transform
// class. The file named members.cs is read in and written out as a
// transformed file named members.enc.
//<Snippet1>
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
      //<Snippet2>
      ToBase64Transform^ base64Transform = gcnew ToBase64Transform;
      //</Snippet2>

      // Create a new byte array with the size of the output block size.
      //<Snippet6>
      array<Byte>^outputBytes = gcnew array<Byte>(
         base64Transform->OutputBlockSize);
      //</Snippet6>

      // Retrieve the file contents into a byte array.
      array<Byte>^inputBytes = gcnew array<Byte>(inputFileStream->Length);
      inputFileStream->Read( inputBytes, 0, inputBytes->Length );

      // Verify that multiple blocks can not be transformed.
      //<Snippet4>
      if (  !base64Transform->CanTransformMultipleBlocks )
      //</snippet4>
      {
         // Initializie the offset size.
         int inputOffset = 0;

         // Iterate through inputBytes transforming by blockSize.
         //<Snippet8>
         //<Snippet5>
         int inputBlockSize = base64Transform->InputBlockSize;
         //</Snippet5>
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
         //</snippet8>
         
         // Transform the final block of data.
         //<Snippet9>
         outputBytes = base64Transform->TransformFinalBlock(
            inputBytes,
            inputOffset,
            inputBytes->Length - inputOffset );
         //</Snippet9>
         outputFileStream->Write( outputBytes, 0, outputBytes->Length );
         Console::WriteLine( L"Created encoded file at {0}", targetFile );
      }

      // Determine if the current transform can be reused.
      //<Snippet3>
      if (  !base64Transform->CanReuseTransform )
      //</Snippet3>
      {
         // Free up any used resources.
         //<Snippet7>
         base64Transform->Clear();
         //</Snippet7>
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
//</Snippet1>
