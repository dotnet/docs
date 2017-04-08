//<Snippet1>
using System;
using System.Security.Cryptography;
using System.Text;

class Class1
{
    static void Main()
    {
        //This hash value is produced from "This is the original message!" 
        //using SHA1Managed.  
        byte[] SentHashValue = { 59, 4, 248, 102, 77, 97, 142, 201, 210, 12, 224, 93, 25, 41, 100, 197, 213, 134, 130, 135 };

        //This is the string that corresponds to the previous hash value.
        string MessageString = "This is the original message!";

        byte[] CompareHashValue;

        //Create a new instance of the UnicodeEncoding class to 
        //convert the string into an array of Unicode bytes.
        UnicodeEncoding UE = new UnicodeEncoding();

        //Convert the string into an array of bytes.
        byte[] MessageBytes = UE.GetBytes(MessageString);

        //Create a new instance of the SHA1Managed class to create 
        //the hash value.
        SHA1Managed SHhash = new SHA1Managed();

        //Create the hash value from the array of bytes.
        CompareHashValue = SHhash.ComputeHash(MessageBytes);

        bool Same = true;

        //Compare the values of the two byte arrays.
        for (int x = 0; x < SentHashValue.Length; x++)
        {
            if (SentHashValue[x] != CompareHashValue[x])
            {
                Same = false;
            }
        }
        //Display whether or not the hash values are the same.
        if (Same)
        {
            Console.WriteLine("The hash codes match.");
        }
        else
        {
            Console.WriteLine("The hash codes do not match.");
        }
    }
}
//</Snippet1>

