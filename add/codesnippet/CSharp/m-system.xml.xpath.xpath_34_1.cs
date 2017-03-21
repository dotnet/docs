        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        Double total = (double)navigator.Evaluate("sum(descendant::book/price)");
        Console.WriteLine("Total price for all books: {0}", total.ToString());