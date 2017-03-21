     'Create the XslTransform object.
     Dim xslt as XslTransform = new XslTransform()

     'Load the stylesheet.
     xslt.Load("output.xsl")

     'Transform the file.
     xslt.Transform("books.xml", "books.html")