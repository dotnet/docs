//<snippet5>
using System;
using System.Xml;
using System.Xml.XPath;

namespace SortBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            XPathDocument doc = new XPathDocument("contosoBooks.xml");
            XPathNavigator nav = doc.CreateNavigator();

            XPathExpression expr;
            expr = nav.Compile("/bookstore/book");

            expr.AddSort("price", XmlSortOrder.Descending,
                           XmlCaseOrder.None, "", XmlDataType.Number);

            XPathNodeIterator iterator = nav.Select(expr);
            while (iterator.MoveNext())
            {
                if (iterator.Current.HasChildren)
                {
                    XPathNodeIterator childIter =
              iterator.Current.SelectChildren(XPathNodeType.Element);
                    while (childIter.MoveNext())
                    {
                        Console.WriteLine(childIter.Current.Value);

                    }
                }
            }
        }
    }
}

//</snippet5>

