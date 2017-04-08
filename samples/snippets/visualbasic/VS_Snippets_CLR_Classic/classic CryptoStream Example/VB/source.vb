Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Security.Cryptography

Public Class Sample
    
' <Snippet1>
    Private Shared Sub EncryptData(inName As String, outName As String, _
    rijnKey() As Byte, rijnIV() As Byte)
    
        'Create the file streams to handle the input and output files.
        Dim fin As New FileStream(inName, FileMode.Open, FileAccess.Read)
        Dim fout As New FileStream(outName, FileMode.OpenOrCreate, _
           FileAccess.Write)
        fout.SetLength(0)
        
        'Create variables to help with read and write.
        Dim bin(100) As Byte 'This is intermediate storage for the encryption.
        Dim rdlen As Long = 0 'This is the total number of bytes written.
        Dim totlen As Long = fin.Length 'Total length of the input file.
        Dim len As Integer 'This is the number of bytes to be written at a time.
        'Creates the default implementation, which is RijndaelManaged.
        Dim rijn As SymmetricAlgorithm = SymmetricAlgorithm.Create()
        Dim encStream As New CryptoStream(fout, _
           rijn.CreateEncryptor(rijnKey, rijnIV), CryptoStreamMode.Write)
        
        Console.WriteLine("Encrypting...")
        
        'Read from the input file, then encrypt and write to the output file.
        While rdlen < totlen
            len = fin.Read(bin, 0, 100)
            encStream.Write(bin, 0, len)
            rdlen = Convert.ToInt32(rdlen + len)
            Console.WriteLine("{0} bytes processed", rdlen)
        End While
        
        encStream.Close()
	fout.Close()
	fin.Close()
    End Sub
' </Snippet1>
End Class
