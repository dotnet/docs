
Imports System
Imports System.IO
Imports System.Xml
Imports System.Net

public class Sample 

  public shared sub Main(args as String())

         dim UserName as string  = args(0)
     dim SecurelyStoredPassword as string  = args(1)
     dim  Domain as string  = args(2)
		
'<snippet1>
    ' Create the reader.
    Dim txtreader as XmlTextReader = new XmlTextReader("book5.xml")
    Dim reader as XmlValidatingReader = new XmlValidatingReader(txtreader)
    txtreader.WhitespaceHandling = WhitespaceHandling.None

    ' Set the credentials necessary to access the DTD file stored on the network.
    Dim resolver as XmlUrlResolver = new XmlUrlResolver()
    resolver.Credentials = System.Net.CredentialCache.DefaultCredentials
    reader.XmlResolver = resolver

    ' Display each of the element nodes.
    while (reader.Read())
       select case reader.NodeType
         case XmlNodeType.Element:
           Console.Write("<{0}>", reader.Name)
         case XmlNodeType.Text:
           Console.Write(reader.Value)
         case XmlNodeType.DocumentType:
           Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value)
         case XmlNodeType.EntityReference:
           Console.Write(reader.Name)
         case XmlNodeType.EndElement:
           Console.Write("</{0}>", reader.Name)
       end select        
    end while           
  '</snippet1>
    'Close the reader.
    reader.Close()     
  
  end sub
end class



