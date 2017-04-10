//<SNIPPET1>
using System;
using System.Security.Cryptography;
using System.Text;


public class CspKeyContainerInfoExample
{

    public static void Main(String[] args)
    {
        RSACryptoServiceProvider rsa= new RSACryptoServiceProvider();

        try
        {
            // Note: In cases where a random key is generated,   
            // a key container is not created until you call  
            // a method that uses the key.  This example calls
            // the Encrypt method before calling the
            // CspKeyContainerInfo property so that a key
            // container is created.  

            // Create some data to encrypt and display it.
            string data = "Here is some data to encrypt.";

            Console.WriteLine("Data to encrypt: " + data);

            // Convert the data to an array of bytes and 
            // encrypt it.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            byte[] encData = rsa.Encrypt(byteData, false);

            // Display the encrypted value.
            Console.WriteLine("Encrypted Data: " + Encoding.ASCII.GetString(encData));

            Console.WriteLine();

            Console.WriteLine("CspKeyContainerInfo information:");

            Console.WriteLine();

            // Create a new CspKeyContainerInfo object.
            CspKeyContainerInfo keyInfo = rsa.CspKeyContainerInfo;

            // Display the value of each property.

            Console.WriteLine("Accessible property: " + keyInfo.Accessible);

            Console.WriteLine("Exportable property: " + keyInfo.Exportable);

            Console.WriteLine("HardwareDevice property: " + keyInfo.HardwareDevice);

            Console.WriteLine("KeyContainerName property: " + keyInfo.KeyContainerName);

            Console.WriteLine("KeyNumber property: " + keyInfo.KeyNumber.ToString());

            Console.WriteLine("MachineKeyStore property: " + keyInfo.MachineKeyStore);

            Console.WriteLine("Protected property: " + keyInfo.Protected);

            Console.WriteLine("ProviderName property: " + keyInfo.ProviderName);

            Console.WriteLine("ProviderType property: " + keyInfo.ProviderType);

            Console.WriteLine("RandomlyGenerated property: " + keyInfo.RandomlyGenerated);

            Console.WriteLine("Removable property: " + keyInfo.Removable);

            Console.WriteLine("UniqueKeyContainerName property: " + keyInfo.UniqueKeyContainerName);


        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            // Clear the key.
            rsa.Clear();
        }
    }
}
//</SNIPPET1>
