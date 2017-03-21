
   public shared sub TransformFile (xsltReader as XmlReader, secureURL as String) 
    
    ' Load the stylesheet using a default XmlUrlResolver and Evidence 
    ' created using the trusted URL.
    Dim xslt as XslTransform = new XslTransform()
    xslt.Load(xsltReader, new XmlUrlResolver(), XmlSecureResolver.CreateEvidenceForUrl(secureURL))

    ' Transform the file.
    xslt.Transform("books.xml", "books.html", new XmlUrlResolver())
   end sub