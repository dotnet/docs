'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.Net

public class Sample

   private shared filename as String = "books.xml"
   private shared stylesheet as String = "sort.xsl"

   public shared sub Main()
   
     'Create the XslTransform.
     Dim xslt as XslTransform = new XslTransform()

     'Create a resolver and set the credentials to use.
     Dim resolver as XmlUrlResolver = new XmlUrlResolver()
     resolver.Credentials = CredentialCache.DefaultCredentials

     'Load the stylesheet.
     xslt.Load(stylesheet, resolver)

     'Load the XML data file.
     Dim doc as XPathDocument = new XPathDocument(filename)

     'Create the XmlTextWriter to output to the console.             
     Dim writer as XmlTextWriter = new XmlTextWriter(Console.Out)

     'Transform the file.
     xslt.Transform(doc, nothing, writer, nothing)
     writer.Close()

  end sub
end class
'</snippet1>