//<snippet4>
using System;
using System.IO;
using System.Text;

public class BinReadWrite
{
    public static void Main()
    {
        string testfile = @"C:\testfile.bin";

        // create a test file using BinaryWriter
        FileStream fs = File.Create(testfile);
        UTF8Encoding utf8 = new UTF8Encoding();

        BinaryWriter bw = new BinaryWriter(fs, utf8);
        string bstring;

        bstring  = "This is line #1 of text written as a binary stream.\r\n";
        bstring += "This is line #2 of text written as a binary stream.\r\n";
        bstring += "This is line #3 of text written as a binary stream.";
        bw.Write(bstring);

        // reset the stream position for reading
        fs.Seek(0, SeekOrigin.Begin);

        // Read the string as raw bytes using FileStream...
        // The first series of bytes is the UTF7 encoded length of the
        // string. In this case, however, it is just the first two bytes.
        int len = fs.ReadByte() & 0x7f;
        len += fs.ReadByte() * 0x80;
        // read the string as bytes of length = len
        byte[] rawbytes = new byte[len];
        fs.Read(rawbytes, 0, len);

        // display the string
        Console.WriteLine("Read from FileStream:   \n" + utf8.GetString(rawbytes));
        Console.WriteLine();

        // Now, read the string using BinaryReader

        // reset the stream position for reading again
        fs.Seek(0, SeekOrigin.Begin);

        BinaryReader br = new BinaryReader(fs, utf8);
        // ReadString will read the length prefix and return the string.
        bstring = br.ReadString();
        Console.WriteLine("Read from BinaryReader: \n" + bstring);
        fs.Close();
    }
}

//The output from the program is this:
//
// Read from FileStream:
// This is line #1 of text written as a binary stream.
// This is line #2 of text written as a binary stream.
// This is line #3 of text written as a binary stream.
//
// Read from BinaryReader:
// This is line #1 of text written as a binary stream.
// This is line #2 of text written as a binary stream.
// This is line #3 of text written as a binary stream.
//</snippet4>
