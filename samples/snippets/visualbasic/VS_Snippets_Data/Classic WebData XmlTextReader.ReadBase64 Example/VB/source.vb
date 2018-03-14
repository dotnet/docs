' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic

Public Class Sample
   Private Const filename As String = "binary.xml"
   
   
   Public Shared Sub Main()
      Dim reader As XmlTextReader = Nothing
      Dim i As Integer

      Try
         reader = New XmlTextReader(filename)
         reader.WhitespaceHandling = WhitespaceHandling.None         

         ' Read the file. Stop at the Base64 element.         
         While reader.Read()
            If "Base64" = reader.Name Then
               Exit While
            End If
         End While 

         ' Read the Base64 data. Write the decoded 
         ' bytes to the console.
         Console.WriteLine("Reading base64... ")
         Dim base64len As Integer = 0
         Dim base64(1000) As Byte
         Do
            base64len = reader.ReadBase64(base64, 0, 50)
            For i = 0 To base64len - 1
               Console.Write(base64(i))
            Next i
         Loop While (reader.Name = "Base64")

         ' Read the BinHex data. Write the decoded 
         ' bytes to the console.
         Console.WriteLine(ControlChars.CrLf & "Reading binhex....")
         Dim binhexlen As Integer = 0
         Dim binhex(1000) As Byte
         binhexlen = reader.ReadBinHex(binhex, 0, 50)
         Do
            binhexlen = reader.ReadBinHex(binhex, 0, 50)
            For i = 0 To binhexlen - 1
               Console.Write(binhex(i))
            Next i
         Loop While (reader.Name = "BinHex") 
      
      Finally
         Console.WriteLine()
         Console.WriteLine("Processing of the file {0} complete.", filename)
         If Not (reader Is Nothing) Then
            reader.Close()
         End If
      End Try
   End Sub 'Main 
End Class 'Sample
' </Snippet1>
