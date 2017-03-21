' Load the style sheet.
Dim xslt As New XslCompiledTransform()
xslt.Load("output.xsl")
        
' Execute the transform and output the results to a file.
xslt.Transform("books.xml", "books.html")