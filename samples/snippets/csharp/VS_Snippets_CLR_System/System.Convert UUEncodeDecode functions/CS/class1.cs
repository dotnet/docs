using System;

namespace UUCodeC
{
   class Coder
   {
      private string inputFileName;
      private string outputFileName;

      static void Main(string[] args)
      {
         if (args.Length != 4 ) {
            System.Console.WriteLine("Usage: UUCodeC -d | -e " +
                               "-s | -c inputFile outputFile");
            return;
         }

         string inputFileName = args[2];
         string outputFileName = args[3];
         Coder coder = new Coder(inputFileName, outputFileName);
         
         switch (args[0]) {
            case "-d": 
               if (args[1] == "-s") {
                  coder.DecodeWithString();
               } 
               else if (args[1] == "-c") {
                  coder.DecodeWithCharArray();
               } 
               else {
                  System.Console.WriteLine("Second arg must be -s or -c");
                  return;
               }
               break;
            case "-e":
               if (args[1] == "-s") {
                  coder.EncodeWithString();
               } 
               else if (args[1] == "-c") {
                  coder.EncodeWithCharArray();
               } 
               else {
                  System.Console.WriteLine("Second arg must be -s or -c");
                  return;
               }
               break;
            default: 
               System.Console.WriteLine("First arg must be -d or -e");
               break;
         }
      }

      public Coder (string inFile, string outFile) {
         inputFileName = (string) inFile.Clone();
         outputFileName = (string) outFile.Clone();
      }

      //<Snippet1>
      public void EncodeWithString() {
         System.IO.FileStream inFile;    
         byte[]             binaryData;

         try {
            inFile = new System.IO.FileStream(inputFileName,
                                      System.IO.FileMode.Open,
                                      System.IO.FileAccess.Read);
            binaryData = new Byte[inFile.Length];
            long bytesRead = inFile.Read(binaryData, 0,
                                 (int)inFile.Length);
            inFile.Close();
         }
         catch (System.Exception exp) {
            // Error creating stream or reading from it.
            System.Console.WriteLine("{0}", exp.Message);
            return;
         }

         // Convert the binary input into Base64 UUEncoded output.
         string base64String;
         try {
             base64String = 
               System.Convert.ToBase64String(binaryData, 
                                      0,
                                      binaryData.Length);
         }
         catch (System.ArgumentNullException) {
            System.Console.WriteLine("Binary data array is null.");
            return;
         }

         // Write the UUEncoded version to the output file.
         System.IO.StreamWriter outFile; 
         try {
            outFile = new System.IO.StreamWriter(outputFileName,
                                 false,
                                 System.Text.Encoding.ASCII);          
            outFile.Write(base64String);
            outFile.Close();
         }
         catch (System.Exception exp) {
            // Error creating stream or writing to it.
            System.Console.WriteLine("{0}", exp.Message);
         }
      }
      //</Snippet1>

      //<Snippet2>
      public void EncodeWithCharArray() {
         System.IO.FileStream inFile;    
         byte[]             binaryData;

         try {
            inFile = new System.IO.FileStream(inputFileName,
                                       System.IO.FileMode.Open,
                                      System.IO.FileAccess.Read);
            binaryData = new Byte[inFile.Length];
            long bytesRead = inFile.Read(binaryData, 0,
                                 (int) inFile.Length);
            inFile.Close();
         }
         catch (System.Exception exp) {
            // Error creating stream or reading from it.
            System.Console.WriteLine("{0}", exp.Message);
            return;
         }

         // Convert the binary input into Base64 UUEncoded output.
         // Each 3 byte sequence in the source data becomes a 4 byte
         // sequence in the character array. 
         long arrayLength = (long) ((4.0d/3.0d) * binaryData.Length);
         
         // If array length is not divisible by 4, go up to the next
         // multiple of 4.
         if (arrayLength % 4 != 0) {
            arrayLength += 4 - arrayLength % 4;
         }
         
         char[] base64CharArray = new char[arrayLength];
         try {
            System.Convert.ToBase64CharArray(binaryData, 
                                     0,
                                     binaryData.Length,
                                     base64CharArray,
                                     0);
         }
         catch (System.ArgumentNullException) {
            System.Console.WriteLine("Binary data array is null.");
            return;
         }
         catch (System.ArgumentOutOfRangeException) {
            System.Console.WriteLine("Char Array is not large enough.");
            return;
         }

         // Write the UUEncoded version to the output file.
         System.IO.StreamWriter outFile; 
         try {
            outFile = new System.IO.StreamWriter(outputFileName,
                                    false,
                                    System.Text.Encoding.ASCII);          
            outFile.Write(base64CharArray);
            outFile.Close();
         }
         catch (System.Exception exp) {
            // Error creating stream or writing to it.
            System.Console.WriteLine("{0}", exp.Message);
         }
      }
      //</Snippet2>

