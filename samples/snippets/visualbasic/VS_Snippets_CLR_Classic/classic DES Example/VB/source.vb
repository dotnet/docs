Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Security.Cryptography

Public Class Form1
    Inherits Form
    
' <Snippet1>
    Private Shared Sub EncryptData(inName As String, outName As String, _
    desKey() As Byte, desIV() As Byte)
    
        'Create the file streams to handle the input and output files.
        Dim fin As New FileStream(inName, FileMode.Open, FileAccess.Read)
        Dim fout As New FileStream(outName, FileMode.OpenOrCreate, _
           FileAccess.Write)
        fout.SetLength(0)
        
        'Create variables to help with read and write.
        Dim bin(4096) As Byte 'This is intermediate storage for the encryption.
        Dim rdlen As Long = 0 'This is the total number of bytes written.
        Dim totlen As Long = fin.Length 'Total length of the input file.
        Dim len As Integer 'This is the number of bytes to be written at a time.
        Dim des As New DESCryptoServiceProvider()
        Dim encStream As New CryptoStream(fout, _
           des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write)
        
        Console.WriteLine("Encrypting...")
        
        'Read from the input file, then encrypt and write to the output file.
        While rdlen < totlen
            len = fin.Read(bin, 0, 4096)
            encStream.Write(bin, 0, len)
            rdlen = Convert.ToInt32(rdlen + len / des.BlockSize * des.BlockSize)
            Console.WriteLine("Processed {0} bytes, {1} bytes total", len, _
               rdlen)
        End While
        
        encStream.Close()
    End Sub
' </Snippet1>
End Class
