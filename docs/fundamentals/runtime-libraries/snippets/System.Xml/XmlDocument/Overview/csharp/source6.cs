// <Snippet1>
using System;
using System.Xml;

public class Sample6
{
    public static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("booksort.xml");

        XmlNodeList nodeList;
        XmlNode root = doc.DocumentElement;

        nodeList = root.SelectNodes("descendant::book[author/last-name='Austen']");

        //Change the price on the books.
        foreach (XmlNode book in nodeList)
        {
            book.LastChild.InnerText = "15.95";
        }

        Console.WriteLine("Display the modified XML document....");
        doc.Save(Console.Out);
    }
}
// </Snippet1>
