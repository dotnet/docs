        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        ' Select all the descendant nodes of the book node.
        Dim bookDescendants As XPathNodeIterator = navigator.SelectDescendants("", "http://www.contoso.com/books", False)

        ' Display the LocalName of each descendant node.
        Console.WriteLine("Descendant nodes of the book node:")
        While bookDescendants.MoveNext()
            Console.WriteLine(bookDescendants.Current.Name)
        End While

        ' Select all the child nodes of the book node.
        Dim bookChildren As XPathNodeIterator = navigator.SelectChildren("", "http://www.contoso.com/books")

        ' Display the LocalName of each child node.
        Console.WriteLine(vbCrLf & "Child nodes of the book node:")
        While bookChildren.MoveNext()
            Console.WriteLine(bookChildren.Current.Name)
        End While

        ' Select all the ancestor nodes of the title node.
        navigator.MoveToChild("title", "http://www.contoso.com/books")

        Dim bookAncestors As XPathNodeIterator = navigator.SelectAncestors("", "http://www.contoso.com/books", False)

        ' Display the LocalName of each ancestor node.
        Console.WriteLine(vbCrLf & "Ancestor nodes of the title node:")

        While bookAncestors.MoveNext()
            Console.WriteLine(bookAncestors.Current.Name)
        End While