' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath

Public Class Sample
    Private Shared filename1 As String = "books.xml"
    Private Shared stylesheet1 As String = "output.xsl"
    
    
    Public Shared Sub Main()
        'Load the stylesheet.
        Dim xslt As New XslTransform()
        xslt.Load(stylesheet1)
        
        'Load the file to transform.
        Dim doc As New XPathDocument(filename1)
        
        'Create an XmlTextWriter which outputs to the console.
        Dim writer As New XmlTextWriter(Console.Out)
        
        'Transform the file and send the output to the console.
        xslt.Transform(doc, Nothing, writer, Nothing)
        writer.Close()
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
