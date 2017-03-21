Dim EncodedString As String = "This is a &ltTest String&gt."
Dim writer As New StringWriter
Server.HtmlDecode(EncodedString, writer)
Dim DecodedString As String = writer.ToString()
   