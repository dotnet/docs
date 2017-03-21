    static void XPathNavigatorMethods_MoveToNext()
    {

        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();
        XPathNodeIterator nodeset = navigator.Select("descendant::book[author/last-name='Melville']");

        while (nodeset.MoveNext())
        {
            // Clone iterator here when working with it.
            RecursiveWalk(nodeset.Current.Clone());
        }
    }

    public static void RecursiveWalk(XPathNavigator navigator)
    {
        switch (navigator.NodeType)
        {
            case XPathNodeType.Element:
                if (navigator.Prefix == String.Empty)
                    Console.WriteLine("<{0}>", navigator.LocalName);
                else
                    Console.Write("<{0}:{1}>", navigator.Prefix, navigator.LocalName);
                Console.WriteLine("\t" + navigator.NamespaceURI);
                break;
            case XPathNodeType.Text:
                Console.WriteLine("\t" + navigator.Value);
                break;
        }

        if (navigator.MoveToFirstChild())
        {
            do
            {
                RecursiveWalk(navigator);
            } while (navigator.MoveToNext());

            navigator.MoveToParent();
            if (navigator.NodeType == XPathNodeType.Element)
                Console.WriteLine("</{0}>", navigator.Name);
        }
        else
        {
            if (navigator.NodeType == XPathNodeType.Element)
            {
                Console.WriteLine("</{0}>", navigator.Name);
            }
        }
    }