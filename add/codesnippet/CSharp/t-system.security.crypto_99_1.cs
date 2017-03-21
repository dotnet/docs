byte[] data = new byte[DATA_SIZE];
byte[] result; 
 
SHA1 sha = new SHA1CryptoServiceProvider(); 
// This is one implementation of the abstract class SHA1.
result = sha.ComputeHash(data);