      //<Snippet3>
      public void DecodeWithCharArray() {
         System.IO.StreamReader inFile;    
         char[] base64CharArray;

         try {
            inFile = new System.IO.StreamReader(inputFileName,
                                    System.Text.Encoding.ASCII);
            base64CharArray = new char[inFile.BaseStream.Length];
            inFile.Read(base64CharArray, 0, (int)inFile.BaseStream.Length);
            inFile.Close();
         }
         catch (System.Exception exp) {
            // Error creating stream or reading from it.
            System.Console.WriteLine("{0}", exp.Message);
            return;
         }

         // Convert the Base64 UUEncoded input into binary output.
         byte[] binaryData;
         try {
            binaryData = 
               System.Convert.FromBase64CharArray(base64CharArray,
                                          0,
                                          base64CharArray.Length);
         }
         catch ( System.ArgumentNullException ) {
            System.Console.WriteLine("Base 64 character array is null.");
            return;
         }
         catch ( System.FormatException ) {
            System.Console.WriteLine("Base 64 Char Array length is not " +
               "4 or is not an even multiple of 4." );
            return;
         }

         // Write out the decoded data.
         System.IO.FileStream outFile;
         try {
            outFile = new System.IO.FileStream(outputFileName,
                                       System.IO.FileMode.Create,
                                       System.IO.FileAccess.Write);
            outFile.Write(binaryData, 0, binaryData.Length);
            outFile.Close();
         }
         catch (System.Exception exp) {
            // Error creating stream or writing to it.
            System.Console.WriteLine("{0}", exp.Message);
         }
      }
      //</Snippet3>

      //<Snippet4>
      public void DecodeWithString() {
         System.IO.StreamReader inFile;    
         string base64String;

         try {
            char[] base64CharArray;
            inFile = new System.IO.StreamReader(inputFileName,
                                    System.Text.Encoding.ASCII);
            base64CharArray = new char[inFile.BaseStream.Length];
            inFile.Read(base64CharArray, 0, (int)inFile.BaseStream.Length);
            base64String = new string(base64CharArray);
         }
         catch (System.Exception exp) {
            // Error creating stream or reading from it.
            System.Console.WriteLine("{0}", exp.Message);
            return;
         }

         // Convert the Base64 UUEncoded input into binary output.
         byte[] binaryData;
         try {
            binaryData = 
               System.Convert.FromBase64String(base64String);
         }
         catch (System.ArgumentNullException) {
            System.Console.WriteLine("Base 64 string is null.");
            return;
         }
         catch (System.FormatException) {
            System.Console.WriteLine("Base 64 string length is not " +
               "4 or is not an even multiple of 4." );
            return;
         }

         // Write out the decoded data.
         System.IO.FileStream outFile;
         try {
            outFile = new System.IO.FileStream(outputFileName,
                                       System.IO.FileMode.Create,
                                       System.IO.FileAccess.Write);
            outFile.Write(binaryData, 0, binaryData.Length);
            outFile.Close();
         }
         catch (System.Exception exp) {
            // Error creating stream or writing to it.
            System.Console.WriteLine("{0}", exp.Message);
         }
      }
      //</Snippet4>
   }
}
