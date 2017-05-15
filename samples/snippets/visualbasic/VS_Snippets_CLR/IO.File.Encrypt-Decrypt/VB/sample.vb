'<SNIPPET1>
Imports System
Imports System.IO
Imports System.Security.AccessControl



Module FileExample

    Sub Main()
        Try
            Dim FileName As String = "test.xml"

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

        Console.ReadLine()

    End Sub


    ' Encrypt a file.
    Sub AddEncryption(ByVal FileName As String)

        File.Encrypt(FileName)

    End Sub


    ' Decrypt the file.
    Sub RemoveEncryption(ByVal FileName As String)

        File.Decrypt(FileName)

    End Sub
End Module
'</SNIPPET1>