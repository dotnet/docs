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

        using(MemoryStream memStream = new MemoryStream(100))
        {
            // Write the first string to the stream.
            memStream.Write(firstString, 0 , firstString.Length);

            // Write the second string to the stream, byte by byte.
            count = 0;
            while(count < secondString.Length)
            {
                memStream.WriteByte(secondString[count++]);
            }

            // Write the stream properties to the console.
            Console.WriteLine(
                "Capacity = {0}, Length = {1}, Position = {2}\n",
                memStream.Capacity.ToString(),
                memStream.Length.ToString(),
                memStream.Position.ToString());

            // Set the position to the beginning of the stream.
            memStream.Seek(0, SeekOrigin.Begin);

            // Read the first 20 bytes from the stream.
            byteArray = new byte[memStream.Length];
            count = memStream.Read(byteArray, 0, 20);

            // Read the remaining bytes, byte by byte.
            while(count < memStream.Length)
            {
                byteArray[count++] =
                    Convert.ToByte(memStream.ReadByte());
            }

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