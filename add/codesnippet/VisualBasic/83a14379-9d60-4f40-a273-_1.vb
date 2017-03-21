' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("output.xsl")
        
' Create the FileStream.
Using fs As New FileStream("c:\data\output.xml", FileMode.Create)
   ' Execute the transformation.
    xslt.Transform(New XPathDocument("books.xml"), Nothing, fs)
End Using