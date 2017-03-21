
   public static void TransformFile (XmlReader xsltReader, String secureURL) {
    
    // Load the stylesheet using a default XmlUrlResolver and Evidence 
    // created using the trusted URL.
    XslTransform xslt = new XslTransform();
    xslt.Load(xsltReader, new XmlUrlResolver(), XmlSecureResolver.CreateEvidenceForUrl(secureURL));

    // Transform the file.
    xslt.Transform("books.xml", "books.html", new XmlUrlResolver());
   } 