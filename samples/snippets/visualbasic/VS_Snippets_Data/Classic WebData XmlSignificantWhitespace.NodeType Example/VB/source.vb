' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic

Public Class Sample
    Private currNode As XmlNode
    Private filename As String = "space.xml"
    Private reader As XmlTextReader = Nothing
    
    Public Shared Sub Main()
        Dim test As New Sample()
    End Sub 'Main
    
    Public Sub New()
            Dim doc As New XmlDocument()
            doc.LoadXml("<!-- Sample XML fragment -->" & _
                        "<author xml:space='preserve'>" & _
                        "<first-name>Eva</first-name>"& _
                        "<last-name>Corets</last-name>" & _ 
                        "</author>")
            
            Console.WriteLine("InnerText before...")
            Console.WriteLine(doc.DocumentElement.InnerText)
            
            ' Add white space.     
            currNode = doc.DocumentElement
            Dim sigws As XmlSignificantWhitespace = doc.CreateSignificantWhitespace(ControlChars.Tab)
            currNode.InsertAfter(sigws, currNode.FirstChild)
            
            Console.WriteLine()
            Console.WriteLine("InnerText after...")
            Console.WriteLine(doc.DocumentElement.InnerText)
            
            ' Save and then display the file.
            doc.Save(filename)
            Console.WriteLine()
            Console.WriteLine("Reading file...")
            ReadFile(filename)
        
    End Sub 'New
     
    
    ' Parse the file and print out each node.
    Public Sub ReadFile(filename As String)
        Try
            reader = New XmlTextReader(filename)
            Dim sNodeType As String = Nothing
            While reader.Read()
                sNodeType = NodeTypeToString(reader.NodeType)
                
                'Print the node type, name, value
                Console.WriteLine("{0}<{1}> {2}", sNodeType, reader.Name, reader.Value)
            End While
        Finally
            If (reader IsNot Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'ReadFile
     
    Public Shared Function NodeTypeToString(nodetype As XmlNodeType) As String
        Dim sNodeType As String = Nothing
        Select Case nodetype
            Case XmlNodeType.None
                sNodeType = "None"
            Case XmlNodeType.Element
                sNodeType = "Element"
            Case XmlNodeType.Attribute
                sNodeType = "Attribute"
            Case XmlNodeType.Text
                sNodeType = "Text"
            Case XmlNodeType.Comment
                sNodeType = "Comment"
            Case XmlNodeType.Document
                sNodeType = "Document"
            Case XmlNodeType.Whitespace
                sNodeType = "Whitespace"
            Case XmlNodeType.SignificantWhitespace
                sNodeType = "SignificantWhitespace"
            Case XmlNodeType.EndElement
                sNodeType = "EndElement"
        End Select
        Return sNodeType
    End Function 'NodeTypeToString
End Class 'Sample
' </Snippet1>
