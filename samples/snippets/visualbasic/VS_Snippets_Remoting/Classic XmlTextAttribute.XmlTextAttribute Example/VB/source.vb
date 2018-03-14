' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml.Schema
Imports System.Xml


Public Class Group
    Public GroupName As String
    Public Comment As String
End Class

Public Class Test
    
    Public Shared Sub Main()
        Dim t As New Test()
        t.SerializerOrder("TextOverride.xml")
    End Sub
    
    ' Create an instance of the XmlSerializer class that overrides
    ' the default way it serializes an object. 
    Public Function CreateOverrider() As XmlSerializer
        ' CreatE instances of the XmlAttributes and
        ' XmlAttributeOverrides classes.
        
        Dim attrs As New XmlAttributes()        
        Dim xOver As New XmlAttributeOverrides()
        
        ' Create an XmlTextAttribute to override the default
        ' serialization process. 
        Dim xText As New XmlTextAttribute()
        attrs.XmlText = xText
        
        ' Add the XmlAttributes to the XmlAttributeOverrides.
        xOver.Add(GetType(Group), "Comment", attrs)
        
        ' Create the XmlSerializer, and return it.
        Dim xSer As New XmlSerializer(GetType(Group), xOver)
        Return xSer
    End Function
    
    
    Public Sub SerializerOrder(ByVal filename As String)
        ' Create an XmlSerializer instance.
        Dim xSer As XmlSerializer = CreateOverrider()
        
        ' Create the object and serialize it.
        Dim myGroup As New Group()
        myGroup.Comment = "This is a great product."
        
        Dim writer As New StreamWriter(filename)
        xSer.Serialize(writer, myGroup)
    End Sub
End Class

' </Snippet1>