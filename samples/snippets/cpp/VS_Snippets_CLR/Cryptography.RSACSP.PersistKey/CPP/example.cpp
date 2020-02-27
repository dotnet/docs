
// <SNIPPET1>
using namespace System;
using namespace System::Security::Cryptography;
void RSAPersistKeyInCSP( String^ ContainerName )
{
   try
   {
      
      // Create a new instance of CspParameters.  Pass
      // 13 to specify a DSA container or 1 to specify
      // an RSA container.  The default is 1.
      CspParameters^ cspParams = gcnew CspParameters;
      
      // Specify the container name using the passed variable.
      cspParams->KeyContainerName = ContainerName;
      
      //Create a new instance of RSACryptoServiceProvider to generate
      //a new key pair.  Pass the CspParameters class to persist the 
      //key in the container.  The PersistKeyInCsp property is true by 
      //default, allowing the key to be persisted. 
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider( cspParams );
      
      //Indicate that the key was persisted.
      Console::WriteLine( "The RSA key was persisted in the container, \"{0}\".", ContainerName );
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}

void RSADeleteKeyInCSP( String^ ContainerName )
{
   try
   {
      
      // Create a new instance of CspParameters.  Pass
      // 13 to specify a DSA container or 1 to specify
      // an RSA container.  The default is 1.
      CspParameters^ cspParams = gcnew CspParameters;
      
      // Specify the container name using the passed variable.
      cspParams->KeyContainerName = ContainerName;
      
      //Create a new instance of RSACryptoServiceProvider. 
      //Pass the CspParameters class to use the 
      //key in the container.
      RSACryptoServiceProvider^ RSAalg = gcnew RSACryptoServiceProvider( cspParams );
      
      //Explicitly set the PersistKeyInCsp property to false
      //to delete the key entry in the container.
      RSAalg->PersistKeyInCsp = false;
      
      //Call Clear to release resources and delete the key from the container.
      RSAalg->Clear();
      
      //Indicate that the key was persisted.
      Console::WriteLine( "The RSA key was deleted from the container, \"{0}\".", ContainerName );
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}

int main()
{
   String^ KeyContainerName = "MyKeyContainer";
   
   //Create a new key and persist it in 
   //the key container.  
   RSAPersistKeyInCSP( KeyContainerName );
   
   //Delete the key from the key container.
   RSADeleteKeyInCSP( KeyContainerName );
}

// </SNIPPET1>
