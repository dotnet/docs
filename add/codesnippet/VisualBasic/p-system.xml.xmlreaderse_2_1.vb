        Dim xmlFrag As String = "<item rk:ID='abc-23'>hammer</item> " & _
                                             "<item rk:ID='r2-435'>paint</item>" & _
                                             "<item rk:ID='abc-39'>saw</item>"
        
        ' Create the XmlNamespaceManager.
        Dim nt As New NameTable()
        Dim nsmgr As New XmlNamespaceManager(nt)
        nsmgr.AddNamespace("rk", "urn:store-items")
        
        ' Create the XmlParserContext.
        Dim context As New XmlParserContext(Nothing, nsmgr, Nothing, XmlSpace.None)
        
        ' Create the reader. 
        Dim settings As New XmlReaderSettings()
        settings.ConformanceLevel = ConformanceLevel.Fragment
        Dim reader As XmlReader = XmlReader.Create(New StringReader(xmlFrag), settings, context)