        While nodeIterator.MoveNext()
            Dim n As XPathNavigator = nodeIterator.Current
            Console.WriteLine(n.LocalName)
        End While