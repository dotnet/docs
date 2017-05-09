Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Class1   
    
    ' <Snippet1>
    Private Sub SerializeObject(ByVal filename As String)
        Dim serializer As New XmlSerializer(GetType(OrderedItem), _
                                              "http://www.cpandl.com")
        
        ' Create an instance of the class to be serialized.
        Dim i As New OrderedItem()
        
        ' Insert code to set property values.
        ' Writing the document requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        ' Serialize the object, and close the TextWriter.
        serializer.Serialize(writer, i)
        writer.Close()
    End Sub
    
    
    Private Sub DeserializeObject(ByVal filename As String)
        Dim serializer As New XmlSerializer(GetType(OrderedItem), _
                                              "http://www.cpandl.com")
        ' A FileStream is needed to read the XML document.
        Dim fs As New FileStream(filename, FileMode.Open)
        
        ' Declare an object variable of the type to be deserialized.
        Dim i As OrderedItem
        
        ' Deserialize the object.
        i = CType(serializer.Deserialize(fs), OrderedItem)
        ' Insert code to use the properties and methods of the object.
    End Sub
         
    ' </Snippet1>
    
    Public Class OrderedItem
        ' Class added so sample will compile
    End Class
End Class
