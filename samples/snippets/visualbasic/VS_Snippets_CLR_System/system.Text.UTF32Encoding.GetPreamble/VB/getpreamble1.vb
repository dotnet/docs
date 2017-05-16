' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.IO
Imports System.Text

Module Example
   Public Sub Main()
      Dim s As String = "This is a string to write to a file using UTF-32 encoding."
      
      ' Write a file using the default constructor without a BOM.
      Dim enc As New UTF32Encoding(Not BitConverter.IsLittleEndian, False)
      Dim bytes() As Byte = enc.GetBytes(s)
      WriteToFile("NoPreamble.txt", enc, bytes)

      ' Use BOM.
      enc = New UTF32Encoding(Not BitConverter.IsLittleEndian, True)
      WriteToFile("Preamble.txt", enc, bytes)
   End Sub

   Private Sub WriteToFile(fn As String, enc As Encoding, bytes As Byte())
      Dim fs As New FileStream(fn, FileMode.Create)
      Dim preamble() As Byte = enc.GetPreamble()
      fs.Write(preamble, 0, preamble.Length)
      Console.WriteLine("Preamble has {0} bytes", preamble.Length)
      fs.Write(bytes, 0, bytes.Length)
      Console.WriteLine("Wrote {0} bytes to {1}.", fs.Length, fn)
      fs.Close()
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'       Preamble has 0 bytes
'       Wrote 232 bytes to NoPreamble.txt.
'
'       Preamble has 4 bytes
'       Wrote 236 bytes to Preamble.txt.
' </Snippet2>