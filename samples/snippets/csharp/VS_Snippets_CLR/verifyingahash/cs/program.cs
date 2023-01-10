//<Snippet1>
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

//This hash value is produced from "This is the original message!"
//using SHA256.
byte[] sentHashValue = Convert.FromHexString("67A1790DCA55B8803AD024EE28F616A284DF5DD7B8BA5F68B4B252A5E925AF79");

//This is the string that corresponds to the previous hash value.
string messageString = "This is the original message!";

//Convert the string into an array of bytes.
byte[] messageBytes = Encoding.UTF8.GetBytes(messageString);

//Create the hash value from the array of bytes.
byte[] compareHashValue = SHA256.HashData(messageBytes);

//Compare the values of the two byte arrays.
bool same = sentHashValue.SequenceEqual(compareHashValue);

//Display whether or not the hash values are the same.
if (same)
{
    Console.WriteLine("The hash codes match.");
}
else
{
    Console.WriteLine("The hash codes do not match.");
}
//</Snippet1>
