using System;
using System.Security.Cryptography;
using System.Collections;
using System.Text;

class Members
{
    // Use a public service provider for encryption and decryption.
    static DESCryptoServiceProvider des = new DESCryptoServiceProvider();

    [STAThread]
    static void Main(string[] args)
    {
        string message = "012345678901234567890";
        byte[] sourceBytes = Encoding.ASCII.GetBytes(message);
        Console.WriteLine("** Phrase to be encoded: " + message);

        byte[] encodedBytes = EncodeBytes(sourceBytes);
        Console.WriteLine("** Phrase after encoding: " +
            Encoding.ASCII.GetString(encodedBytes));

        byte[] decodedBytes = DecodeBytes(encodedBytes);
        Console.WriteLine("** Phrase after decoding: " +
            Encoding.ASCII.GetString(decodedBytes));

        Console.WriteLine("Sample ended successfully; " +
            "press Enter to continue.");
        Console.ReadLine();
    }

    // Encode the specified byte array by using CryptoAPITranform.
    private static byte[] EncodeBytes(byte[] sourceBytes)
    {
        int currentPosition = 0;
        byte[] targetBytes = new byte[1024];
        int sourceByteLength = sourceBytes.Length;

        // Create a DES encryptor from this instance to perform encryption.
        CryptoAPITransform cryptoTransform =
            (CryptoAPITransform)des.CreateEncryptor();

        // Retrieve the block size to read the bytes.
        int inputBlockSize = cryptoTransform.InputBlockSize;

        // Retrieve the key handle.
        IntPtr keyHandle = cryptoTransform.KeyHandle;

        // Retrieve the block size to write the bytes.
        int outputBlockSize = cryptoTransform.OutputBlockSize;

        try
        {
            // Determine if multiple blocks can be transformed.
            if (cryptoTransform.CanTransformMultipleBlocks)
            {
                int numBytesRead = 0;
                while (sourceByteLength - currentPosition >= inputBlockSize)
                {
                    // Transform the bytes from currentPosition in the
                    // sourceBytes array, writing the bytes to the targetBytes
                    // array.
                    numBytesRead = cryptoTransform.TransformBlock(
                        sourceBytes,
                        currentPosition,
                        inputBlockSize,
                        targetBytes,
                        currentPosition);

                    // Advance the current position in the sourceBytes array.
                    currentPosition += numBytesRead;
                }

                // Transform the final block of bytes.
                byte[] finalBytes = cryptoTransform.TransformFinalBlock(
                    sourceBytes,
                    currentPosition,
                    sourceByteLength - currentPosition);

                // Copy the contents of the finalBytes array to the
                // targetBytes array.
                finalBytes.CopyTo(targetBytes, currentPosition);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught unexpected exception:" + ex.ToString());
        }

        // Determine if the current transform can be reused.
        if (!cryptoTransform.CanReuseTransform)
        {
            // Free up any used resources.
            cryptoTransform.Clear();
        }

        // Trim the extra bytes in the array that were not used.
        return TrimArray(targetBytes);
    }

    // Decode the specified byte array using CryptoAPITranform.
    private static byte[] DecodeBytes(byte[] sourceBytes)
    {
        byte[] targetBytes = new byte[1024];
        int currentPosition = 0;

        // Create a DES decryptor from this instance to perform decryption.
        CryptoAPITransform cryptoTransform =
            (CryptoAPITransform)des.CreateDecryptor();

        int inputBlockSize = cryptoTransform.InputBlockSize;
        int sourceByteLength = sourceBytes.Length;

        try
        {
            int numBytesRead = 0;
            while (sourceByteLength - currentPosition >= inputBlockSize)
            {
                // Transform the bytes from current position in the 
                // sourceBytes array, writing the bytes to the targetBytes
                // array.
                numBytesRead = cryptoTransform.TransformBlock(
                    sourceBytes,
                    currentPosition,
                    inputBlockSize,
                    targetBytes,
                    currentPosition);

                // Advance the current position in the source array.
                currentPosition += numBytesRead;
            }

            // Transform the final block of bytes.
            byte[] finalBytes = cryptoTransform.TransformFinalBlock(
                sourceBytes,
                currentPosition,
                sourceByteLength - currentPosition);

            // Copy the contents of the finalBytes array to the targetBytes
            // array.
            finalBytes.CopyTo(targetBytes, currentPosition);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught unexpected exception:" + ex.ToString());
        }

        // Strip out the second block of bytes.
        Array.Copy(targetBytes, (inputBlockSize * 2), targetBytes, inputBlockSize, targetBytes.Length - (inputBlockSize * 2));

        // Trim the extra bytes in the array that were not used.
        return TrimArray(targetBytes);
    }

    // Resize the dimensions of the array to a size that contains only valid
    // bytes.
    private static byte[] TrimArray(byte[] targetArray)
    {
        IEnumerator enum1 = targetArray.GetEnumerator();
        int i = 0;

        while (enum1.MoveNext())
        {
            if (enum1.Current.ToString().Equals("0"))
            {
                break;
            }
            i++;
        }

        // Create a new array with the number of valid bytes.
        byte[] returnedArray = new byte[i];
        for (int j = 0; j < i; j++)
        {
            returnedArray[j] = targetArray[j];
        }

        return returnedArray;
    }
}
//
// This sample produces the following output:
//
// ** Phrase to be encoded: 012345678901234567890
// ** Phrase after encoding: AIGC(+b7X?^djAU?15ve?o
// ** Phrase after decoding: 012345678901234567890
// Sample ended successfully; press Enter to continue.