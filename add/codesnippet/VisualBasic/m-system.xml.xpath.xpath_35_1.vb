        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(navigator.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        For Each nav As XPathNavigator In navigator.Select("//bk:price", manager)
            If nav.Value = "11.99" Then
                nav.SetValue("12.99")
            End If
        Next

        Console.WriteLine(navigator.OuterXml)