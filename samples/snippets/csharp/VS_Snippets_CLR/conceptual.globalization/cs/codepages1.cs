// <Snippet1>
using System;
using System.IO;
using System.Text;

public class Example
{
    public static void Main()
    {
        // Represent Greek uppercase characters in code page 737.
        char[] greekChars = { 'Α', 'Β', 'Γ', 'Δ', 'Ε', 'Ζ', 'Η', 'Θ',
                            'Ι', 'Κ', 'Λ', 'Μ', 'Ν', 'Ξ', 'Ο', 'Π',
                            'Ρ', 'Σ', 'Τ', 'Υ', 'Φ', 'Χ', 'Ψ', 'Ω' };

        Encoding cp737 = Encoding.GetEncoding(737);
        int nBytes = cp737.GetByteCount(greekChars);
        byte[] bytes737 = new byte[nBytes];
        bytes737 = cp737.GetBytes(greekChars);
        // Write the bytes to a file.
        FileStream fs = new FileStream(@".\\CodePageBytes.dat", FileMode.Create);
        fs.Write(bytes737, 0, bytes737.Length);
        fs.Close();

        // Retrieve the byte data from the file.
        fs = new FileStream(@".\\CodePageBytes.dat", FileMode.Open);
        byte[] bytes1 = new byte[fs.Length];
        fs.Read(bytes1, 0, (int)fs.Length);
        fs.Close();

        // Restore the data on a system whose code page is 737.
        string data = cp737.GetString(bytes1);
        Console.WriteLine(data);
        Console.WriteLine();

        // Restore the data on a system whose code page is 1252.
        Encoding cp1252 = Encoding.GetEncoding(1252);
        data = cp1252.GetString(bytes1);
        Console.WriteLine(data);
    }
}
// The example displays the following output:
//       ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ
//       €‚ƒ„…†‡ˆ‰Š‹ŒŽ‘’""•–—

// </Snippet1>
