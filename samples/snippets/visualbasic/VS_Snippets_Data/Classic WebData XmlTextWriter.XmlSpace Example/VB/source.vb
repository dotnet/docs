' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        ' Create the writer.
        Dim writer As XmlTextWriter = Nothing
        writer = New XmlTextWriter("ws.html", Nothing)
        
        ' Write an element (this one is the root).
        writer.WriteStartElement("p")
        
        ' Write the xml:space attribute.
        writer.WriteAttributeString("xml", "space", Nothing, "preserve")
        
        ' Verify that xml:space is set properly.
        If writer.XmlSpace = XmlSpace.Preserve Then
            Console.WriteLine("xmlspace is correct!")
        End If 
        ' Write out the HTML elements.  Insert white space
        ' between 'something' and 'Big'.
        writer.WriteString("something")
        writer.WriteWhitespace("  ")
        writer.WriteElementString("b", "B")
        writer.WriteString("ig")
        
        ' Write the root end element.
        writer.WriteEndElement()
        
        ' Write the XML to file and close the writer.
        writer.Close()
    End Sub 'Main
End Class 'Sample
' </Snippet1>