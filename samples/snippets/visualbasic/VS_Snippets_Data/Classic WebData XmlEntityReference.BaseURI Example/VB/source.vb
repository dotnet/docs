' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()
  
    'Create the XmlDocument.
    Dim doc as XmlDocument = new XmlDocument()
    doc.Load("http://localhost/uri.xml")
                     
    'Display information on the entity reference node.
    Dim entref as XmlEntityReference =  CType(doc.DocumentElement.LastChild.FirstChild, XmlEntityReference) 
    Console.WriteLine("Name of the entity reference:  {0}", entref.Name)
    Console.WriteLine("Base URI of the entity reference:  {0}", entref.BaseURI)
    Console.WriteLine("The entity replacement text:  {0}", entref.InnerText)
  end sub
end class
   ' </Snippet1>

