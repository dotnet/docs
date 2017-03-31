 '<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath

Public Class Sample    
    
  Public Shared Sub Main() 
        
    ' Create the XslCompiledTransform object and load the style sheet.
    Dim xslt As New XslCompiledTransform()
    xslt.Load("message.xsl")
        
    Dim argList As New XsltArgumentList()
    AddHandler argList.XsltMessageEncountered, AddressOf MessageCallBack
        
    ' Load the file to transform.
    Dim doc As New XPathDocument("books.xml")
        
    ' Transform the file.
    xslt.Transform(doc, argList, XmlWriter.Create("output.xml"))
    
  End Sub 'Main     
    
  Private Shared Sub MessageCallBack(ByVal sender As Object, ByVal e As XsltMessageEncounteredEventArgs) 
    Console.WriteLine("Message received: {0}", e.Message)
    
  End Sub 'MessageCallBack
End Class 'Sample 
'</snippet1>