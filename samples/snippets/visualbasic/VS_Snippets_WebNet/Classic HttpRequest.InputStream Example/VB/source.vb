Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim str As System.IO.Stream, strmContents As String
Dim counter, strLen, strRead As Integer
 
' Create a Stream object.
str = Request.InputStream
' Find number of bytes in stream.
strLen = CInt(str.Length)
' Create a byte array.
Dim strArr(strLen) As Byte 
' Read stream into byte array.
strRead = str.Read(strArr,0,strLen) 
 
' Convert byte array to a text string.
For counter = 0 To strLen-1
   strmContents = strmContents & strArr(counter).ToString()
Next counter
 
' </Snippet1>
 End Sub
End Class
