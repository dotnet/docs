' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml.Serialization


Public Class Group
    <XmlArray(IsNullable := True), _
     XmlArrayItem(GetType(Manager), IsNullable := False), _
     XmlArrayItem(GetType(Employee), IsNullable := False)> _
    Public Employees() As Employee
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
        test.SerializeObject("TypeDoc.xml")
    End Sub    
    
    Public Sub SerializeObject(filename As String)
        Dim s As New XmlSerializer(GetType(Group))
        
        ' To write the file, a TextWriter is required.
        Dim writer As New StreamWriter(filename)
        
        ' Creates the object to serialize.
        Dim group As New Group()
        
        ' Creates a null Manager object.
        Dim mgr As Manager = Nothing
        
        ' Creates a null Employee object.
        Dim y As Employee = Nothing
        
        group.Employees = New Employee() {mgr, y}
        
        ' Serializes the object and closes the TextWriter.
        s.Serialize(writer, group)
        writer.Close()
    End Sub
End Class

' </Snippet1>
