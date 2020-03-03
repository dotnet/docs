//<Snippet1>
using System;
using System.Security.Cryptography;

public class TestHMACMD5
{
    static private void PrintByteArray(Byte[] arr)
    {
        int i;
        Console.WriteLine("Length: " + arr.Length);
        for (i = 0; i < arr.Length; i++)
        {
            Console.Write("{0:X}", arr[i]);
            Console.Write("    ");
            if ((i + 9) % 8 == 0) Console.WriteLine();
        }
        if (i % 8 != 0) Console.WriteLine();
    }
    public static void Main()
    {
        // Create a key.
        byte[] key1 = { 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b, 0x0b };
        // Pass the key to the constructor of the HMACMD5 class.  
        HMACMD5 hmac1 = new HMACMD5(key1);

        // Create another key.
        byte[] key2 = System.Text.Encoding.ASCII.GetBytes("KeyString");
        // Pass the key to the constructor of the HMACMD5 class.  
        HMACMD5 hmac2 = new HMACMD5(key2);

        // Encode a string into a byte array, create a hash of the array,
        // and print the hash to the screen.
        byte[] data1 = System.Text.Encoding.ASCII.GetBytes("Hi There");
        PrintByteArray(hmac1.ComputeHash(data1));

        // Encode a string into a byte array, create a hash of the array,
        // and print the hash to the screen.
        byte[] data2 = System.Text.Encoding.ASCII.GetBytes("This data will be hashed.");
        PrintByteArray(hmac2.ComputeHash(data2));
    }
}
public class HMACMD5 : KeyedHashAlgorithm
{
    private MD5 hash1;
    private MD5 hash2;
    private bool bHashing = false;

    private byte[] rgbInner = new byte[64];
    private byte[] rgbOuter = new byte[64];

    public HMACMD5(byte[] rgbKey)
    {
        HashSizeValue = 128;
        // Create the hash algorithms.
        hash1 = MD5.Create();
        hash2 = MD5.Create();
        // Get the key.
        if (rgbKey.Length > 64)
        {
            KeyValue = hash1.ComputeHash(rgbKey);
            // No need to call Initialize; ComputeHash does it automatically.
        }
        else
        {
            KeyValue = (byte[])rgbKey.Clone();
        }
        // Compute rgbInner and rgbOuter.
        int i = 0;
        for (i = 0; i < 64; i++)
        {
            rgbInner[i] = 0x36;
            rgbOuter[i] = 0x5C;
        }
        for (i = 0; i < KeyValue.Length; i++)
        {
            rgbInner[i] ^= KeyValue[i];
            rgbOuter[i] ^= KeyValue[i];
        }
    }

    public override byte[] Key
    {
        get { return (byte[])KeyValue.Clone(); }
        set
        {
            if (bHashing)
            {
                throw new Exception("Cannot change key during hash operation");
            }
            if (value.Length > 64)
            {
                KeyValue = hash1.ComputeHash(value);
                // No need to call Initialize; ComputeHash does it automatically.
            }
            else
            {
                KeyValue = (byte[])value.Clone();
            }
            // Compute rgbInner and rgbOuter.
            int i = 0;
            for (i = 0; i < 64; i++)
            {
                rgbInner[i] = 0x36;
                rgbOuter[i] = 0x5C;
            }
            for (i = 0; i < KeyValue.Length; i++)
            {
                rgbInner[i] ^= KeyValue[i];
                rgbOuter[i] ^= KeyValue[i];
            }
        }
    }
    public override void Initialize()
    {
        hash1.Initialize();
        hash2.Initialize();
        bHashing = false;
    }
    protected override void HashCore(byte[] rgb, int ib, int cb)
    {
        if (bHashing == false)
        {
            hash1.TransformBlock(rgbInner, 0, 64, rgbInner, 0);
            bHashing = true;
        }
        hash1.TransformBlock(rgb, ib, cb, rgb, ib);
    }

    protected override byte[] HashFinal()
    {
        if (bHashing == false)
        {
            hash1.TransformBlock(rgbInner, 0, 64, rgbInner, 0);
            bHashing = true;
        }
        // Finalize the original hash.
        hash1.TransformFinalBlock(new byte[0], 0, 0);
        // Write the outer array.
        hash2.TransformBlock(rgbOuter, 0, 64, rgbOuter, 0);
        // Write the inner hash and finalize the hash.
        hash2.TransformFinalBlock(hash1.Hash, 0, hash1.Hash.Length);
        bHashing = false;
        return hash2.Hash;
    }
}
//</Snippet1>