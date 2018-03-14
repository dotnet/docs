' <Snippet1>
imports System
imports System.Data
imports System.Xml

public class Sample

  public shared sub Main()

    'Create an XmlDataDocument.
    Dim doc as XmlDataDocument = new XmlDataDocument()

    'Load the schema.
    doc.DataSet.ReadXmlSchema("store.xsd") 
 
    'Load the XML data.
    doc.Load("2books.xml")

    'Change the price on the first book using the DataSet methods.
    Dim books as DataTable = doc.DataSet.Tables.Item("book")
    books.Rows.Item(0).Item("price") = "12.95" 

    Console.WriteLine("Display the modified XML data...")
    doc.Save(Console.Out)

  end sub
end class
   ' </Snippet1>

