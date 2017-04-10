using System;
using System.Data;
using System.ComponentModel;
using System.Security.Cryptography;

public class Sample
{
 protected int DATA_SIZE = 1024;

 protected void Method()
 {
// <Snippet1>
byte[] data = new byte[DATA_SIZE];
byte[] result; 
 
SHA1 sha = new SHA1CryptoServiceProvider(); 
// This is one implementation of the abstract class SHA1.
result = sha.ComputeHash(data);
// </Snippet1>

 }
}
