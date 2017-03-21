        Dim settings As XmlReaderSettings = New XmlReaderSettings()
        settings.Schemas.Add("http://www.contoso.com/books", "contosoBooks.xsd")
        settings.ValidationType = ValidationType.Schema

        Dim reader As XmlReader = XmlReader.Create("contosoBooks.xml", settings)
        Dim document As XmlDocument = New XmlDocument()
        document.Load(reader)

        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim price As New Decimal(19.99)
        navigator.SetTypedValue(price)

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)