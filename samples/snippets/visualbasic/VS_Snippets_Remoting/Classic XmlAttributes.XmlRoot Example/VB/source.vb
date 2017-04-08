Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization


' This is the class that will be serialized.
Public Class Group
    Public GroupName As String
    <XmlAttribute()> Public GroupCode As Integer
End Class


Public Class Test
    
    Public Shared Sub Main()
        Dim t As New Test()
        t.SerializeObject("OverrideRoot.xml")
    End Sub
    
    
    ' Return an XmlSerializer for overriding attributes.
    Public Function CreateOverrider() As XmlSerializer
        ' Create the XmlAttributes and XmlAttributeOverrides objects.
        Dim attrs As New XmlAttributes()
        Dim xOver As New XmlAttributeOverrides()
        
        Dim xRoot As New XmlRootAttribute()
        
        ' Set a new Namespace and ElementName for the root element.
        xRoot.Namespace = "http://www.cpandl.com"
        xRoot.ElementName = "NewGroup"
        attrs.XmlRoot = xRoot
        
        ' Add the XmlAttributes object to the XmlAttributeOverrides.
        ' No  member name is needed because the whole class is
        ' overridden. 
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
    
    
    Public Sub SerializeObject(ByVal filename As String)
        ' Create the XmlSerializer using the CreateOverrider method.
        Dim xSer As XmlSerializer = CreateOverrider()
        
        ' Create the object to serialize.
        Dim myGroup As New Group()
        myGroup.GroupName = ".NET"
        myGroup.GroupCode = 123
        
        ' To write the file, a TextWriter is required.
        Dim writer As New StreamWriter(filename)
        
        ' Serialize the object and close the TextWriter.
        xSer.Serialize(writer, myGroup)
        writer.Close()
    End Sub
End Class

' </Snippet1>
