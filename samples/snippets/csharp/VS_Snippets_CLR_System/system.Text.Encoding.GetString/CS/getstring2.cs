// <Snippet3>
using System;
using System.IO;
using System.Text;

public class Example
{
   const int MAX_BUFFER_SIZE = 2048;
   static Encoding enc8 = Encoding.UTF8;
   static byte[] bytes = new byte[MAX_BUFFER_SIZE]; 

   public static void Main()
   {
      FileStream fStream = new FileStream(@".\Utf8Example.txt", FileMode.Open);
      string contents = null;
      
      // If file size is small, read in a single operation.
      if (fStream.Length <= MAX_BUFFER_SIZE) {
         int bytesRead = fStream.Read(bytes, 0, bytes.Length);
         contents = enc8.GetString(bytes, 0, bytesRead);
      }   
      // If file size exceeds buffer size, perform multiple reads.
      else {
         contents = ReadFromBuffer(fStream);
      }
      fStream.Close();
      Console.WriteLine(contents);
   }

    private static string ReadFromBuffer(FileStream fStream)
    {
        string output = String.Empty;
        Decoder decoder8 = enc8.GetDecoder();
      
        while (fStream.Position < fStream.Length) {
           int nBytes = fStream.Read(bytes, 0, bytes.Length);
           int nChars = decoder8.GetCharCount(bytes, 0, nBytes);
           char[] chars = new char[nChars];
           nChars = decoder8.GetChars(bytes, 0, nBytes, chars, 0);
           output += new String(chars, 0, nChars);                                                     
        }
        return output;
    }   
}
// The example displays the following output:
//     This is a UTF-8-encoded file that contains primarily Latin text, although it
//     does list the first twelve letters of the Russian (Cyrillic) alphabet:
//     
//     А б в г д е ё ж з и й к
//     
//     The goal is to save this file, then open and decode it as a binary stream.
// </Snippet3>
