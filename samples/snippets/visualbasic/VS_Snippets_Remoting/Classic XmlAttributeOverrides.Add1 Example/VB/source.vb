Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization



' <Snippet1>
' This is the class that will be serialized.
Public Class Group
    Public GroupName As String
    <XmlAttribute()> Public GroupCode As Integer
End Class

Public Class Sample
    
    Public Function CreateOverrider() As XmlSerializer
        ' Create an XmlAttributeOverrides object. 
        Dim xOver As New XmlAttributeOverrides()
        
        ' Create an XmlAttributeAttribute to override the base class
        ' object's XmlAttributeAttribute object. Give the overriding object
        ' a new attribute name ("Code").
        Dim xAtt As New XmlAttributeAttribute()
        xAtt.AttributeName = "Code"
        
        ' Create an instance of the XmlAttributes class and set the
        ' XmlAttribute property to the XmlAttributeAttribute object. 
        Dim attrs As New XmlAttributes()
        attrs.XmlAttribute = xAtt
        
        ' Add the XmlAttributes object to the XmlAttributeOverrides
        ' and specify the type and member name to override. 
        xOver.Add(GetType(Group), "GroupCode", attrs)
        
        Dim xSer As New XmlSerializer(GetType(Group), xOver)
        Return xSer
    End Function
End Class

' </Snippet1>
