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