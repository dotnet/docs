'<Snippet1>
Imports System.IO
Imports System.Security.Cryptography

Public Module HashDirectory

    Public Sub Main(ByVal args() As String)
        If args.Length < 1 Then
            Console.WriteLine("No directory selected")
            Return
        End If

        Dim targetDirectory As String = args(0)
        If Directory.Exists(targetDirectory) Then
            ' Create a DirectoryInfo object representing the specified directory.
            Dim dir As New DirectoryInfo(targetDirectory)
            ' Get the FileInfo objects for every file in the directory.
            Dim files As FileInfo() = dir.GetFiles()
            ' Initialize a SHA256 hash object.
            Using mySHA256 As SHA256 = SHA256.Create()
                ' Compute and print the hash values for each file in directory.
                For Each fInfo  As FileInfo In files
                    Try
                        ' Create a fileStream for the file.
                        Dim fileStream = fInfo.Open(FileMode.Open)
                        ' Be sure it's positioned to the beginning of the stream.
                        fileStream.Position = 0
                        ' Compute the hash of the fileStream.
                        Dim hashValue() As Byte = mySHA256.ComputeHash(fileStream)
                        ' Write the name of the file to the Console.
                        Console.Write(fInfo.Name + ": ")
                        ' Write the hash value to the Console.
                        PrintByteArray(hashValue)
                        ' Close the file.
                        fileStream.Close()
                    Catch e As IOException
                        Console.WriteLine($"I/O Exception: {e.Message}")
                    Catch e As UnauthorizedAccessException 
                        Console.WriteLine($"Access Exception: {e.Message}")
                    End Try    
                Next 
            End Using
        Else
           Console.WriteLine("The directory specified could not be found.")
        End If
    End Sub

    ' Print the byte array in a readable format.
    Public Sub PrintByteArray(array() As Byte)
        For i As Integer = 0 To array.Length - 1
            Console.Write($"{array(i):X2}")
            If i Mod 4 = 3 Then
                Console.Write(" ")
            End If
        Next 
        Console.WriteLine()

    End Sub 
End Module
'</Snippet1>