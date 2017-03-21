      Public Sub DecodeWithCharArray()
         Dim inFile As System.IO.StreamReader
         Dim base64CharArray() As Char

         Try
            inFile = New System.IO.StreamReader(inputFileName, _
                                                System.Text.Encoding.ASCII)

            ReDim base64CharArray(inFile.BaseStream.Length - 1)
            inFile.Read(base64CharArray, 0, inFile.BaseStream.Length)
            inFile.Close()
         Catch exp As System.Exception
            ' Error creating stream or reading from it.
            System.Console.WriteLine("{0}", exp.Message)
            Return
         End Try

         ' Convert the Base64 UUEncoded input into binary output.
         Dim binaryData() As Byte
         Try
            binaryData = System.Convert.FromBase64CharArray(base64CharArray, 0, _
                                                      base64CharArray.Length)
         Catch exp As System.ArgumentNullException
            System.Console.WriteLine("Base 64 character array is null.")
            Return
         Catch exp As System.FormatException
            System.Console.WriteLine("Base 64 Char Array length is not " + _
                     "4 or is not an even multiple of 4")
            Return
         End Try

         ' Write out the decoded data.
         Dim outFile As System.IO.FileStream
         Try
            outFile = New System.IO.FileStream(outputFileName, _
                                               System.IO.FileMode.Create, _
                                               System.IO.FileAccess.Write)
            outFile.Write(binaryData, 0, binaryData.Length - 1)
            outFile.Close()
         Catch exp As System.Exception
            ' Error creating stream or writing to it.
            System.Console.WriteLine("{0}", exp.Message)
         End Try
      End Sub