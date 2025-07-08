' <Snippet1>
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO

Public Module Sample 
  Public Sub Main() 

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
    While reader.Read()
    End While
    
  End Sub

  ' Display any validation errors.
  Private Sub ValidationCallBack(sender as object, e as ValidationEventArgs) 
    Console.WriteLine($"Validation Error:{vbCrLf}   {e.Message}")
    Console.WriteLine()
  End Sub
End Module
' The example displays output like the following:
'   Validation Error: 
'        The element 'book' in namespace 'urn:bookstore-schema' has invalid child element 'author' 
'        in namespace 'urn:bookstore-schema'. List of possible elements expected: 'title' in 
'        namespace 'urn:bookstore-schema'.
'
'    Validation Error: 
'       The element 'author' in namespace 'urn:bookstore-schema' has invalid child element 'name' 
'       in namespace 'urn:bookstore-schema'. List of possible elements expected: 'first-name' in 
'       namespace 'urn:bookstore-schema'.
' </Snippet1>