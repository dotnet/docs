// <Snippet2>
using System;
using System.IO;
using System.Text;

public class Example
{
   public static void Main()
   {
        // Create a UTF-16 encoding that supports a BOM.
        Encoding unicode = new UnicodeEncoding();

        // A Unicode string with two characters outside an 8-bit code range.
        String unicodeString =
            "This Unicode string has 2 characters outside the " +
            "ASCII range: \n" +
            "Pi (\u03A0)), and Sigma (\u03A3).";
        Console.WriteLine("Original string:");
        Console.WriteLine(unicodeString);
        Console.WriteLine();

        // Encode the string.
        Byte[] encodedBytes = unicode.GetBytes(unicodeString);
        Console.WriteLine("The encoded string has {0} bytes.\n",
                          encodedBytes.Length);

        // Write the bytes to a file with a BOM.
        var fs = new FileStream(@".\UTF8Encoding.txt", FileMode.Create);
        Byte[] bom = unicode.GetPreamble();
        fs.Write(bom, 0, bom.Length);
        fs.Write(encodedBytes, 0, encodedBytes.Length);
        Console.WriteLine("Wrote {0} bytes to the file.\n", fs.Length);
        fs.Close();

        // Open the file using StreamReader.
        var sr = new StreamReader(@".\UTF8Encoding.txt");
        String newString = sr.ReadToEnd();
        sr.Close();
        Console.WriteLine("String read using StreamReader:");
        Console.WriteLine(newString);
        Console.WriteLine();

        // Open the file as a binary file and decode the bytes back to a string.
        fs = new FileStream(@".\UTF8Encoding.txt", FileMode.Open);
        Byte[] bytes = new Byte[fs.Length];
        fs.Read(bytes, 0, (int)fs.Length);
        fs.Close();

        String decodedString = unicode.GetString(encodedBytes);
        Console.WriteLine("Decoded bytes:");
        Console.WriteLine(decodedString);
   }
}
// The example displays the following output:
//    Original string:
//    This Unicode string has 2 characters outside the ASCII range:
//    Pi (π), and Sigma (Σ).
//
//    The encoded string has 172 bytes.
//
//    Wrote 174 bytes to the file.
//
//    String read using StreamReader:
//    This Unicode string has 2 characters outside the ASCII range:
//    Pi (π), and Sigma (Σ).
//
//    Decoded bytes:
//    This Unicode string has 2 characters outside the ASCII range:
//    Pi (π), and Sigma (Σ).
// </Snippet2>
