Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
 
 public class Sample
    
   public shared sub Main () 
   

       Dim reader as new XmlTextReader("c:\tmp\output.xsl")
       TransformFile(reader, "http://localhost/data")

   end sub 
 
   ' Perform an XSLT transformation where xsltReader is an XmlReader containing
   ' a stylesheet and secureURI is a trusted URI that can be used to create Evidence.
' <snippet1>

   public shared sub TransformFile (xsltReader as XmlReader, secureURL as String) 
    
    ' Load the stylesheet using a default XmlUrlResolver and Evidence 
    ' created using the trusted URL.
    Dim xslt as XslTransform = new XslTransform()
    xslt.Load(xsltReader, new XmlUrlResolver(), XmlSecureResolver.CreateEvidenceForUrl(secureURL))

    ' Transform the file.
    xslt.Transform("books.xml", "books.html", new XmlUrlResolver())
   end sub
' </snippet1>
end class