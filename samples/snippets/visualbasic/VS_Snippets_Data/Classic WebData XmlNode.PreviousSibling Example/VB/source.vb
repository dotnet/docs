' <Snippet1>
 Imports System
 Imports System.Xml
 Imports Microsoft.VisualBasic
 
 public class Sample 

   public shared sub Main() 

       Dim doc as XmlDocument = new XmlDocument()
       doc.Load("books.xml")
 
       Dim lastNode as XmlNode = doc.DocumentElement.LastChild
       Console.WriteLine("Last book...")
       Console.WriteLine(lastNode.OuterXml)

       Dim prevNode as XmlNode = lastNode.PreviousSibling
       Console.WriteLine(ControlChars.LF + "Previous book...")
       Console.WriteLine(prevNode.OuterXml)  
   end sub
 end class
' </Snippet1>
