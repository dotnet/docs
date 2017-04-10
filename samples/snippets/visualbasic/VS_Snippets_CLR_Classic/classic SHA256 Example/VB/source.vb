'<Snippet1>
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class HashDirectory

    Public Shared Sub Main(ByVal args() As String)
        Dim directory As String
        If args.Length < 1 Then
            Dim fdb As New FolderBrowserDialog
            Dim dr As DialogResult = fdb.ShowDialog()
            If (dr = DialogResult.OK) Then
                directory = fdb.SelectedPath
            Else
                Console.WriteLine("No directory selected")
                Return
            End If
        Else
            directory = args(0)
        End If
        Try
            ' Create a DirectoryInfo object representing the specified directory.
            Dim dir As New DirectoryInfo(directory)
            ' Get the FileInfo objects for every file in the directory.
            Dim files As FileInfo() = dir.GetFiles()
            ' Initialize a SHA256 hash object.
            Dim mySHA256 As SHA256 = SHA256Managed.Create()
            Dim hashValue() As Byte
            ' Compute and print the hash values for each file in directory.
            Dim fInfo As FileInfo
            For Each fInfo In files
                ' Create a fileStream for the file.
                Dim fileStream As FileStream = fInfo.Open(FileMode.Open)
                ' Be sure it's positioned to the beginning of the stream.
                fileStream.Position = 0
                ' Compute the hash of the fileStream.
                hashValue = mySHA256.ComputeHash(fileStream)
                ' Write the name of the file to the Console.
                Console.Write(fInfo.Name + ": ")
                ' Write the hash value to the Console.
                PrintByteArray(hashValue)
                ' Close the file.
                fileStream.Close()
            Next fInfo
            Return
        Catch DExc As DirectoryNotFoundException
            Console.WriteLine("Error: The directory specified could not be found.")
        Catch IOExc As IOException
            Console.WriteLine("Error: A file in the directory could not be accessed.")
        End Try

    End Sub

    ' Print the byte array in a readable format.
    Public Shared Sub PrintByteArray(ByVal array() As Byte)
        Dim i As Integer
        For i = 0 To array.Length - 1
            Console.Write(String.Format("{0:X2}", array(i)))
            If i Mod 4 = 3 Then
                Console.Write(" ")
            End If
        Next i
        Console.WriteLine()

    End Sub 'PrintByteArray
End Class
'</Snippet1>