        Dim readOnlyDocument As XPathDocument = New XPathDocument("books.xml")
        Dim readOnlyNavigator As XPathNavigator = readOnlyDocument.CreateNavigator()

        Dim editableDocument As XmlDocument = New XmlDocument()
        editableDocument.Load("books.xml")
        Dim editableNavigator As XPathNavigator = editableDocument.CreateNavigator()

        Console.WriteLine("XPathNavigator.CanEdit from XPathDocument: {0}", readOnlyNavigator.CanEdit)
        Console.WriteLine("XPathNavigator.CanEdit from XmlDocument: {0}", editableNavigator.CanEdit)
