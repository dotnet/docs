// <Snippet1>
using System;
using System.IO;
using System.Text;

class MemStream
{
    static void Main()
    {
        int count;
        byte[] byteArray;
        char[] charArray;
        UnicodeEncoding uniEncoding = new UnicodeEncoding();

        // Create the data to write to the stream.
        byte[] firstString = uniEncoding.GetBytes(
            "Invalid file path characters are: ");
        byte[] secondString = uniEncoding.GetBytes(
            Path.GetInvalidPathChars());

        // <Snippet2>
        using(MemoryStream memStream = new MemoryStream(100))
        // </Snippet2>
        {
            // <Snippet3>
            // Write the first string to the stream.
            memStream.Write(firstString, 0 , firstString.Length);
            // </Snippet3>

            // <Snippet4>
            // Write the second string to the stream, byte by byte.
            count = 0;
            while(count < secondString.Length)
            {
                memStream.WriteByte(secondString[count++]);
            }
            // </Snippet4>

            // <Snippet5>
            // Write the stream properties to the console.
            Console.WriteLine(
                "Capacity = {0}, Length = {1}, Position = {2}\n",
                memStream.Capacity.ToString(),
                memStream.Length.ToString(),
                memStream.Position.ToString());
            // </Snippet5>

            // <Snippet6>
            // Set the position to the beginning of the stream.
            memStream.Seek(0, SeekOrigin.Begin);
            // </Snippet6>

            // <Snippet7>
            // Read the first 20 bytes from the stream.
            byteArray = new byte[memStream.Length];
            count = memStream.Read(byteArray, 0, 20);
            // </Snippet7>

            // <Snippet8>
            // Read the remaining bytes, byte by byte.
            while(count < memStream.Length)
            {
                byteArray[count++] =
                    Convert.ToByte(memStream.ReadByte());
            }
            // </Snippet8>

            // Decode the byte array into a char array
            // and write it to the console.
            charArray = new char[uniEncoding.GetCharCount(
                byteArray, 0, count)];
            uniEncoding.GetDecoder().GetChars(
                byteArray, 0, count, charArray, 0);
            Console.WriteLine(charArray);
        }
    }
}
// </Snippet1>