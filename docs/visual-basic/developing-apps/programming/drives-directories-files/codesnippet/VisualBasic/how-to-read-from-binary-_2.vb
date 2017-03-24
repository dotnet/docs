    ' This method does not trap for exceptions. If an exception is 
    ' encountered opening the file to be copied or writing to the 
    ' destination location, then the exception will be thrown to 
    ' the requestor.
    Public Sub CopyBinaryFile(ByVal path As String,
                              ByVal copyPath As String,
                              ByVal bufferSize As Integer,
                              ByVal overwrite As Boolean)

        Dim inputFile = IO.File.Open(path, IO.FileMode.Open)

        If overwrite AndAlso My.Computer.FileSystem.FileExists(copyPath) Then
            My.Computer.FileSystem.DeleteFile(copyPath)
        End If

        ' Adjust array length for VB array declaration.
        Dim bytes = New Byte(bufferSize - 1) {}

        While inputFile.Read(bytes, 0, bufferSize) > 0
            My.Computer.FileSystem.WriteAllBytes(copyPath, bytes, True)
        End While

        inputFile.Close()
    End Sub