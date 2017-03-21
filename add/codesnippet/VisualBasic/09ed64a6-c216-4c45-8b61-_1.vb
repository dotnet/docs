      Public Sub EncodeWithCharArray()
         Dim inFile As System.IO.FileStream
         Dim binaryData() As Byte

         Try
            inFile = New System.IO.FileStream(inputFileName, _
                                              System.IO.FileMode.Open, _
                                              System.IO.FileAccess.Read)
            ReDim binaryData(inFile.Length)
            Dim bytesRead As Long = inFile.Read(binaryData, _
                                                0, _
                                                CInt(inFile.Length))
            inFile.Close()
         Catch exp As System.Exception
            ' Error creating stream or reading from it.
            System.Console.WriteLine("{0}", exp.Message)
            Return
         End Try

         ' Convert the binary input into Base64 UUEncoded output.
         ' Each 3 byte sequence in the source data becomes a 4 byte
         ' sequence in the character array. 
         Dim arrayLength As Long 
         arrayLength = (4 / 3) * binaryData.Length
         If arrayLength Mod 4 <> 0 Then
            arrayLength = arrayLength + 4 - arrayLength Mod 4
         End If

         Dim base64CharArray(arrayLength - 1) As Char
         Try
            System.Convert.ToBase64CharArray(binaryData, _
                                             0, _
                                             binaryData.Length, _
                                             base64CharArray, 0)
         Catch exp As System.ArgumentNullException
            System.Console.WriteLine("Binary data array is null.")
            Return
         Catch exp As System.ArgumentOutOfRangeException
            System.Console.WriteLine("Char Array is not large enough.")
            Return
         End Try

         ' Write the UUEncoded version to the output file.
         Dim outFile As System.IO.StreamWriter
         Try
            outFile = New System.IO.StreamWriter(outputFileName, _
                                                 False, _
                                                 System.Text.Encoding.ASCII)
            outFile.Write(base64CharArray)
            outFile.Close()
         Catch exp As System.Exception
            ' Error creating stream or writing to it.
            System.Console.WriteLine("{0}", exp.Message)
         End Try
      End Sub