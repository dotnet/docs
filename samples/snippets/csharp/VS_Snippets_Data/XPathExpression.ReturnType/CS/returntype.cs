//<snippet1>
using System;
using System.Xml;
using System.Xml.XPath;

public class XPathExpressionExample
{
    public static void Main()
    {
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XPathExpression expression1 = XPathExpression.Compile(".//bk:price/text()*10"); // Returns a number.
        XPathExpression expression2 = XPathExpression.Compile("bk:bookstore/bk:book/bk:price"); // Returns a nodeset.

        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("bk", "http://www.contoso.com/books");

        expression1.SetContext(manager);
        expression2.SetContext(manager);

        Evaluate(expression1, navigator);
        Evaluate(expression2, navigator);
    }

    public static void Evaluate(XPathExpression expression, XPathNavigator navigator)
    {
        switch (expression.ReturnType)
        {
            case XPathResultType.Number:
                Console.WriteLine(navigator.Evaluate(expression));
                break;

            case XPathResultType.NodeSet:
                XPathNodeIterator nodes = navigator.Select(expression);
                while (nodes.MoveNext())
                {
                    Console.WriteLine(nodes.Current.ToString());
                }
                break;

            case XPathResultType.Boolean:
                if ((bool)navigator.Evaluate(expression))
                    Console.WriteLine("True!");
                break;

            case XPathResultType.String:
                Console.WriteLine(navigator.Evaluate(expression));
                break;
        }
    }
}
//</snippet1>