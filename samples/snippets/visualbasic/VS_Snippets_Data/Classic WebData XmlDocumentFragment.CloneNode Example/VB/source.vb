' <Snippet1>
 Imports System
 Imports System.IO
 Imports System.Xml
 
 public class Sample
 
   public shared sub Main()
     
     ' Create the XmlDocument.
     Dim doc as XmlDocument  = new XmlDocument()
     doc.LoadXml("<items/>")

     ' Create a document fragment.
     Dim docFrag as XmlDocumentFragment = doc.CreateDocumentFragment()
 
     ' Set the contents of the document fragment.
     docFrag.InnerXml ="<item>widget</item>"

     ' Create a deep clone.  The cloned node
     ' includes child nodes.
     Dim deep as XmlNode = docFrag.CloneNode(true)
     Console.WriteLine("Name: " + deep.Name)
     Console.WriteLine("OuterXml: " + deep.OuterXml)

     ' Create a shallow clone.  The cloned node does
     ' not include any child nodes.
     Dim shallow as XmlNode = docFrag.CloneNode(false)
     Console.WriteLine("Name: " + shallow.Name)
     Console.WriteLine("OuterXml: " + shallow.OuterXml)    
 
   end sub
 end class
 ' </Snippet1>

