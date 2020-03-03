#region Using directives

using System;
using System.Security.Cryptography.Pkcs;

#endregion

namespace mpkcs_SignedCMS
{
    class Program
    {
        static void Main(string[] args)
        {
        }

static void Test_CheckSignature1(byte[] encodedMessage)
{
//<Snippet1>
// Create a new, nondetached SignedCms message.
SignedCms signedCms = new SignedCms();

// encodedMessage is the encoded message received from 
// the sender.
signedCms.Decode(encodedMessage);

// Verify the signature without validating the 
// certificate.
signedCms.CheckSignature(true);
//</Snippet1>
}

static void Test_CheckSignature2(byte[] innerContent, byte[] encodedMessage)
{
//<Snippet2>
// Create a ContentInfo object from the inner content obtained 
// independently from encodedMessage.
ContentInfo contentInfo = new ContentInfo(innerContent);

// Create a new, detached SignedCms message.
SignedCms signedCms = new SignedCms(contentInfo, true);

// encodedMessage is the encoded message received from 
// the sender.
signedCms.Decode(encodedMessage);

// Verify the signature without validating the 
// certificate.
signedCms.CheckSignature(true);
//</Snippet2>
}

static void Test_ComputeSignature1(byte[] dataToSign)
{
//<Snippet3>
// The dataToSign byte array holds the data to be signed.
ContentInfo contentInfo = new ContentInfo(dataToSign);

// Create a new, nondetached SignedCms message.
SignedCms signedCms = new SignedCms(contentInfo);

// Sign the message.
signedCms.ComputeSignature();

// Encode the message.
byte[] myCmsMessage = signedCms.Encode();

// The signed CMS/PKCS #7 message is ready to send.
// The original content is included in this byte array.
//</Snippet3>
}

static void Test_ComputeSignature2(byte[] dataToSign)
{
//<Snippet4>
// The dataToSign byte array holds the data to be signed.
ContentInfo contentInfo = new ContentInfo(dataToSign);

// Create a new, detached SignedCms message.
SignedCms signedCms = new SignedCms(contentInfo, true);

// Sign the message.
signedCms.ComputeSignature();

// Encode the message.
byte[] myCmsMessage = signedCms.Encode();

// The signed CMS/PKCS #7 message is ready to send.
// The original content is not included in this byte array.
//</Snippet4>
}
}
}
