' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample 

  public shared sub Main()

    'Create the validating reader.
    Dim txtreader as XmlTextReader = new XmlTextReader("attrs.xml")
    Dim reader as XmlValidatingReader = new XmlValidatingReader(txtreader)

    'Read the ISBN attribute.
    reader.MoveToContent()
    Dim isbn as string = reader.GetAttribute("ISBN")
    Console.WriteLine("The ISBN value: " + isbn)

    'Close the reader.
    reader.Close()

  End sub
End class 
' </Snippet1>
