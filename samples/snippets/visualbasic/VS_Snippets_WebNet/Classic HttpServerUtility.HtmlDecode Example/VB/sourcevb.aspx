<!--<Snippet1>-->
<%@ PAGE LANGUAGE = "VB" %>
<%@ Import Namespace="System.IO" %>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<script runat = "server">
 
   Function LoadDecodedFile(file As String) As String
      Dim DecodedString As String
      Dim fs As New FileStream(file, FileMode.Open)
      Dim r As New StreamReader(fs)
      ' Position the file pointer at the beginning of the file.
      r.BaseStream.Seek(0, SeekOrigin.Begin)
      ' Read the entire file into a string and decode each chunk.
      Do While r.Peek() > -1
         DecodedString = DecodedString & _
            Server.HtmlDecode(r.ReadLine())
      Loop
      r.Close()
      LoadDecodedFile = DecodedString
   End Function
 
</script>
<head runat="server">
    <title> HttpServerUtility.HtmlDecode Example</title>
</head>
<body></body>
</html>

<!--</Snippet1>-->
