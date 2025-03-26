using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Collections;

class XPathNavigatorMethods
{
    static string contosobooks = @"C:\Documents and Settings\dylanm\My Documents\contosoBooks.xml";

    static void Main()
    {
    }

    #region AppendChild/Element
    static void XPathNavigatorMethods_AppendChild1()
    {
        // XPathNavigator.AppendChild()

        //<snippet1>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        XmlWriter pages = navigator.AppendChild();
        pages.WriteElementString("pages", "100");
        pages.Close();

        Console.WriteLine(navigator.OuterXml);
        //</snippet1>
    }

    static void XPathNavigatorMethods_AppendChild2()
    {
        // XPathNavigator.AppendChild(string)

        //<snippet2>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        navigator.AppendChild("<pages>100</pages>");

        Console.WriteLine(navigator.OuterXml);
        //</snippet2>
    }

    static void XPathNavigatorMethods_AppendChild3()
    {
        // XPathNavigator.AppendChile(XmlReader)

        //<snippet3>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        XmlReader pages = XmlReader.Create(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));

        navigator.AppendChild(pages);

        Console.WriteLine(navigator.OuterXml);
        //</snippet3>
    }

    static void XPathNavigatorMethods_AppendChild4()
    {
        // XPathNavigator.AppendChild(XPathNavigator)

        //<snippet4>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        XmlDocument childNodes = new XmlDocument();
        childNodes.Load(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));
        XPathNavigator childNodesNavigator = childNodes.CreateNavigator();

        if(childNodesNavigator.MoveToChild("pages", "http://www.contoso.com/books"))
        {
            navigator.AppendChild(childNodesNavigator);
        }

