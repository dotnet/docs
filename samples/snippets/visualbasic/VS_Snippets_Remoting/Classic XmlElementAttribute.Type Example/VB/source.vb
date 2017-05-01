Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.Collections
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Group
    <XmlElement(GetType(Manager))> _    
    Public Staff() As Employee
    
    <XmlElement(GetType(Integer)), _
     XmlElement(GetType(String)), _
     XmlElement(GetType(DateTime))> _
    Public ExtraInfo As ArrayList
End Class

Public Class Employee
    Public Name As String
End Class

Public Class Manager
    Inherits Employee
    Public Level As Integer
End Class

Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("TypeEx.xml")
    End Sub    
    
    Public Sub SerializeObject(filename As String)
        ' Create an XmlSerializer instance.
        Dim xSer As New XmlSerializer(GetType(Group))
        
        ' Create an object and serialize it.
        Dim myGroup As New Group()
        
        Dim e1 As New Manager()
        e1.Name = "Manager1"
        Dim m1 As New Manager()
        m1.Name = "Manager2"
        m1.Level = 4
        
        Dim emps() As Employee = {e1, m1}
        myGroup.Staff = emps
        
        myGroup.ExtraInfo = New ArrayList()
        myGroup.ExtraInfo.Add(".NET")
        myGroup.ExtraInfo.Add(42)
        myGroup.ExtraInfo.Add(New DateTime(2001, 1, 1))
        
        Dim writer As New StreamWriter(filename)
        xSer.Serialize(writer, myGroup)
        writer.Close()
    End Sub
End Class

' </Snippet1>
