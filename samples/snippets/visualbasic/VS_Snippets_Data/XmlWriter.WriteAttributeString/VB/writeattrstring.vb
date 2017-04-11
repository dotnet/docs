'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample 

  Public Shared Sub Main() 
 
     Dim writer As XmlWriter = Nothing

     writer = XmlWriter.Create("sampledata.xml")
        
     ' Write the root element.
     writer.WriteStartElement("book")

     ' Write the xmlns:bk="urn:book" namespace declaration.
     writer.WriteAttributeString("xmlns","bk", Nothing,"urn:book")
  
     ' Write the bk:ISBN="1-800-925" attribute.
     writer.WriteAttributeString("ISBN", "urn:book", "1-800-925")

     writer.WriteElementString("price", "19.95")

     ' Write the close tag for the root element.
     writer.WriteEndElement()
             
     ' Write the XML to file and close the writer.
     writer.Flush()
     writer.Close()  

  End Sub
End Class
'</snippet1>