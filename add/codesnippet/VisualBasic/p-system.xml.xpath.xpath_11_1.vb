        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()
        Dim table As Hashtable = New Hashtable(XPathNavigator.NavigatorComparer)

        ' Add nodes to the Hashtable.
        For Each navigator2 As XPathNavigator In navigator.Select("//book")
            Dim value As Object = navigator2.Evaluate("string(./title)")
            table.Add(navigator2.Clone(), value)
            Console.WriteLine("Added book with title {0}", value)
        Next

        Console.WriteLine(table.Count)
        Console.WriteLine("Does the Hashtable have the book 'The Confidence Man'?")
        Console.WriteLine(table.Contains(navigator.SelectSingleNode("//book[title='The Confidence Man']")))