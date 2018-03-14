Imports System
Imports System.IO
Imports System.Xml
Imports System.Text

Public Class Sample 

  Public shared sub Main() 

'<snippet1> 
Dim settings As XmlWriterSettings = New XmlWriterSettings()
settings.OmitXmlDeclaration = true
settings.ConformanceLevel = ConformanceLevel.Fragment
settings.CloseOutput = false

' Create the XmlWriter object and write some content.
Dim strm as MemoryStream = new MemoryStream()
Dim writer As XmlWriter = XmlWriter.Create(strm, settings)
writer.WriteElementString("orderID", "1-456-ab")
writer.WriteElementString("orderID", "2-36-00a")
writer.Flush()
writer.Close()

' Do additonal processing on the stream.
'</snippet1>
        
  end sub
end class