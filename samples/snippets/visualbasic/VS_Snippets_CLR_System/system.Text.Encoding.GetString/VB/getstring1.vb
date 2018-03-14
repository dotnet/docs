' Visual Basic .NET Document
Option Strict On
' <Snippet2>
Imports System.IO
Imports System.Text

Module Example
   Const MAX_BUFFER_SIZE As Integer = 2048
   
   Dim enc8 As Encoding = Encoding.UTF8
      
   Public Sub Main()
      Dim fStream As New FileStream(".\Utf8Example.txt", FileMode.Open)
      Dim contents As String = Nothing
      
      ' If file size is small, read in a single operation.
      If fStream.Length <= MAX_BUFFER_SIZE Then
         Dim bytes(CInt(fStream.Length) - 1) As Byte
         fStream.Read(bytes, 0, bytes.Length)
         contents = enc8.GetString(bytes)
      ' If file size exceeds buffer size, perform multiple reads.
      Else
         contents = ReadFromBuffer(fStream)
      End If
      fStream.Close()
      Console.WriteLine(contents)
   End Sub   

    Private Function ReadFromBuffer(fStream As FileStream) As String
        Dim bytes(MAX_BUFFER_SIZE) As Byte
        Dim output As String = String.Empty
        Dim decoder8 As Decoder = enc8.GetDecoder()
      
        Do While fStream.Position < fStream.Length
           Dim nBytes As Integer = fStream.Read(bytes, 0, bytes.Length)
           Dim nChars As Integer = decoder8.GetCharCount(bytes, 0, nBytes)
           Dim chars(nChars - 1) As Char
           nChars = decoder8.GetChars(bytes, 0, nBytes, chars, 0)
           output += New String(chars, 0, nChars)                                                     
        Loop
        Return output
    End Function
End Module
' The example displays the following output:
'     This is a UTF-8-encoded file that contains primarily Latin text, although it
'     does list the first twelve letters of the Russian (Cyrillic) alphabet:
'     
'     ? ? ? ? ? ? ? ? ? ? ? ?
'     
'     The goal is to save this file, then open and decode it as a binary stream.
' </Snippet2>
