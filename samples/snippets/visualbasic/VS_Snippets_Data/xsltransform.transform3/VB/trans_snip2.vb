Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl

public class Sample

   public shared sub Main()
   
'<snippet1>
     'Create the XslTransform object.
     Dim xslt as XslTransform = new XslTransform()

     'Load the stylesheet.
     xslt.Load("output.xsl")

     'Transform the file.
     xslt.Transform("books.xml", "books.html")
'</snippet1>
  end sub
end class