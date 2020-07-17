
// <SNIPPET1>
using namespace System;
using namespace System::IO;
using namespace System::Security::Cryptography;
int main()
{
   
   // creates the CspParameters object and sets the key container name used to store the RSA key pair
   CspParameters^ cp = gcnew CspParameters;
   cp->KeyContainerName = "MyKeyContainerName";
   
   // instantiates the rsa instance accessing the key container MyKeyContainerName
   RSACryptoServiceProvider^ rsa = gcnew RSACryptoServiceProvider( cp );
   
   // add the below line to delete the key entry in MyKeyContainerName
   // rsa.PersistKeyInCsp = false;
   //writes out the current key pair used in the rsa instance
   Console::WriteLine( "Key is : \n{0}", rsa->ToXmlString( true ) );
}

// </SNIPPET1>
