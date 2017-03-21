        while (nodeIterator.MoveNext())
        {
            XPathNavigator n = nodeIterator.Current;
            Console.WriteLine(n.LocalName);
        }