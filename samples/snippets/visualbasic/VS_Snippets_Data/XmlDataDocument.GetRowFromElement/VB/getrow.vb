'<snippet1>
Imports System
Imports System.Data
Imports System.Xml

public class Sample

  public shared sub Main()

      'Create an XmlDataDocument.
      Dim doc as XmlDataDocument = new XmlDataDocument()

      'Load the schema.
      doc.DataSet.ReadXmlSchema("store.xsd") 
 
      'Load the XML data.
      doc.Load("2books.xml")
        
      'Change the price on the first book.
      Dim book as XmlElement 
      book = CType(doc.DocumentElement.FirstChild, XmlElement)
      Dim row as DataRow 
      row = doc.GetRowFromElement(book)
      row.Item("price") = "12.95"
        
     Console.WriteLine("Display the modified XML data...")
     Console.WriteLine(doc.DocumentElement.OuterXml)

  end sub
end class
'</snippet1>