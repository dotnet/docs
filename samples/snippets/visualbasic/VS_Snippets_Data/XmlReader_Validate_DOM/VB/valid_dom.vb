'<snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO

public class Sample 

  public shared sub Main() 

    ' Create and load the XML document.
    Dim doc as XmlDocument = new XmlDocument()
    doc.Load("booksSchema.xml")

    ' Make changes to the document.
    Dim book as XmlElement
    book = CType(doc.DocumentElement.FirstChild, XmlElement)
    book.SetAttribute("publisher", "Worldwide Publishing")

    ' Create an XmlNodeReader using the XML document.
    Dim nodeReader as XmlNodeReader = new XmlNodeReader(doc)

    ' Set the validation settings on the XmlReaderSettings object.
    Dim settings as XmlReaderSettings = new XmlReaderSettings()
    settings.ValidationType = ValidationType.Schema
    settings.Schemas.Add("urn:bookstore-schema", "books.xsd")
    AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack

    ' Create a validating reader that wraps the XmlNodeReader object.
    Dim reader as XmlReader = XmlReader.Create(nodeReader,settings)
    
    ' Parse the XML file.
    while (reader.Read())
    end while
  end sub

  ' Display any validation errors.
  private shared sub ValidationCallBack(sender as object, e as ValidationEventArgs)
    Console.WriteLine("Validation Error: {0}", e.Message)
  end sub

end class
'</snippet1>
