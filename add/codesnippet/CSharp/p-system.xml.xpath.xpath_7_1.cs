        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        // Select all books authored by Melville.
        XPathNodeIterator nodes = navigator.Select("descendant::book[author/last-name='Melville']");

        while (nodes.MoveNext())
        {
            // Clone the navigator returned by the Current property. 
            // Use the cloned navigator to get the title element.
            XPathNavigator clone = nodes.Current.Clone();
            clone.MoveToFirstChild();
            Console.WriteLine("Book title: {0}", clone.Value);
        }