Dim writer As New StringWriter
Server.UrlDecode(EncodedString, writer)
Dim DecodedString As String = writer.ToString()
   