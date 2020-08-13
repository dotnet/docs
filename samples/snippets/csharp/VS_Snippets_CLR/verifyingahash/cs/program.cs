//<Snippet1>
using System;
using System.Security.Cryptography;
using System.Text;

class Class1
{
    static void Main()
    {
        //This hash value is produced from "This is the original message!"
        //using SHA256.
        byte[] sentHashValue = { 185, 203, 236, 22, 3, 228, 27, 130, 87, 23, 244, 15, 87, 88, 14, 43, 37, 61, 106, 224, 81, 172, 224, 211, 104, 85, 194, 197, 194, 25, 120, 217 };

        //This is the string that corresponds to the previous hash value.
        string messageString = "This is the original message!";

        byte[] compareHashValue;

        //Create a new instance of the UnicodeEncoding class to
        //convert the string into an array of Unicode bytes.
        UnicodeEncoding ue = new UnicodeEncoding();

        //Convert the string into an array of bytes.
        byte[] messageBytes = ue.GetBytes(messageString);

        //Create a new instance of the SHA256 class to create
        //the hash value.
        SHA256 shHash = SHA256.Create();

        //Create the hash value from the array of bytes.
        compareHashValue = shHash.ComputeHash(messageBytes);

        bool same = true;

        //Compare the values of the two byte arrays.
        for (int x = 0; x < sentHashValue.Length; x++)
        {
            if (sentHashValue[x] != compareHashValue[x])
            {
                same = false;
            }
        }
        //Display whether or not the hash values are the same.
        if (same)
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
