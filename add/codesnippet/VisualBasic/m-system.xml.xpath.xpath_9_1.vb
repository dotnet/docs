        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(document.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        Dim first As XPathNavigator = navigator.SelectSingleNode("/bk:bookstore/bk:book[1]", manager)
        Dim last As XPathNavigator = navigator.SelectSingleNode("/bk:bookstore/bk:book[2]", manager)

        navigator.MoveTo(first)
        navigator.DeleteRange(last)
        Console.WriteLine(navigator.OuterXml)