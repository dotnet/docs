// <Snippet1>
using System;
using System.Xml;

public class Sample3
{
    public static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<book ISBN='1-861001-57-5'>" +
                    "<title>Pride And Prejudice</title>" +
                    "<price>19.95</price>" +
                    "</book>");

        XmlNode root = doc.FirstChild;

        Console.WriteLine("Display the price element...");
        Console.WriteLine(root.LastChild.OuterXml);
    }
}
// </Snippet1>
