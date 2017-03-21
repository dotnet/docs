        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        ' Select all book nodes and display all attributes on each book.
        Dim nodes As XPathNodeIterator = navigator.SelectDescendants("book", "", False)
        While nodes.MoveNext()
            Dim navigator2 As XPathNavigator = nodes.Current.Clone()
            navigator2.MoveToFirstAttribute()
            Console.WriteLine("{0} = {1}", navigator2.Name, navigator2.Value)

            While navigator2.MoveToNextAttribute()
                Console.WriteLine("{0} = {1}", navigator2.Name, navigator2.Value)
            End While

            Console.WriteLine()
        End While