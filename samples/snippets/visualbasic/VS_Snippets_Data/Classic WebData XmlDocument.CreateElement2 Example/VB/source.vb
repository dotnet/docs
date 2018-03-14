' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample 

  public shared sub Main() 

    ' Create the XmlDocument.
    Dim doc as XmlDocument = new XmlDocument()
    Dim xmlData as string = "<book xmlns:bk='urn:samples'></book>"

    doc.Load(new StringReader(xmlData))

    ' Create a new element and add it to the document.
    Dim elem as XmlElement = doc.CreateElement("bk", "genre", "urn:samples")
    elem.InnerText = "fantasy"
    doc.DocumentElement.AppendChild(elem)

    Console.WriteLine("Display the modified XML...")
    doc.Save(Console.Out)

  end sub
end class
' </Snippet1>
