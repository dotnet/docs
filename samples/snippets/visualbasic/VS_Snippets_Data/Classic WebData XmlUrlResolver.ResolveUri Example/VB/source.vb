' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
  Public Shared Sub Main()

     Dim resolver As New XmlUrlResolver()
     Dim baseUri As New Uri("http://servername/tmp/test.xsl")
     Dim fulluri As Uri = resolver.ResolveUri(baseUri, "includefile.xsl")
            
     ' Get a stream object containing the XSL file
     Dim s As Stream = CType(resolver.GetEntity(fulluri, Nothing, GetType(Stream)), Stream)
            
     ' Read the stream object displaying the contents of the XSL file
     Dim reader As New XmlTextReader(s)
     While reader.Read()
        Console.WriteLine(reader.ReadOuterXml())
     End While
        
  End Sub 'New 
End Class 'Sample
' </Snippet1>