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
      Dim reader as XmlTextReader = new XmlTextReader("2books.xml")
      reader.MoveToContent() 'Moves the reader to the root node.
      doc.Load(reader)
        
     'Change the price on the first book imports the DataSet methods.
     Dim books as DataTable = doc.DataSet.Tables.Item("book")
     books.Rows.Item(0).Item("price") = "12.95"
        
     Console.WriteLine("Display the modified XML data...")
     doc.Save(Console.Out)

  end sub
end class
'</snippet1>