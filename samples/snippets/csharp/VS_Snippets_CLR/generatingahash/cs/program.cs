//<Snippet1>
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Class1
{
    static void Main(string[] args)
    {
        byte[] HashValue;

        string MessageString = "This is the original message!";

        //Create a new instance of the UnicodeEncoding class to 
        //convert the string into an array of Unicode bytes.
        UnicodeEncoding UE = new UnicodeEncoding();

        //Convert the string into an array of bytes.
        byte[] MessageBytes = UE.GetBytes(MessageString);

        //Create a new instance of the SHA1Managed class to create 
        //the hash value.
        SHA1Managed SHhash = new SHA1Managed();

        //Create the hash value from the array of bytes.
        HashValue = SHhash.ComputeHash(MessageBytes);

        //Display the hash value to the console. 
        foreach (byte b in HashValue)
        {
            Console.Write("{0} ", b);
        }
    }
}
//</Snippet1>

