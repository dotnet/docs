Dim TestString As String = "This is a <Test String>."
Dim writer As New StringWriter
Server.HtmlEncode(TestString, writer)
Dim EncodedString As String = writer.ToString()
   