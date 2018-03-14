' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
   
   Public Shared Sub Main()
      Dim reader As XmlTextReader = Nothing
      
      Try
         'Load the reader with the XML file.
         reader = New XmlTextReader("attrs.xml")
         
         'Read the genre attribute.
         reader.MoveToContent()
         reader.MoveToFirstAttribute()
         Dim genre As String = reader.Value
         Console.WriteLine("The genre value: " & genre)
      
      Finally
         If Not (reader Is Nothing) Then
            reader.Close()
         End If
      End Try
   End Sub 'Main 
End Class 'Sample
' </Snippet1>