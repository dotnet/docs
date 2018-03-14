' <Snippet1>
 Imports System
 Imports System.Xml
 Imports Microsoft.VisualBasic
 
 public class Sample 

   public shared sub Main() 

       Dim doc as XmlDocument = new XmlDocument()
       doc.Load("books.xml")
 
       Dim currNode as XmlNode = doc.DocumentElement.FirstChild
       Console.WriteLine("First book...")
       Console.WriteLine(currNode.OuterXml)

       Dim nextNode as XmlNode = currNode.NextSibling
       Console.WriteLine(ControlChars.LF + "Second book...")
       Console.WriteLine(nextNode.OuterXml) 
 
   end sub
 end class
' </Snippet1>
