' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim reader As XmlNodeReader = Nothing
        
        Try
            'Create and load the XML document.
            Dim doc As New XmlDocument()
            doc.LoadXml("<book genre='novel' ISBN='1-861003-78'> " & _
                       "<title>Pride And Prejudice</title>" & _
                       "<price>19.95</price>" & _
                       "</book>")
            
            'Load the XmlNodeReader 
            reader = New XmlNodeReader(doc)
            
            'Read the attributes on the book element.
            reader.MoveToContent()
            While reader.MoveToNextAttribute()
                Console.WriteLine("{0} = {1}", reader.Name, reader.Value)
            End While
            
            'Move the reader to the title element.
            reader.Read()
            
            'Read the title and price elements.
            Console.WriteLine(reader.ReadElementString())
            Console.WriteLine(reader.ReadElementString())
        
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main ' End class
End Class 'Sample
' </Snippet1>
