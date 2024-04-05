// <Snippet1>
using System;
using System.Xml;

public class Sample5
{
    public static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("books.xml");

        XmlNode lastNode = doc.DocumentElement.LastChild;
        Console.WriteLine("Last book...");
        Console.WriteLine(lastNode.OuterXml);

        XmlNode prevNode = lastNode.PreviousSibling;
        Console.WriteLine("\r\nPrevious book...");
        Console.WriteLine(prevNode.OuterXml);
    }
}
// </Snippet1>
