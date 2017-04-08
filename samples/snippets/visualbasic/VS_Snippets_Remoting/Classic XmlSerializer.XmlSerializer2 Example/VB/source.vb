Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Class1
    
    ' <Snippet1>
    Private Sub SerializeObject(ByVal filename As String)
        ' Create an XmlRootAttribute, and set its properties.
        Dim xRoot As New XmlRootAttribute()
        xRoot.ElementName = "CustomRoot"
        xRoot.Namespace = "http://www.cpandl.com"
        xRoot.IsNullable = True
        
        ' Construct the XmlSerializer with the XmlRootAttribute.
        Dim serializer As New XmlSerializer(GetType(OrderedItem), xRoot)
        
        ' Create an instance of the object to serialize.
        Dim i As New OrderedItem()
        ' Insert code to set properties of the ordered item.
        ' Writing the document requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        serializer.Serialize(writer, i)
        writer.Close()
    End Sub
        
    Private Sub DeserializeObject(ByVal filename As String)
        ' Create an XmlRootAttribute, and set its properties.
        Dim xRoot As New XmlRootAttribute()
        xRoot.ElementName = "CustomRoot"
        xRoot.Namespace = "http://www.cpandl.com"
        xRoot.IsNullable = True
        
        Dim serializer As New XmlSerializer(GetType(OrderedItem), xRoot)
        
        ' A FileStream is needed to read the XML document.
        Dim fs As New FileStream(filename, FileMode.Open)
        ' Deserialize the object.
        Dim i As OrderedItem = CType(serializer.Deserialize(fs), OrderedItem)
        ' Insert code to use the object's properties and methods.
    End Sub
         
    ' </Snippet1>
    Public Class OrderedItem
        ' Class added so sample will compile
    End Class
End Class
