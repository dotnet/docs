        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XPathExpression query = navigator.Compile("sum(descendant::book/price)");

        Double total = (double)navigator.Evaluate(query);
        Console.WriteLine("Total price for all books: {0}", total.ToString());