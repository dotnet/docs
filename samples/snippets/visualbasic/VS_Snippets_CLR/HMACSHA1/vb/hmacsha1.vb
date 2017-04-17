'<SNIPPET1>
Imports System
Imports System.IO
Imports System.Security.Cryptography

Public Class HMACSHA1example

    Public Shared Sub Main(ByVal Fileargs() As String)
        Dim dataFile As String
        Dim signedFile As String
        'If no file names are specified, create them.
        If Fileargs.Length < 2 Then
            dataFile = "text.txt"
            signedFile = "signedFile.enc"

            If Not File.Exists(dataFile) Then
                ' Create a file to write to.
                Using sw As StreamWriter = File.CreateText(dataFile)
                    sw.WriteLine("Here is a message to sign")
                End Using
            End If

        Else
            dataFile = Fileargs(0)
            signedFile = Fileargs(1)
        End If
        Try
            ' Create a random key using a random number generator. This would be the
            '  secret key shared by sender and receiver.
            Dim secretkey() As Byte = New [Byte](63) {}
            'RNGCryptoServiceProvider is an implementation of a random number generator.
            Using rng As New RNGCryptoServiceProvider()
                ' The array is now filled with cryptographically strong random bytes.
                rng.GetBytes(secretkey)

                ' Use the secret key to encode the message file.
                SignFile(secretkey, dataFile, signedFile)

                ' Take the encoded file and decode
                VerifyFile(secretkey, signedFile)
            End Using
        Catch e As IOException
            Console.WriteLine("Error: File not found", e)
        End Try

    End Sub 'Main

    ' Computes a keyed hash for a source file and creates a target file with the keyed hash
    ' prepended to the contents of the source file. 
    Public Shared Sub SignFile(ByVal key() As Byte, ByVal sourceFile As String, ByVal destFile As String)
        ' Initialize the keyed hash object.
        Using myhmac As New HMACSHA1(key)
            Using inStream As New FileStream(sourceFile, FileMode.Open)
                Using outStream As New FileStream(destFile, FileMode.Create)
                    ' Compute the hash of the input file.
                    Dim hashValue As Byte() = myhmac.ComputeHash(inStream)
                    ' Reset inStream to the beginning of the file.
                    inStream.Position = 0
                    ' Write the computed hash value to the output file.
                    outStream.Write(hashValue, 0, hashValue.Length)
                    ' Copy the contents of the sourceFile to the destFile.
                    Dim bytesRead As Integer
                    ' read 1K at a time
                    Dim buffer(1023) As Byte
                    Do
                        ' Read from the wrapping CryptoStream.
                        bytesRead = inStream.Read(buffer, 0, 1024)
                        outStream.Write(buffer, 0, bytesRead)
                    Loop While bytesRead > 0
                End Using
            End Using
        End Using
        Return

    End Sub 'SignFile
    ' end SignFile

    ' Compares the key in the source file with a new key created for the data portion of the file. If the keys 
    ' compare the data has not been tampered with.
    Public Shared Function VerifyFile(ByVal key() As Byte, ByVal sourceFile As String) As Boolean
        Dim err As Boolean = False
        ' Initialize the keyed hash object. 
        Using hmac As New HMACSHA1(key)
            ' Create an array to hold the keyed hash value read from the file.
            Dim storedHash(hmac.HashSize / 8) As Byte
            ' Create a FileStream for the source file.
            Using inStream As New FileStream(sourceFile, FileMode.Open)
                ' Read in the storedHash.
                inStream.Read(storedHash, 0, storedHash.Length - 1)
                ' Compute the hash of the remaining contents of the file.
                ' The stream is properly positioned at the beginning of the content, 
                ' immediately after the stored hash value.
                Dim computedHash As Byte() = hmac.ComputeHash(inStream)
                ' compare the computed hash with the stored value
                Dim i As Integer
                For i = 0 To storedHash.Length - 2
                    If computedHash(i) <> storedHash(i) Then
                        err = True
                    End If
                Next i
            End Using
        End Using
        If err Then
            Console.WriteLine("Hash values differ! Signed file has been tampered with!")
            Return False
        Else
            Console.WriteLine("Hash values agree -- no tampering occurred.")
            Return True
        End If

    End Function 'VerifyFile 
End Class 'HMACSHA1example 'end VerifyFile
'end class
'</SNIPPET1>