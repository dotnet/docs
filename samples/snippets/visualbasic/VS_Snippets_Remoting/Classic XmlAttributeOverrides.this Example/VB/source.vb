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
        Dim attrs As New XmlAttributes()
        Dim xOver As New XmlAttributeOverrides()
        
        Dim xRoot As New XmlRootAttribute()
        ' Set a new Namespace and ElementName for the root element.
        xRoot.Namespace = "http://www.cpandl.com"
        xRoot.ElementName = "NewGroup"
        attrs.XmlRoot = xRoot
        
        xOver.Add(GetType(Group), attrs)
        
        ' Get the XmlAttributes object, based on the type.
        Dim tempAttrs As XmlAttributes
        tempAttrs = xOver(GetType(Group))
        
        ' Print the Namespace and ElementName of the root.
        Console.WriteLine(tempAttrs.XmlRoot.Namespace)
        Console.WriteLine(tempAttrs.XmlRoot.ElementName)
        
        Dim xSer As New XmlSerializer(GetType(Group), xOver)
        Return xSer
    End Function
End Class

' </Snippet1>
