Namespace UUCodeVB
   Class Coder
      Private inputFileName As String
      Private outputFileName As String

      Public Sub New(ByVal inFile As String, ByVal outFile As String)
         inputFileName = CStr(inFile.Clone())
         outputFileName = CStr(outFile.Clone())
      End Sub 'New

      '<Snippet3>
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
      '</Snippet3>

      '<Snippet4>
      Public Sub DecodeWithString()
         Dim inFile As System.IO.StreamReader
         Dim base64String As String

         Try
            Dim base64CharArray() As Char
            inFile = New System.IO.StreamReader(inputFileName, _
                                                System.Text.Encoding.ASCII)
            base64CharArray = New Char(inFile.BaseStream.Length) {}
            inFile.Read(base64CharArray, 0, inFile.BaseStream.Length)
            base64String = New String(base64CharArray, _
                                      0, _
                                      base64CharArray.Length - 1)
         Catch exp As System.Exception
            ' Error creating stream or reading from it.
            System.Console.WriteLine("{0}", exp.Message)
            Return
         End Try

         ' Convert the Base64 UUEncoded input into binary output.
         Dim binaryData() As Byte
         Try
            binaryData = System.Convert.FromBase64String(base64String)
         Catch exp As System.ArgumentNullException
            System.Console.WriteLine("Base 64 string is null.")
            Return
         Catch exp As System.FormatException
            System.Console.WriteLine("Base 64 length is not 4 or is " + _
                                     "not an even multiple of 4.")
            Return
         End Try

         'Write out the decoded data.
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
      '</Snippet4>

      '<Snippet2>
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
      '</Snippet2>

      '<Snippet1>
      Public Sub EncodeWithString()
         Dim inFile As System.IO.FileStream
         Dim binaryData() As Byte

         Try
            inFile = New System.IO.FileStream(inputFileName, _
                                              System.IO.FileMode.Open, _
                                              System.IO.FileAccess.Read)
            ReDim binaryData(inFile.Length)
            Dim bytesRead As Long = inFile.Read(binaryData, _
                                                0, _
                                                inFile.Length)
            inFile.Close()
         Catch exp As System.Exception
            ' Error creating stream or reading from it.
            System.Console.WriteLine("{0}", exp.Message)
            Return
         End Try

         ' Convert the binary input into Base64 UUEncoded output.
         Dim base64String As String
         Try
            base64String = System.Convert.ToBase64String(binaryData, _
                                                         0, _
                                                         binaryData.Length)
         Catch exp As System.ArgumentNullException
            System.Console.WriteLine("Binary data array is null.")
            Return
         End Try

         ' Write the UUEncoded version to the output file.
         Dim outFile As System.IO.StreamWriter
         Try
            outFile = New System.IO.StreamWriter(outputFileName, _
                                                 False, _
                                                 System.Text.Encoding.ASCII)
            outFile.Write(base64String)
            outFile.Close()
         Catch exp As System.Exception
            ' Error creating stream or writing to it.
            System.Console.WriteLine("{0}", exp.Message)
         End Try
      End Sub

      '</Snippet1>
      Public Overloads Shared Sub Main()
         Dim args() As String = System.Environment.GetCommandLineArgs()
            
         If args.Length <> 5 Then
            System.Console.WriteLine(("Usage: UUCodeC -d | -e " + "-s | -c inputFile outputFile"))
            Return
         End If

         Dim inputFileName As String = args(3)
         Dim outputFileName As String = args(4)
         Dim coder As New Coder(inputFileName, outputFileName)

         Select Case args(1)
            Case "-d"
               If args(2) = "-s" Then
                  coder.DecodeWithString()
               Else
                  If args(2) = "-c" Then
                     coder.DecodeWithCharArray()
                  Else
                     System.Console.WriteLine("Second arg must be -s or -c")
                     Return
                  End If
               End If
            Case "-e"
               If args(2) = "-s" Then
                  coder.EncodeWithString()
               Else
                  If args(2) = "-c" Then
                     coder.EncodeWithCharArray()
                  Else
                     System.Console.WriteLine("Second arg must be -s or -c")
                     Return
                  End If
               End If
            Case Else
               System.Console.WriteLine("First arg must be -d or -e")
         End Select
      End Sub 'Main

   End Class
End Namespace
