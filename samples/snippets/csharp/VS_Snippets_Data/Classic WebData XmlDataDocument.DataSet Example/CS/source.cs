// <Snippet1>
using System;
using System.Data;
using System.Xml;

public class Sample
{
  public static void Main()
  {
     //Create an XmlDataDocument.
     XmlDataDocument doc = new XmlDataDocument();

     //Load the schema file.
     doc.DataSet.ReadXmlSchema("store.xsd"); 

     //Load the XML data.
     doc.Load("2books.xml");

     //Update the price on the first book using the DataSet methods.
     DataTable books = doc.DataSet.Tables["book"];
     books.Rows[0]["price"] = "12.95";  

     Console.WriteLine("Display the modified XML data...");
     doc.Save(Console.Out);
  }
} // End class
   // </Snippet1>

