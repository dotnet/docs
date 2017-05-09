' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample 

  public shared sub Main()

    'Create the validating reader.
    Dim txtreader as XmlTextReader = new XmlTextReader("attrs.xml")
    Dim reader as XmlValidatingReader = new XmlValidatingReader(txtreader)

    'Read the genre attribute.
    reader.MoveToContent()
    reader.MoveToFirstAttribute()
    Dim genre As String = reader.Value
    Console.WriteLine("The genre value: " & genre)

    'Close the reader.
    reader.Close()

  End sub
End class 
' </Snippet1>
