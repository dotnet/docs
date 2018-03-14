<!--<Snippet1>-->

<%@ Page language="VB" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.IO" %>

<script runat="server">
' This example is meant to be added to a Global.asax file.

Sub Application_BeginRequest()
   Request.Filter = New QQQ1(Request.Filter)
   Request.Filter = New QQQ2(Request.Filter)
End Sub

' The class QQQ1 changes all lower case alpha chars to upper case.
Public Class QQQ1
   Inherits Stream

   Private _sink As Stream

   Public Sub New(sink As Stream)
      _sink = sink
   End Sub

   ' All MustOverride interface members must be included.
   Public Overrides ReadOnly Property CanRead() As Boolean
      Get 
         Return True
      End Get
   End Property

   Public Overrides ReadOnly Property CanSeek() As Boolean
      Get
         Return False
      End Get
   End Property

   Public Overrides ReadOnly Property CanWrite() As Boolean
      Get
         Return False
      End Get
   End Property

   Public Overrides ReadOnly Property Length() As Long
      Get
         Return _sink.Length
      End Get
   End Property

   Public Overrides Property Position() As Long
      Get
         Return _sink.Position
      End Get
      Set 
         Throw New NotSupportedException()
      End Set
   End Property

   Public Overrides Function Read(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer) As Integer
      Dim c As Integer = _sink.Read(buffer, offset, count)
      Dim i As Integer
      For i = 0 To count - 1
         If buffer(offset+i) >= Asc("a") And buffer(offset+i) <= Asc("z") Then
            buffer(offset+i) = buffer(offset+i) - (Asc("a")-Asc("A"))
         End If
      Next i
      Return c
   End Function

   Public Overrides Function Seek(ByVal offset As Long, ByVal direction As System.IO.SeekOrigin) As Long
        Throw New NotSupportedException()
   End Function

   Public Overrides Sub SetLength(ByVal length As Long)
      Throw New NotSupportedException()
   End Sub

   Public Overrides Sub Close()
      _sink.Close()
   End Sub

   Public Overrides Sub Flush()
      _sink.Flush()
   End Sub

   Public Overrides Sub Write(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer)
      Throw New NotSupportedException()
   End Sub
End Class


' The class QQQ2 changes all E characters to asterisks.
class QQQ2 
   Inherits Stream
    
   Private _sink As Stream

   Public Sub New(sink As Stream)
      _sink = sink
   End Sub

   ' All MustOverride interface members must be included.
   Public Overrides ReadOnly Property CanRead() As Boolean
      Get  
         Return true
      End Get
   End Property

   Public Overrides ReadOnly Property CanSeek() As Boolean
      Get
         Return False
      End Get
   End Property

   Public Overrides ReadOnly Property CanWrite() As Boolean
      Get 
         Return False
      End Get
   End Property

   Public Overrides ReadOnly Property Length() As Long
      Get
         Return _sink.Length
      End Get
   End Property

   Public Overrides Property Position() As Long
      Get
         Return _sink.Position
      End Get  
      Set 
         Throw New NotSupportedException()
      End Set
   End Property

   Public Overrides Function Read(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer) As Integer
      Dim c As Integer = _sink.Read(buffer, offset, count)
      Dim i As Integer
      For i = 0 To count-1
         If buffer(i) = Asc("E") Then
            buffer(i) = Asc("*")
         End If
      Next i
      Return c
   End Function

   Public Overrides Function Seek(ByVal offset As Long, ByVal direction As System.IO.SeekOrigin) As Long
      Throw New NotSupportedException()
   End Function

   Public Overrides Sub SetLength(length As Long)
      Throw New NotSupportedException()
   End Sub

   Public Overrides Sub Close()
      _sink.Close()
   End Sub

   Public Overrides Sub Flush()
      _sink.Flush()
   End Sub

   Public Overrides Sub Write(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer)
      Throw New NotSupportedException()
   End Sub
End Class


'____________________________________________________________________

' This ASP.NET page uses the request filter to modify all text sent by the 
' browser in Request.InputStream. To test the filter, use this page to take
' the POSTed output from a data entry page using a tag such as: 
' <form method="POST" action="ThisTestPage.aspx">

'<%@ PAGE LANGUAGE = VB %>
'<%@ IMPORT namespace="System.IO" %>

'<html>
'<Script runat=server>

'   Sub Page_Load()
'      Dim str As Stream, strmContents As String
'      Dim counter, strLen As Integer
 
      ' Create a Stream object.
'      str = Request.InputStream

      ' Find number of bytes in stream.
'      strLen = CInt(str.Length)

      ' Create a byte array.
'      Dim strArr(strLen) As Byte 

      ' Read stream into byte array.
'      str.Read(strArr,0,strLen) 
 
      ' Convert byte array to a text string.
'      For counter = 0 To strLen-1
'         strmContents = strmContents & Chr(strArr(counter))
'      Next counter

'      Response.Write("Contents of Filtered InputStream: " & strmContents)
'   End Sub

' </html>

</script>
<!--</Snippet1>-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
