 '<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath

Public Class Sample
    
    Private Const filename As String = "books.xml"
    Private Const stylesheet As String = "outputConsole.xsl"   
    
    Public Shared Sub Main() 
        
        ' Create the XslTransform object and load the style sheet.
        Dim xslt As New XslCompiledTransform()
        xslt.Load(stylesheet)
        
        ' Load the file to transform.
        Dim doc As New XPathDocument(filename)
        
        ' Create the writer.             
        Dim writer As XmlWriter = XmlWriter.Create(Console.Out, xslt.OutputSettings)
        
        ' Transform the file and send the output to the console.
        xslt.Transform(doc, writer)
        writer.Close()
    
    End Sub 'Main 
End Class 'Sample 
'</snippet1>