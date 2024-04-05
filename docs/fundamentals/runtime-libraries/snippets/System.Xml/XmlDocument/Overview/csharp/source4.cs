// <Snippet1>
using System;
using System.Xml;

public class Sample4
{
    public static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("books.xml");

        XmlNode currNode = doc.DocumentElement.FirstChild;
        Console.WriteLine("First book...");
        Console.WriteLine(currNode.OuterXml);

        XmlNode nextNode = currNode.NextSibling;
        Console.WriteLine("\r\nSecond book...");
        Console.WriteLine(nextNode.OuterXml);
    }
}
// </Snippet1>
