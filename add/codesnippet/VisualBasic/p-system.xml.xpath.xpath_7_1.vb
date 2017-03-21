        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        ' Select all books authored by Melville.
        Dim nodes As XPathNodeIterator = navigator.Select("descendant::book[author/last-name='Melville']")

        While nodes.MoveNext()
            ' Clone the navigator returned by the Current property. 
            ' Use the cloned navigator to get the title element.
            Dim clone As XPathNavigator = nodes.Current.Clone()
            clone.MoveToFirstChild()
            Console.WriteLine("Book title: {0}", clone.Value)
        End While