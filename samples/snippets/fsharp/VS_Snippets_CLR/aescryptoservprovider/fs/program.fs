//<Snippet1>
open System
open System.IO
open System.Security.Cryptography

//<Snippet2>
let encryptStringToBytes_Aes (plainText: string, key : byte[], iv : byte[]) : byte[] =

    // Check arguments.
    if (isNull plainText || plainText.Length <= 0) then nullArg "plainText"
    if (isNull key || key.Length <= 0) then nullArg "key"
    if (isNull iv || iv.Length <= 0) then nullArg "iv"
    
    // Create an AesCryptoServiceProvider object
    // with the specified key and IV.
    use aesAlg = new AesCryptoServiceProvider()
    aesAlg.Key <- key
    aesAlg.IV <- iv

    // Create an encryptor to perform the stream transform.
    let encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)

    // Create the streams used for encryption.
    use msEncrypt = new MemoryStream()
    use csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
    use swEncrypt = new StreamWriter(csEncrypt)
    
    //Write all data to the stream.
    swEncrypt.Write(plainText)
    swEncrypt.Flush()
    
    // Return the encrypted bytes from the memory stream.
    msEncrypt.ToArray()
//</Snippet2>

//<Snippet3>
let decryptStringFromBytes_Aes (cipherText : byte[], key : byte[], iv : byte[]) : string =

    // Check arguments.
    if (isNull cipherText || cipherText.Length <= 0) then nullArg "cipherText"
    if (isNull key || key.Length <= 0) then nullArg "key"
    if (isNull iv || iv.Length <= 0) then nullArg "iv"

    // Create an AesCryptoServiceProvider object
    // with the specified key and IV.
    use aesAlg = new AesCryptoServiceProvider()
    aesAlg.Key <- key
    aesAlg.IV <- iv

    // Create a decryptor to perform the stream transform.
    let decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

    // Create the streams used for decryption.
    use msDecrypt = new MemoryStream(cipherText)
    use csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
    use srDecrypt = new StreamReader(csDecrypt)

    // Read the decrypted bytes from the decrypting stream
    // and return the resulting string.
    srDecrypt.ReadToEnd()
//</Snippet3>

[<EntryPoint>]
let main argv = 

    let original = "Here is some data to encrypt!"

    // Create a new instance of the AesCryptoServiceProvider
    // class.  This generates a new key and initialization 
    // vector (IV).
    use myAes = new AesCryptoServiceProvider()

    // Encrypt the string to an array of bytes.
    let encrypted = encryptStringToBytes_Aes(original, myAes.Key, myAes.IV)

    // Decrypt the bytes to a string.
    let roundtrip = decryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV)

    //Display the original data and the decrypted data.
    Console.WriteLine("Original:   {0}", original)
    Console.WriteLine("Round Trip: {0}", roundtrip)
    0
//</Snippet1>
