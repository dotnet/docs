Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Security.Cryptography

Public Class Sample
    
' <Snippet1>
Private Shared Sub EncryptData(inName As String, outName As String, _
   tdesKey() As Byte, tdesIV() As Byte)
   
    'Create the file streams to handle the input and output files.
    Dim fin As New FileStream(inName, FileMode.Open, FileAccess.Read)
    Dim fout As New FileStream(outName, FileMode.OpenOrCreate, _
       FileAccess.Write)
    fout.SetLength(0)
        
    'Create variables to help with read and write.
    Dim bin(100) As Byte 'This is intermediate storage for the encryption.
    Dim rdlen As Long = 0 'This is the total number of bytes written.
    Dim totlen As Long = fin.Length 'This is the total length of the input file.
    Dim len As Integer 'This is the number of bytes to be written at a time.
    Dim tdes As New TripleDESCryptoServiceProvider()
    Dim encStream As New CryptoStream(fout, _
       tdes.CreateEncryptor(tdesKey, tdesIV), CryptoStreamMode.Write)
        
    Console.WriteLine("Encrypting...")
        
    'Read from the input file, then encrypt and write to the output file.
    While rdlen < totlen
        len = fin.Read(bin, 0, 100)
        encStream.Write(bin, 0, len)
        rdlen = rdlen + len
        Console.WriteLine("{0} bytes processed", rdlen)
    End While
        
    encStream.Close()
End Sub
' </Snippet1>
End Class 'Sample 
