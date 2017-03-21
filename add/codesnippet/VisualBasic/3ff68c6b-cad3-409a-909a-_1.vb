
   public shared sub TransformFile (xsltNav as XPathNavigator) 
    
    ' Load the stylesheet.
    Dim xslt as XslTransform = new XslTransform()
    xslt.Load(xsltNav, nothing, nothing)

    ' Transform the file.
    xslt.Transform("books.xml", "books.html", nothing)
   end sub