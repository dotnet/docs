'<snippet1>
Imports System.IO
Imports System.Security.Cryptography

Friend Class Members
    <STAThread()> _
    Shared Sub Main(ByVal args() As String)
        Dim appPath As String = (System.IO.Directory.GetCurrentDirectory())
        appPath = appPath & "..\\..\\..\"
        ' Insert your file names into this method call.
        EncodeFromFile(appPath & "program.vb", appPath & "code.enc")
        DecodeFromFile(appPath & "code.enc", appPath & "roundtrip.txt")

    End Sub

    ' Read in the specified source file and write out an encoded target file.
    Private Shared Sub EncodeFromFile(ByVal sourceFile As String, ByVal targetFile As String)
        ' Verify members.cs exists at the specified directory.
        If Not File.Exists(sourceFile) Then
            Console.Write("Unable to locate source file located at ")
            Console.WriteLine(sourceFile & ".")
            Console.Write("Please correct the path and run the ")
            Console.WriteLine("sample again.")
            Return
        End If

        ' Retrieve the input and output file streams.
        Using inputFileStream As New FileStream(sourceFile, FileMode.Open, FileAccess.Read)
            Using outputFileStream As New FileStream(targetFile, FileMode.Create, FileAccess.Write)

                ' Create a new ToBase64Transform object to convert to base 64.
                Dim base64Transform As New ToBase64Transform()

                ' Create a new byte array with the size of the output block size.
                Dim outputBytes(base64Transform.OutputBlockSize - 1) As Byte

                ' Retrieve the file contents into a byte array.
                Dim inputBytes(inputFileStream.Length - 1) As Byte
                inputFileStream.Read(inputBytes, 0, inputBytes.Length)

                ' Verify that multiple blocks can not be transformed.
                If Not base64Transform.CanTransformMultipleBlocks Then
                    ' Initializie the offset size.
                    Dim inputOffset As Integer = 0

                    ' Iterate through inputBytes transforming by blockSize.
                    Dim inputBlockSize As Integer = base64Transform.InputBlockSize

                    Do While inputBytes.Length - inputOffset > inputBlockSize
                        base64Transform.TransformBlock(inputBytes, inputOffset, inputBytes.Length - inputOffset, outputBytes, 0)

                        inputOffset += base64Transform.InputBlockSize
                        outputFileStream.Write(outputBytes, 0, base64Transform.OutputBlockSize)
                    Loop

                    ' Transform the final block of data.
                    outputBytes = base64Transform.TransformFinalBlock(inputBytes, inputOffset, inputBytes.Length - inputOffset)

                    outputFileStream.Write(outputBytes, 0, outputBytes.Length)
                    Console.WriteLine("Created encoded file at " & targetFile)
                End If

                ' Determine if the current transform can be reused.
                If Not base64Transform.CanReuseTransform Then
                    ' Free up any used resources.
                    base64Transform.Clear()
                End If
            End Using
        End Using

    End Sub

    Public Shared Sub DecodeFromFile(ByVal inFileName As String, ByVal outFileName As String)
        Using myTransform As New FromBase64Transform(FromBase64TransformMode.IgnoreWhiteSpaces)

            Dim myOutputBytes(myTransform.OutputBlockSize - 1) As Byte

            'Open the input and output files.
            Using myInputFile As New FileStream(inFileName, FileMode.Open, FileAccess.Read)
                Using myOutputFile As New FileStream(outFileName, FileMode.Create, FileAccess.Write)

                    'Retrieve the file contents into a byte array. 
                    Dim myInputBytes(myInputFile.Length - 1) As Byte
                    myInputFile.Read(myInputBytes, 0, myInputBytes.Length)

                    'Transform the data in chunks the size of InputBlockSize. 
                    Dim i As Integer = 0
                    Do While myInputBytes.Length - i > 4 'myTransform.InputBlockSize
                        Dim bytesWritten As Int32 = myTransform.TransformBlock(myInputBytes, i, 4, myOutputBytes, 0) 'myTransform.InputBlockSize
                        i += 4 'myTransform.InputBlockSize
                        myOutputFile.Write(myOutputBytes, 0, bytesWritten)
                    Loop

                    'Transform the final block of data.
                    myOutputBytes = myTransform.TransformFinalBlock(myInputBytes, i, myInputBytes.Length - i)
                    myOutputFile.Write(myOutputBytes, 0, myOutputBytes.Length)

                    'Free up any used resources.
                    myTransform.Clear()
                End Using
            End Using
        End Using

    End Sub
End Class

'</snippet1>
