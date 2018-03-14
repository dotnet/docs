
//<snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Security::Cryptography;
class MyMainClass
{
public:
   static void DecodeFromFile( String^ inFileName, String^ outFileName )
   {
      FromBase64Transform^ myTransform = gcnew FromBase64Transform( FromBase64TransformMode::IgnoreWhiteSpaces );
      array<Byte>^myOutputBytes = gcnew array<Byte>(myTransform->OutputBlockSize);
      
      //Open the input and output files.
      FileStream^ myInputFile = gcnew FileStream( inFileName,FileMode::Open,FileAccess::Read );
      FileStream^ myOutputFile = gcnew FileStream( outFileName,FileMode::Create,FileAccess::Write );
      
      //Retrieve the file contents into a Byte array.
      array<Byte>^myInputBytes = gcnew array<Byte>(myInputFile->Length);
      myInputFile->Read( myInputBytes, 0, myInputBytes->Length );
      
      //Transform the data in chunks the size of InputBlockSize.
      int i = 0;
      while ( myInputBytes->Length - i > 4 )
      {
         myTransform->TransformBlock( myInputBytes, i, 4, myOutputBytes, 0 );
         
         /*myTransform->InputBlockSize*/
         i += 4;
         
         /*myTransform->InputBlockSize*/
         myOutputFile->Write( myOutputBytes, 0, myTransform->OutputBlockSize );
      }

      
      //Transform the final block of data.
      myOutputBytes = myTransform->TransformFinalBlock( myInputBytes, i, myInputBytes->Length - i );
      myOutputFile->Write( myOutputBytes, 0, myOutputBytes->Length );
      
      //Free up any used resources.
      myTransform->Clear();
      myInputFile->Close();
      myOutputFile->Close();
   }

};

int main()
{
   MyMainClass * m = new MyMainClass;
   
   //Insert your file names into this method call.
   m->DecodeFromFile(  "c:\\encoded.txt",  "c:\\roundtrip.txt" );
}

//</snippet1>
