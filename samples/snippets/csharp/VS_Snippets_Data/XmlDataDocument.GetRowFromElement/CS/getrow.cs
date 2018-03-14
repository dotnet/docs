//<snippet1>
using System;
using System.Data;
using System.Xml;
public class Sample {
    public static void Main() {
        // Create an XmlDataDocument.
        XmlDataDocument doc = new XmlDataDocument();
        
        // Load the schema file.
        doc.DataSet.ReadXmlSchema("store.xsd");
        
        // Load the XML data.
        doc.Load("2books.xml");
        
        //Change the price on the first book.
        XmlElement root = doc.DocumentElement;
        DataRow row = doc.GetRowFromElement((XmlElement)root.FirstChild);
        row["price"] = "12.95";
        
        Console.WriteLine("Display the modified XML data...");
        Console.WriteLine(doc.DocumentElement.OuterXml);
    }
} // End class
//</snippet1>