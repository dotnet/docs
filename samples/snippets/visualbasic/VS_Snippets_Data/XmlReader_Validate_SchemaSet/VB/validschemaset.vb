'<snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO

public class Sample 

  public shared sub Main() 

    ' Create the XmlSchemaSet class.
    Dim sc as XmlSchemaSet = new XmlSchemaSet()

    ' Add the schema to the collection.
    sc.Add("urn:bookstore-schema", "books.xsd")

    ' Set the validation settings.
    Dim settings as XmlReaderSettings = new XmlReaderSettings()
    settings.ValidationType = ValidationType.Schema
    settings.Schemas = sc
    AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack
 
    ' Create the XmlReader object.
    Dim reader as XmlReader = XmlReader.Create("booksSchemaFail.xml", settings)

    ' Parse the file. 
    while reader.Read()
    end while
    
  end sub

  ' Display any validation errors.
  private shared sub ValidationCallBack(sender as object, e as ValidationEventArgs) 
    Console.WriteLine("Validation Error: {0}", e.Message)
  end sub
end class
'</snippet1>