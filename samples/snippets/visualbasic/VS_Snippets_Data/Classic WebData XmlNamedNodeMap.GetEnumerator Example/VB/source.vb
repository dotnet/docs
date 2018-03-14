' <Snippet1>
 Option Explicit
 Option Strict
 
 Imports System
 Imports System.IO
 Imports System.Xml
 Imports System.Collections
 
 public class Sample
   public shared sub Main()

       Dim doc as XmlDocument = new XmlDocument()
       doc.LoadXml("<book genre='novel' publicationdate='1997' " & _
                   "      ISBN='1-861001-57-5'>" & _
                   "  <title>Pride And Prejudice</title>" & _
                   "</book>")      
 
       Dim attrColl as XmlAttributeCollection = doc.DocumentElement.Attributes

       Console.WriteLine("Display all the attributes for this book...")
       Dim ienum as IEnumerator = attrColl.GetEnumerator()
       Dim attr as XmlAttribute   
       while (ienum.MoveNext())
         attr = CType(ienum.Current, XmlAttribute)
         Console.WriteLine("{0} = {1}", attr.Name, attr.Value)
       end while 
 
   end sub
 end class
 ' </Snippet1>

