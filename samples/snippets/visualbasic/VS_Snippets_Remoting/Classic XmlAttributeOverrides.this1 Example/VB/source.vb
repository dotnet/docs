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
        ' Create an XmlSerializer with overriding attributes.
        Dim xOver As New XmlAttributeOverrides()
        
        ' Create an XmlAttributeAttribute object and set the
        ' AttributeName property. 
        Dim xAtt As New XmlAttributeAttribute()
        xAtt.AttributeName = "Code"
        
        ' Create a new XmlAttributes object and set the
        ' XmlAttributeAttribute object to the XmlAttribute property. 
        Dim attrs As New XmlAttributes()
        attrs.XmlAttribute = xAtt
        
        ' Add the XmlAttributes to the XmlAttributeOverrides object. The
        ' name of the overridden attribute must be specified. 
        xOver.Add(GetType(Group), "GroupCode", attrs)
                
        ' Get the XmlAttributes object for the type and member.
        Dim tempAttrs As XmlAttributes
        tempAttrs = xOver(GetType(Group), "GroupCode")
        Console.WriteLine(tempAttrs.XmlAttribute.AttributeName)
        
        ' Create the XmlSerializer instance and return it.
        Dim xSer As New XmlSerializer(GetType(Group), xOver)
        Return xSer
    End Function
End Class

' </Snippet1>
