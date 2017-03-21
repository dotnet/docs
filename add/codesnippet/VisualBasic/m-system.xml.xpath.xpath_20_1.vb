        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        ' Select all book nodes.
        Dim nodes As XPathNodeIterator = navigator.SelectDescendants("book", "", False)

        ' Select all book nodes that have the matching attribute value.
        Dim expr As XPathExpression = navigator.Compile("book[@genre='novel']")
        While nodes.MoveNext()
            Dim navigator2 As XPathNavigator = nodes.Current.Clone()
            If navigator2.Matches(expr) Then
                navigator2.MoveToFirstChild()
                Console.WriteLine("Book title:  {0}", navigator2.Value)
            End If
        End While