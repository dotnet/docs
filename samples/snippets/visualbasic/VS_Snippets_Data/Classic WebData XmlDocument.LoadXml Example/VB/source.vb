' <Snippet1>
Imports System
Imports System.Xml

public class Sample 

  public shared sub Main() 
 
    ' Create the XmlDocument.
    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<item><name>wrench</name></item>")

   ' Add a price element.
   Dim newElem as XmlElement = doc.CreateElement("price")
   newElem.InnerText = "10.95"
   doc.DocumentElement.AppendChild(newElem)

   Dim settings As New XmlWriterSettings()
   settings.Indent = True
   ' Save the document to a file and auto-indent the output.
   Dim writer As XmlWriter = XmlWriter.Create("data.xml", settings)
    doc.Save(writer)
  end sub
end class
'</snippet1>
