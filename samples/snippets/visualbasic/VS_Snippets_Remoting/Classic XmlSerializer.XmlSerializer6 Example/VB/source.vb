Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Sample
    
    ' <Snippet1>
    Private Sub SerializeObject(ByVal filename As String)
        Dim serializer As New XmlSerializer(GetType(OrderedItem))
        
        ' Create an instance of the class to be serialized.
        Dim i As New OrderedItem()
        
        ' Set the public property values.
        With i
            .ItemName = "Widget"
            .Description = "Regular Widget"
            .Quantity = 10
            .UnitPrice = CDec(2.3)
        End With
        
        ' Writing the document requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        ' Serialize the object, and close the TextWriter.
        serializer.Serialize(writer, i)
        writer.Close()
    End Sub
    
    
    ' This is the class that will be serialized.
    Public Class OrderedItem
        Public ItemName As String
        Public Description As String
        Public UnitPrice As Decimal
        Public Quantity As Integer
    End Class
    
    ' </Snippet1>
End Class
