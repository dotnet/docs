' <snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Net

public class Sample 

  public shared sub Main()

    ' Supply the credentials necessary access the DTD file stored on the network.
    Dim resolver as XmlUrlResolver = new XmlUrlResolver()
    resolver.Credentials = CredentialCache.DefaultCredentials

    ' Create and load the XmlDocument.
    Dim doc as XmlDocument = new XmlDocument()
    doc.XmlResolver = resolver  ' Set the resolver.
    doc.Load("book5.xml")

    ' Display the entity replacement text which is pulled from the DTD file.
    Console.WriteLine(doc.DocumentElement.LastChild.InnerText)
  
  end sub
end class
' </snippet1>


