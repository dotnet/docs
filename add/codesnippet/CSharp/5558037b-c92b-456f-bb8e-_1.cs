        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XPathNodeIterator nodes = navigator.Select("//book");
        XPathExpression query = nodes.Current.Compile("sum(descendant::price)");

        Double total = (double)navigator.Evaluate(query, nodes);
        Console.WriteLine("Total price for all books: {0}", total.ToString());