' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
   Private Const filename As String = "items.xml"
   
   Public Shared Sub Main()
      Dim txtreader As XmlTextReader = Nothing
      Dim reader As XmlValidatingReader = Nothing
      
      Try
         'Load the reader with the data file and ignore all white space nodes.         
         txtreader = New XmlTextReader(filename)
         txtreader.WhitespaceHandling = WhitespaceHandling.None
         
         'Implement the validating reader over the text reader. 
         reader = New XmlValidatingReader(txtreader)
         reader.ValidationType = ValidationType.None
         
         'Parse the file and display each of the nodes.
         While reader.Read()
            Select Case reader.NodeType
               Case XmlNodeType.Element
                  Console.Write("<{0}>", reader.Name)
               Case XmlNodeType.Text
                  Console.Write(reader.Value)
               Case XmlNodeType.CDATA
                  Console.Write("<![CDATA[{0}]]>", reader.Value)
               Case XmlNodeType.ProcessingInstruction
                  Console.Write("<?{0} {1}?>", reader.Name, reader.Value)
               Case XmlNodeType.Comment
                  Console.Write("<!--{0}-->", reader.Value)
               Case XmlNodeType.XmlDeclaration
                  Console.Write("<?xml version='1.0'?>")
               Case XmlNodeType.Document
               Case XmlNodeType.DocumentType
                  Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value)
               Case XmlNodeType.EntityReference
                  Console.Write(reader.Name)
               Case XmlNodeType.EndElement
                  Console.Write("</{0}>", reader.Name)
            End Select
         End While
      
      Finally
         If Not (reader Is Nothing) Then
            reader.Close()
         End If
      End Try
   End Sub 'Main 
End Class 'Sample 
' </Snippet1>