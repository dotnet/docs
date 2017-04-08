' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Schema


Public Class Group
    <XmlAttribute(Namespace := "http://www.cpandl.com")> _
        Public GroupName As String    
    <XmlAttribute(DataType := "base64Binary")> _
        Public GroupNumber() As Byte    
    <XmlAttribute(DataType := "date", AttributeName := "CreationDate")> _
        Public Today As DateTime
End Class

Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("Attributes.xml")
    End Sub 
    
    Public Sub SerializeObject(ByVal filename As String)
        ' Create an instance of the XmlSerializer class.
        Dim mySerializer As New XmlSerializer(GetType(Group))
        
        ' Writing the file requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        ' Create an instance of the class that will be serialized.
        Dim myGroup As New Group()
        
        ' Set the object properties.
        myGroup.GroupName = ".NET"
        
        Dim hexByte() As Byte = {Convert.ToByte(100), Convert.ToByte(50)}
        myGroup.GroupNumber = hexByte
        
        Dim myDate As New DateTime(2001, 1, 10)
        myGroup.Today = myDate
        
        ' Serialize the class, and close the TextWriter.
        mySerializer.Serialize(writer, myGroup)
        writer.Close()
    End Sub
End Class

' </Snippet1>
