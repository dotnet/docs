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