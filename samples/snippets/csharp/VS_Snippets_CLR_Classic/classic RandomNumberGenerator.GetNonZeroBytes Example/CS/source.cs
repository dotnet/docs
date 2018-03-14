using System;
using System.Data;
using System.Security.Cryptography ;
using System.Windows.Forms;

public class Form1: Form
{
 public void Method()
 {
// <Snippet1>
    byte[] random = new Byte[100];
    //RNGCryptoServiceProvider is an implementation of a random number generator.
    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
    rng.GetNonZeroBytes(random); // The array is now filled with cryptographically strong random bytes, and none are zero.
// </Snippet1>

 }
}
