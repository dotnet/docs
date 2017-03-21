' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("HTML_out.xsl")
        
' Transform the file and output an HTML string.
Dim HTMLoutput As String
Dim writer As New StringWriter()
xslt.Transform("books.xml", Nothing, writer)
HTMLoutput = writer.ToString()
writer.Close()