        Console.WriteLine(navigator.OuterXml);
        //</snippet4>
    }

    static void XPathNavigatorMethods_AppendChildElement()
    {
        // XPathNavigator.AppendChildElement(string, string, string, string)

        //<snippet5>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        navigator.AppendChildElement(navigator.Prefix, "pages", navigator.LookupNamespace(navigator.Prefix), "100");

        Console.WriteLine(navigator.OuterXml);
        //</snippet5>
    }
    #endregion

    #region Clone
    static void XPathNavigatorMethods_Clone()
    {
        // XPathNavigator.Clone()

        //<snippet6>
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
            Console.WriteLine($"Book title: {clone.Value}");
        }
        //</snippet6>
    }
    #endregion

    #region CreateAttribute(s)
    static void XPathNavigatorMethods_CreateAttribute()
    {
        // XPathNavigator.CreateAttribute(string, string, string, string)

        //<snippet7>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        navigator.CreateAttribute("", "discount", "", "1.00");

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet7>
    }

    static void XPathNavigatorMethods_CreateAttributes()
    {
        // XPathNavigator.CreateAttributes()

        //<snippet8>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlWriter attributes = navigator.CreateAttributes();

        attributes.WriteAttributeString("discount", "1.00");
        attributes.WriteAttributeString("currency", "USD");
        attributes.Close();

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet8>
    }
    #endregion

    #region DeleteSelf
    static void XPathNavigatorMethods_DeleteSelf()
    {
        // XPathNavigator.DeleteSelf()

        //<snippet9>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        navigator.DeleteSelf();

        Console.WriteLine($"Position after delete: {navigator.Name}");
        Console.WriteLine(navigator.OuterXml);
        //</snippet9>
    }

    #endregion

    #region DeleteRange
    static void XPathNavigatorMethods_DeleteRange()
    {
        // XPathNavigator.DeleteRange()

        //<snippet52>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XmlNamespaceManager manager = new XmlNamespaceManager(document.NameTable);
        manager.AddNamespace("bk", "http://www.contoso.com/books");

        XPathNavigator first = navigator.SelectSingleNode("/bk:bookstore/bk:book[1]", manager);
        XPathNavigator last = navigator.SelectSingleNode("/bk:bookstore/bk:book[2]", manager);

        navigator.MoveTo(first);
        navigator.DeleteRange(last);
        Console.WriteLine(navigator.OuterXml);
        //</snippet52>
    }
    #endregion

    #region Evaluate
    static void XPathNavigatorMethods_Evaluate1()
    {
        // XPathNavigator.Evaluate(string)

        //<snippet10>
        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        Double total = (double)navigator.Evaluate("sum(descendant::book/price)");
        Console.WriteLine($"Total price for all books: {total.ToString()}");
        //</snippet10>
    }

    static void XPathNavigatorMethods_Evaluate2()
    {
        // XPathNavigator.Evaluate(XPathExpression)

        //<snippet11>
        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XPathExpression query = navigator.Compile("sum(descendant::book/price)");

        Double total = (double)navigator.Evaluate(query);
        Console.WriteLine($"Total price for all books: {total.ToString()}");
        //</snippet11>
    }

    static void XPathNavigatorMethods_Evaluate3()
    {
        // XPathNavigator.Evaluate(string, IXmlNamespaceResolver)

        //<snippet12>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("bk", "http://www.contoso.com/books");

        Double total = (double)navigator.Evaluate("sum(descendant::bk:book/bk:price)", manager);
        Console.WriteLine($"Total price for all books: {total.ToString()}");
        //</snippet12>
    }

    static void XPathNavigatorMethods_Evaluate4()
    {
        // XPathNavigator.Evaluate(XPathExpression, XPathNodeIterator)

        //<snippet13>
        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XPathNodeIterator nodes = navigator.Select("//book");
        XPathExpression query = nodes.Current.Compile("sum(descendant::price)");

        Double total = (double)navigator.Evaluate(query, nodes);
        Console.WriteLine($"Total price for all books: {total.ToString()}");
        //</snippet13>
    }
    #endregion

    #region InsertAfter
    static void XPathNavigatorMethods_InsertAfter1()
    {
        // XPathNavigator.InsertAfter()

        //<snippet14>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlWriter pages = navigator.InsertAfter();
        pages.WriteElementString("pages", "100");
        pages.Close();

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet14>
    }

    static void XPathNavigatorMethods_InsertAfter2()
    {
        // XPathNavigator.InsertAfter(string)

        //<snippet15>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        navigator.InsertAfter("<pages>100</pages>");

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet15>
    }

    static void XPathNavigatorMethods_InsertAfter3()
    {
        // XPathNavigator.InsertAfter(XmlReader)

        //<snippet16>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlReader pages = XmlReader.Create(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));

        navigator.InsertAfter(pages);

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet16>
    }

    static void XPathNavigatorMethods_InsertAfter4()
    {
        // XPathNavigator.InsertAfter(XPathNavigator)

        //<snippet17>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlDocument childNodes = new XmlDocument();
        childNodes.Load(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));
        XPathNavigator childNodesNavigator = childNodes.CreateNavigator();

        navigator.InsertAfter(childNodesNavigator);

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet17>
    }
    #endregion

    #region InsertBefore
    static void XPathNavigatorMethods_InsertBefore1()
    {
        // XPathNavigator.InsertBefore()

        //<snippet18>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlWriter pages = navigator.InsertBefore();
        pages.WriteElementString("pages", "100");
        pages.Close();

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet18>
    }

    static void XPathNavigatorMethods_InsertBefore2()
    {
        // XPathNavigator.InsertBefore(string)

        //<snippet19>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        navigator.InsertBefore("<pages>100</pages>");

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet19>
    }

    static void XPathNavigatorMethods_InsertBefore3()
    {
        // XPathNavigator.InsertBefore(XmlReader)

        //<snippet20>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlReader pages = XmlReader.Create(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));

        navigator.InsertBefore(pages);

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet20>
    }

    static void XPathNavigatorMethods_InsertBefore4()
    {
        // XPathNavigator.InsertBefore(XPathNavigator)

        //<snippet21>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlDocument childNodes = new XmlDocument();
        childNodes.Load(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));
        XPathNavigator childNodesNavigator = childNodes.CreateNavigator();

        navigator.InsertBefore(childNodesNavigator);

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet21>
    }
    #endregion

    #region InsertElementAfter/Before
    static void XPathNavigatorMethods_InsertElementAfter()
    {
        // XPathNavigator.InsertElementAfter(string, string, string, string)

        //<snippet22>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        navigator.InsertElementAfter(navigator.Prefix, "pages", navigator.LookupNamespace(navigator.Prefix), "100");

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet22>
    }

    static void XPathNavigatorMethods_InsertElementBefore()
    {
        // XPathNavigator.InsertElementBefore(string, string, string, string)

        //<snippet23>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        navigator.InsertElementBefore(navigator.Prefix, "pages", navigator.LookupNamespace(navigator.Prefix), "100");

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet23>
    }
    #endregion

    #region Matches
    static void XPathNavigatorMethods_Matches()
    {
        //<snippet24>
        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        // Select all book nodes.
        XPathNodeIterator nodes = navigator.SelectDescendants("book", "", false);

        // Select all book nodes that have the matching attribute value.
        XPathExpression expr = navigator.Compile("book[@genre='novel']");
        while (nodes.MoveNext())
        {
            XPathNavigator navigator2 = nodes.Current.Clone();
            if (navigator2.Matches(expr))
            {
                navigator2.MoveToFirstChild();
                Console.WriteLine($"Book title:  {navigator2.Value}");
            }
        }
        //</snippet24>
    }
    #endregion

    #region MoveToFollowing
    static void XPathNavigatorMethods_MoveToFollowing1()
    {
        //<snippet25>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToFollowing(XPathNodeType.Element);

        Console.WriteLine($"Position: {navigator.Name}");
        Console.WriteLine(navigator.OuterXml);
        //</snippet25>
    }

    static void XPathNavigatorMethods_MoveToFollowing2()
    {
        //<snippet26>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToFollowing("price", "http://www.contoso.com/books");

        Console.WriteLine($"Position: {navigator.Name}");
        Console.WriteLine(navigator.OuterXml);
        //</snippet26>
    }

    static void XPathNavigatorMethods_MoveToFollowing3()
    {
        //<snippet27>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToFollowing("price", "http://www.contoso.com/books");
        XPathNavigator boundary = navigator.Clone();

        navigator.MoveToRoot();

        while (navigator.MoveToFollowing(XPathNodeType.Text, boundary))
        {
            Console.WriteLine(navigator.OuterXml);
        }
        //</snippet27>
    }

    static void XPathNavigatorMethods_MoveToFollowing4()
    {
        //<snippet28>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToFollowing("book", "http://www.contoso.com/books");
        XPathNavigator boundary = navigator.Clone();
        boundary.MoveToFollowing("first-name", "http://www.contoso.com/books");

        navigator.MoveToFollowing("price", "http://www.contoso.com/books", boundary);

        Console.WriteLine($"Position (after boundary): {navigator.Name}");
        Console.WriteLine(navigator.OuterXml);

        navigator.MoveToFollowing("title", "http://www.contoso.com/books", boundary);

        Console.WriteLine($"Position (before boundary): {navigator.Name}");
        Console.WriteLine(navigator.OuterXml);
        //</snippet28>
    }
    #endregion

    #region MoveToNext
    //<snippet29>
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
                if (string.IsNullOrEmpty(navigator.Prefix))
                    Console.WriteLine($"<{navigator.LocalName}>");
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
                Console.WriteLine($"</{navigator.Name}>");
        }
        else
        {
            if (navigator.NodeType == XPathNodeType.Element)
            {
                Console.WriteLine($"</{navigator.Name}>");
            }
        }
    }
    //</snippet29>
    #endregion

    #region PrependChild/Element
    static void XPathNavigatorMethods_PrependChild1()
    {
        //<snippet30>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        XmlWriter pages = navigator.PrependChild();
        pages.WriteElementString("pages", "100");
        pages.Close();

        Console.WriteLine(navigator.OuterXml);
        //</snippet30>
    }

    static void XPathNavigatorMethods_PrependChild2()
    {
        //<snippet31>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        navigator.PrependChild("<pages>100</pages>");

        Console.WriteLine(navigator.OuterXml);
        //</snippet31>
    }

    static void XPathNavigatorMethods_PrependChild3()
    {
        //<snippet32>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        XmlReader pages = XmlReader.Create(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));

        navigator.PrependChild(pages);

        Console.WriteLine(navigator.OuterXml);
        //</snippet32>
    }

    static void XPathNavigatorMethods_PrependChild4()
    {
        //<snippet33>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        XmlDocument childNodes = new XmlDocument();
        childNodes.Load(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));
        XPathNavigator childNodesNavigator = childNodes.CreateNavigator();

        navigator.PrependChild(childNodesNavigator);

        Console.WriteLine(navigator.OuterXml);
        //</snippet33>
    }

    static void XPathNavigatorMethods_PrependChildElement()
    {
        //<snippet34>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        navigator.PrependChildElement(navigator.Prefix, "pages", navigator.LookupNamespace(navigator.Prefix), "100");

        Console.WriteLine(navigator.OuterXml);
        //</snippet34>
    }

    #endregion

    #region ReadSubTree
    static void XPathNavigatorMethods_ReadSubtree()
    {
        //<snippet35>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        XmlReader reader = navigator.ReadSubtree();

        while (reader.Read())
        {
            Console.WriteLine(reader.ReadInnerXml());
        }

        reader.Close();
        //</snippet35>
    }
    #endregion

    #region ReplaceRange

    static void XPathNavigatorMethods_ReplaceRange()
    {
        // XPathNavigator.ReplaceRange()

        //<snippet53>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XmlNamespaceManager manager = new XmlNamespaceManager(document.NameTable);
        manager.AddNamespace("bk", "http://www.contoso.com/books");

        XPathNavigator first = navigator.SelectSingleNode("/bk:bookstore/bk:book[1]", manager);
        XPathNavigator last = navigator.SelectSingleNode("/bk:bookstore/bk:book[2]", manager);

        navigator.MoveTo(first);
        XmlWriter newRange = navigator.ReplaceRange(last);
        newRange.WriteStartElement("book");
        newRange.WriteAttributeString("genre", "");
        newRange.WriteAttributeString("publicationdate", "2005-04-07");
        newRange.WriteAttributeString("ISBN", "0");
        newRange.WriteStartElement("title");
        newRange.WriteString("New Book");
        newRange.WriteEndElement();
        newRange.WriteStartElement("author");
        newRange.WriteStartElement("first-name");
        newRange.WriteString("First Name");
        newRange.WriteEndElement();
        newRange.WriteStartElement("last-name");
        newRange.WriteString("Last Name");
        newRange.WriteEndElement();
        newRange.WriteEndElement();
        newRange.WriteElementString("price", "$0.00");
        newRange.WriteEndElement();
        newRange.Close();
        Console.WriteLine(navigator.OuterXml);
        //</snippet53>
    }

    #endregion

    #region ReplaceSelf
    static void XPathNavigatorMethods_ReplaceSelf1()
    {
        //<snippet36>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        navigator.ReplaceSelf("<pages>100</pages>");

        Console.WriteLine($"Position after delete: {navigator.Name}");
        Console.WriteLine(navigator.OuterXml);
        //</snippet36>
    }

    static void XPathNavigatorMethods_ReplaceSelf2()
    {
        //<snippet37>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlReader pages = XmlReader.Create(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));

        navigator.ReplaceSelf(pages);

        Console.WriteLine($"Position after delete: {navigator.Name}");
        Console.WriteLine(navigator.OuterXml);
        //</snippet37>
    }

    static void XPathNavigatorMethods_ReplaceSelf3()
    {
        //<snippet38>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        XmlDocument childNodes = new XmlDocument();
        childNodes.Load(new StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));
        XPathNavigator childNodesNavigator = childNodes.CreateNavigator();

        navigator.ReplaceSelf(childNodesNavigator);

        Console.WriteLine($"Position after delete: {navigator.Name}");
        Console.WriteLine(navigator.OuterXml);
        //</snippet38>
    }
    #endregion

    #region Select()
    static void XPathNavigatorMethods_Select1()
    {
        //<snippet39>
        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XPathNodeIterator nodes = navigator.Select("/bookstore/book");
        nodes.MoveNext();
        XPathNavigator nodesNavigator = nodes.Current;

        XPathNodeIterator nodesText = nodesNavigator.SelectDescendants(XPathNodeType.Text, false);

        while (nodesText.MoveNext())
            Console.WriteLine(nodesText.Current.Value);
        //</snippet39>
    }

    static void XPathNavigatorMethods_Select2()
    {
        //<snippet40>
        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XPathExpression query = navigator.Compile("/bookstore/book");
        XPathNodeIterator nodes = navigator.Select(query);
        XPathNavigator nodesNavigator = nodes.Current;

        XPathNodeIterator nodesText = nodesNavigator.SelectDescendants(XPathNodeType.Text, false);

        while (nodesText.MoveNext())
        {
            Console.WriteLine(nodesText.Current.Value);
        }
        //</snippet40>
    }

    static void XPathNavigatorMethods_Select3()
    {
        //<snippet41>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();
        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("bk", "http://www.contoso.com/books");

        XPathNodeIterator nodes = navigator.Select("/bk:bookstore/bk:book/bk:price", manager);
        // Move to the first node bk:price node
        if(nodes.MoveNext())
        {
            // now nodes.Current points to the first selected node
            XPathNavigator nodesNavigator = nodes.Current;

            //select all the descendants of the current price node
            XPathNodeIterator nodesText =
               nodesNavigator.SelectDescendants(XPathNodeType.Text, false);

            while(nodesText.MoveNext())
            {
               Console.WriteLine(nodesText.Current.Value);
            }
        }
        //</snippet41>
    }
    #endregion

    #region SelectAncestors/Children/Descendants
    static void XPathNavigatorMethods_SelectAncestorsChildrenDescendants()
    {
        //<snippet42>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        // Select all the descendant nodes of the book node.
        XPathNodeIterator bookDescendants = navigator.SelectDescendants("", "http://www.contoso.com/books", false);

        // Display the LocalName of each descendant node.
        Console.WriteLine("Descendant nodes of the book node:");
        while (bookDescendants.MoveNext())
        {
            Console.WriteLine(bookDescendants.Current.Name);
        }

        // Select all the child nodes of the book node.
        XPathNodeIterator bookChildren = navigator.SelectChildren("", "http://www.contoso.com/books");

        // Display the LocalName of each child node.
        Console.WriteLine("\nChild nodes of the book node:");
        while (bookChildren.MoveNext())
        {
            Console.WriteLine(bookChildren.Current.Name);
        }

        // Select all the ancestor nodes of the title node.
        navigator.MoveToChild("title", "http://www.contoso.com/books");

        XPathNodeIterator bookAncestors = navigator.SelectAncestors("", "http://www.contoso.com/books", false);

        // Display the LocalName of each ancestor node.
        Console.WriteLine("\nAncestor nodes of the title node:");

        while (bookAncestors.MoveNext())
        {
            Console.WriteLine(bookAncestors.Current.Name);
        }
        //</snippet42>
    }
    #endregion

    #region SelectSingleNode
    static void XPathNavigatorMethods_SelectSingleNode1()
    {
        //<snippet43>
        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XPathNavigator node = navigator.SelectSingleNode("//title");
        Console.WriteLine(node.InnerXml);
        //</snippet43>
    }

    static void XPathNavigatorMethods_SelectSingleNode2()
    {
        //<snippet44>
        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XPathExpression query = navigator.Compile("//title");

        XPathNavigator node = navigator.SelectSingleNode(query);
        Console.WriteLine(node.InnerXml);
        //</snippet44>
    }

    static void XPathNavigatorMethods_SelectSingleNode3()
    {
        //<snippet45>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("bk", "http://www.contoso.com/books");

        XPathNavigator node = navigator.SelectSingleNode("//bk:title", manager);
        Console.WriteLine(node.InnerXml);
        //</snippet45>
    }
    #endregion

    #region SetTyped/Value
    static void XPathNavigatorMethods_SetTypedValue()
    {
        //<snippet46>
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add("http://www.contoso.com/books", "contosoBooks.xsd");
        settings.ValidationType = ValidationType.Schema;

        XmlReader reader = XmlReader.Create("contosoBooks.xml", settings);
        XmlDocument document = new XmlDocument();
        document.Load(reader);

        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        Decimal price = 19.99M;
        navigator.SetTypedValue(price);

        navigator.MoveToParent();
        Console.WriteLine(navigator.OuterXml);
        //</snippet46>
    }

    static void XPathNavigatorMethods_SetValue()
    {
        //<snippet47>
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("bk", "http://www.contoso.com/books");

        foreach (XPathNavigator nav in navigator.Select("//bk:price", manager))
        {
            if (nav.Value == "11.99")
            {
                nav.SetValue("12.99");
            }
        }

        Console.WriteLine(navigator.OuterXml);
        //</snippet47>
    }
    #endregion

    #region WriteSubtree
    static void XPathNavigatorMethods_WriteSubtree()
    {
        //<snippet48>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        XmlWriter writer = XmlWriter.Create("contosoBook.xml");
        navigator.WriteSubtree(writer);

        writer.Close();
        //</snippet48>
    }
    #endregion

    #region MoveToNextAttribute
    static void XPathNavigatorMethods_MoveToNextAttribute()
    {
        //<snippet49>
        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();

        // Select all book nodes and display all attributes on each book.
        XPathNodeIterator nodes = navigator.SelectDescendants("book", "", false);
        while (nodes.MoveNext())
        {
            XPathNavigator navigator2 = nodes.Current.Clone();
            navigator2.MoveToFirstAttribute();
            Console.WriteLine($"{navigator2.Name} = {navigator2.Value}");

            while (navigator2.MoveToNextAttribute())
            {
                Console.WriteLine($"{navigator2.Name} = {navigator2.Value}");
            }

            Console.WriteLine();
        }
        //</snippet49>
    }
    #endregion

    #region BasicMoveTos
    static void XPathNavigatorMethods_BasicMoveTos()
    {
        //<snippet54>
        // Load the XML document.
        XmlDocument document = new XmlDocument();
        document.Load("contosoBooks.xml");

        // Create the XPathNavigator.
        XPathNavigator navigator = document.CreateNavigator();

        // Create an XmlNamespaceManager used to handle namespaces
        // found in the XML document.
        XmlNamespaceManager manager = new XmlNamespaceManager(document.NameTable);
        manager.AddNamespace("bk", "http://www.contoso.com/books");

        // Move to the last book node using the SelectSingleNode method.
        navigator = navigator.SelectSingleNode("//bk:book[last()]", manager);
        Console.WriteLine($"Last book node: \n===============\n{navigator.OuterXml}");

        // Move to the previous book node and write it to the console
        // if the move was successful.
        if (navigator.MoveToPrevious())
        {
            Console.WriteLine($"\nSecond book node: \n=================\n{navigator.OuterXml}");
        }

        // Move to the first book node and write it to the console
        // if the move was successful.
        if (navigator.MoveToFirst())
        {
            Console.WriteLine($"\nFirst book node: \n================\n{navigator.OuterXml}");
        }

        // Move to the parent bookstore node and write it to the console
        // if the move was successful.
        if (navigator.MoveToParent())
        {
            Console.WriteLine($"\nParent bookstore node: \n======================\n{navigator.OuterXml}");
        }

        // Move to the first child node of the bookstore node and write
        // it to the console if the move was successful.
        if (navigator.MoveToFirstChild())
        {
            Console.WriteLine($"\nFirst book node: \n================\n{navigator.OuterXml}");
        }

        // Move to the root node and write it to the console.
        navigator.MoveToRoot();
        Console.WriteLine($"\nRoot node: \n==========\n{navigator.OuterXml}");
        //</snippet54>
    }
    #endregion

    #region TwoWaysToIterateOverXPathNavigator
    static void XPathNavigatorMethods_TwoWaysToIterateOverXPathNavigator()
    {
        XPathDocument doc = new XPathDocument(new StringReader("<A><B/></A>"));
        XPathNavigator nav = doc.CreateNavigator();
        XPathNodeIterator nodeIterator = nav.SelectDescendants("", "", false);

        //<snippet55>
        while (nodeIterator.MoveNext())
        {
            XPathNavigator n = nodeIterator.Current;
            Console.WriteLine(n.LocalName);
        }
        //</snippet55>

        //<snippet56>
        foreach (XPathNavigator n in nodeIterator)
            Console.WriteLine(n.LocalName);
        //</snippet56>
    }
    #endregion
}
