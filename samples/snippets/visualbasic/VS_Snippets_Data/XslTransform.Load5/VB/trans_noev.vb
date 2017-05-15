Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
 
 public class Sample
 
   public shared sub Main () 
   

       Dim doc as new XmlDocument()
       doc.Load("c:\tmp\output.xsl")
       TransformFile(doc.CreateNavigator())
 
   end sub 
 
   ' Perform an XSLT transformation where xsltNav is an XPathNavigator containing
   ' a stylesheet from an untrusted source.
' <snippet1>

   public shared sub TransformFile (xsltNav as XPathNavigator) 
    
    ' Load the stylesheet.
    Dim xslt as XslTransform = new XslTransform()
    xslt.Load(xsltNav, nothing, nothing)

    ' Transform the file.
    xslt.Transform("books.xml", "books.html", nothing)
   end sub
' </snippet1>
end class