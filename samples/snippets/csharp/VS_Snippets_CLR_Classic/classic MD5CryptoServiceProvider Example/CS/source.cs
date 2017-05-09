using System;
using System.Windows.Forms;
using System.Security.Policy;
using System.Security.Cryptography;


public class Form1: Form
{
// <Snippet1>
byte[] MD5hash (byte[] data)
 {
    // This is one implementation of the abstract class MD5.
    MD5 md5 = new MD5CryptoServiceProvider();

    byte[] result = md5.ComputeHash(data);

    return result;
 }
// </Snippet1>
}
