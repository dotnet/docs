' <Snippet1>
 Imports System
 Imports System.Xml
 
 public class Sample
 
   public shared sub Main()
   
       Dim doc as XmlDocument = new XmlDocument()
       doc.LoadXml("<book>" & _
                   "  <title>Pride And Prejudice</title>" & _
                   "  <price/>" & _
                   "</book>")   
 
       Dim currNode as XmlElement 
       currNode = CType (doc.DocumentElement.LastChild, XmlElement)
       if (currNode.IsEmpty)
         currNode.InnerXml="19.95"
       end if
 
       Console.WriteLine("Display the modified XML...")
       Console.WriteLine(doc.OuterXml)
 
   end sub
 end class
   ' </Snippet1>

