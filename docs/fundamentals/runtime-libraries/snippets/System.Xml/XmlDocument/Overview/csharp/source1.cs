// <Snippet1>
using System;
using System.Xml;

public class Sample1
{
    public static void Main()
    {
        //Create the XmlDocument.
        XmlDocument doc = new XmlDocument();
        doc.Load("books.xml");

        //Display all the book titles.
        XmlNodeList elemList = doc.GetElementsByTagName("title");
        for (int i = 0; i < elemList.Count; i++)
        {
            Console.WriteLine(elemList[i].InnerXml);
        }
    }
}
// </Snippet1>
