        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();
        
        XPathNodeIterator nodes = navigator.Select("/bookstore/book");
        nodes.MoveNext();
        XPathNavigator nodesNavigator = nodes.Current;
        
        XPathNodeIterator nodesText = nodesNavigator.SelectDescendants(XPathNodeType.Text, false);
        
        while (nodesText.MoveNext())
            Console.WriteLine(nodesText.Current.Value);