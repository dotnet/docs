' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
 
public class Sample 

  public shared sub Main() 
   
    ' Create and load the XML document.
    Dim doc as XmlDocument = new XmlDocument()
    Dim xmlString as string = "<book><title>Oberon's Legacy</title></book>"
    doc.Load(new StringReader(xmlString))
  
    ' Create an XML declaration. 
    Dim xmldecl as XmlDeclaration 
    xmldecl = doc.CreateXmlDeclaration("1.0",nothing, nothing)
    xmldecl.Encoding="UTF-8"
    xmldecl.Standalone="yes"     
      
    ' Add the new node to the document.
    Dim root as XmlElement = doc.DocumentElement
    doc.InsertBefore(xmldecl, root)
    
    ' Display the modified XML document 
    Console.WriteLine(doc.OuterXml)
      
  end sub
end class
   ' </Snippet1>

