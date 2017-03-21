        ' Create an XmlReaderSettings object with the contosoBooks.xsd schema.
        Dim settings As XmlReaderSettings = New XmlReaderSettings()
        settings.Schemas.Add("http://www.contoso.com/books", "contosoBooks.xsd")
        settings.ValidationType = ValidationType.Schema

        ' Create an XmlReader object with the contosoBooks.xml file and its schema.
        Dim reader As XmlReader = XmlReader.Create("contosoBooks.xml", settings)

        Dim document As XPathDocument = New XPathDocument(reader)
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        ' Display the current type of the price element.
        Console.WriteLine(navigator.ValueType)

        ' Get the value of the price element as a string and display it.
        Dim price As String = navigator.ValueAs(GetType(String))
        Console.WriteLine(price)