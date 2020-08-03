//<Snippet1>
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Class1
{
    static void Main(string[] args)
    {
        byte[] hashValue;

        string messageString = "This is the original message!";

        //Create a new instance of the UnicodeEncoding class to
        //convert the string into an array of Unicode bytes.
        UnicodeEncoding ue = new UnicodeEncoding();

        //Convert the string into an array of bytes.
        byte[] messageBytes = ue.GetBytes(messageString);

        //Create a new instance of the SHA256 class to create
        //the hash value.
        SHA256 shHash = SHA256.Create();

        //Create the hash value from the array of bytes.
        hashValue = shHash.ComputeHash(messageBytes);

        //Display the hash value to the console.
        foreach (byte b in hashValue)
        {
            Console.Write("{0} ", b);
        }
    }
}
//</Snippet1>
