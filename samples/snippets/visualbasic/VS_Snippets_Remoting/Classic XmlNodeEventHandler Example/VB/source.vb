Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization



Public Class Class1
    
    ' <Snippet1>
    Private Sub DeserializeItem(ByVal filename As String)
        Dim mySerializer As New XmlSerializer(GetType(ObjectToDeserialize))
        ' Add an instance of the delegate to the event.
        AddHandler mySerializer.UnknownNode, AddressOf Serializer_UnknownNode
        ' A FileStream is needed to read the file to deserialize.
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim o As ObjectToDeserialize = _
            CType(mySerializer.Deserialize(fs), ObjectToDeserialize)
    End Sub 'DeserializeItem
    
    
    Private Sub Serializer_UnknownNode _
                    (ByVal sender As Object, _
                     ByVal e As XmlNodeEventArgs)
        
        Console.WriteLine("UnknownNode Name: " & e.Name)
        Console.WriteLine("UnknownNode LocalName: " & e.LocalName)
        Console.WriteLine("UnknownNode Namespace URI: " & e.NamespaceURI)
        Console.WriteLine("UnknownNode Text: " & e.Text)
        
        Dim o As Object = e.ObjectBeingDeserialized
        Console.WriteLine("Object being deserialized " & o.ToString())
        
        Dim myNodeType As XmlNodeType = e.NodeType
        Console.WriteLine(myNodeType)
    End Sub
    
    ' </Snippet1>
    
    Public Class ObjectToDeserialize
        ' Class added so that sample will compile
    End Class
End Class
