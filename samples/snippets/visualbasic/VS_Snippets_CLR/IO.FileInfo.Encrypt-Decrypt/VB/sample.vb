'<SNIPPET1>
Imports System
Imports System.IO
Imports System.Security.AccessControl



Module FileExample

    Sub Main()
        Try
            Dim FileName As String = "c:\MyTest.txt"

            Console.WriteLine("Encrypt " + FileName)

            ' Encrypt the file.
            AddEncryption(FileName)

            Console.WriteLine("Decrypt " + FileName)

            ' Decrypt the file.
            RemoveEncryption(FileName)

            Console.WriteLine("Done")
        Catch e As Exception
            Console.WriteLine(e)
        End Try

    End Sub



    Sub AddEncryption(ByVal FileName As String)
        ' Create a new FileInfo object.
        Dim fInfo As New FileInfo(FileName)
        If fInfo.Exists = False Then
            fInfo.Create()
        End If
        ' Add encryption.
        fInfo.Encrypt()

    End Sub



    Sub RemoveEncryption(ByVal FileName As String)
        ' Create a new FileInfo object.
        Dim fInfo As New FileInfo(FileName)
        If fInfo.Exists = False Then
            fInfo.Create()
        End If
        ' Remove encryption.
        fInfo.Decrypt()

    End Sub
End Module
'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'Encrypt c:\MyTest.txt
'Decrypt c:\MyTest.txt
'Done
'</SNIPPET1>