'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl

public class Sample

   public shared sub Main() 
    
      ' Create the XslCompiledTransform and load the style sheet.
      Dim xslt as XslCompiledTransform = new XslCompiledTransform()
      xslt.Load("discount.xsl")

      ' Create the XsltArgumentList.
      Dim argList as XsltArgumentList = new XsltArgumentList()
         
      ' Calculate the discount date.
      Dim orderDate as DateTime = new DateTime(2004, 01, 15)
      Dim discountDate as DateTime = orderDate.AddDays(20)
      argList.AddParam("discount", "", discountDate.ToString())

      ' Create an XmlWriter to write the output.             
     Dim writer as XmlWriter = XmlWriter.Create("orderOut.xml")

     ' Transform the file.
     xslt.Transform(new XPathDocument("order.xml"), argList, writer)
     writer.Close()

  end sub

end class
'</snippet1>
