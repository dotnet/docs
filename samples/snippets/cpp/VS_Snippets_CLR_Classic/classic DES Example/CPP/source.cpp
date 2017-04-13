

#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::IO;
using namespace System::Windows::Forms;
using namespace System::Security::Cryptography;

// <Snippet1>
void EncryptData( String^ inName, String^ outName, array<Byte>^desKey, array<Byte>^desIV )
{
   
   //Create the file streams to handle the input and output files.
   FileStream^ fin = gcnew FileStream( inName,FileMode::Open,FileAccess::Read );
   FileStream^ fout = gcnew FileStream( outName,FileMode::OpenOrCreate,FileAccess::Write );
   fout->SetLength( 0 );
   
   //Create variables to help with read and write.
   array<Byte>^bin = gcnew array<Byte>(100);
   long rdlen = 0; //This is the total number of bytes written.

   long totlen = (long)fin->Length; //This is the total length of the input file.

   int len; //This is the number of bytes to be written at a time.

   DES^ des = gcnew DESCryptoServiceProvider;
   CryptoStream^ encStream = gcnew CryptoStream( fout,des->CreateEncryptor( desKey, desIV ),CryptoStreamMode::Write );
   Console::WriteLine( "Encrypting..." );
   
   //Read from the input file, then encrypt and write to the output file.
   while ( rdlen < totlen )
   {
      len = fin->Read( bin, 0, 100 );
      encStream->Write( bin, 0, len );
      rdlen = rdlen + len;
      Console::WriteLine( "{0} bytes processed", rdlen );
   }

   encStream->Close();
   fout->Close();
   fin->Close();
}

// </Snippet1>
