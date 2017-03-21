
   public static void TransformFile (XPathNavigator xsltNav) {
    
    // Load the stylesheet. 
    XslTransform xslt = new XslTransform();
    xslt.Load(xsltNav, null, null);

    // Transform the file.
    xslt.Transform("books.xml", "books.html", null);
   } 