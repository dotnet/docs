        'Create a new XslTransform object.
        Dim xslt As New XslTransform()
        
        'Load the stylesheet.
        xslt.Load(CType("http://server/favorite.xsl", String))
        
        'Create a new XPathDocument and load the XML data to be transformed.
        Dim mydata As New XPathDocument("inputdata.xml")
        
        'Create an XmlTextWriter which outputs to the console.
        Dim writer As New XmlTextWriter(Console.Out)
        
        'Transform the data and send the output to the console.
        xslt.Transform(mydata, Nothing, writer, Nothing)