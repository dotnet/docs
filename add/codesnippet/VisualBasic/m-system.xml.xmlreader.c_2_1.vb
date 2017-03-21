        Dim xmlData As String = "<item productID='124390'>" & _ 
                                             "<price>5.95</price>" & _ 
                                             "</item>"
        
        ' Create the XmlReader object.
        Dim reader As XmlReader = XmlReader.Create(New StringReader(xmlData))