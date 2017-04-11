Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization


' This is the class that will be serialized. 
Public Class Group
    ' The GroupName value will be serialized--unless it's overridden.
    Public GroupName As String
    
    ' This field will be ignored when serialized--
    '  unless it's overridden.
    <XmlIgnoreAttribute()> Public Comment As String
End Class


Public Class Test
    
    Public Shared Sub Main()
        Dim t As New Test()
        t.SerializeObject("IgnoreXml.xml")
    End Sub
    
    
    ' Return an XmlSerializer used for overriding.
    Public Function CreateOverrider() As XmlSerializer
        ' Create the XmlAttributeOverrides and XmlAttributes objects.
        Dim xOver As New XmlAttributeOverrides()
        Dim attrs As New XmlAttributes()
        
        ' Setting XmlIgnore to false overrides the XmlIgnoreAttribute
        ' applied to the Comment field. Thus it will be serialized.
        attrs.XmlIgnore = False
        xOver.Add(GetType(Group), "Comment", attrs)
        
        ' Use the XmlIgnore to instruct the XmlSerializer to ignore
        ' the GroupName instead. 
        attrs = New XmlAttributes()
        attrs.XmlIgnore = True
        xOver.Add(GetType(Group), "GroupName", attrs)
        
        Dim xSer As New XmlSerializer(GetType(Group), xOver)
        Return xSer
    End Function
    
    
    Public Sub SerializeObject(ByVal filename As String)
        ' Create an XmlSerializer instance.
        Dim xSer As XmlSerializer = CreateOverrider()
        
        ' Create the object to serialize and set its properties.
        Dim myGroup As New Group()
        myGroup.GroupName = ".NET"
        myGroup.Comment = "My Comment..."
        
        ' Writing the file requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        ' Serialize the object and close the TextWriter.
        xSer.Serialize(writer, myGroup)
        writer.Close()
    End Sub
End Class

' </Snippet1>
