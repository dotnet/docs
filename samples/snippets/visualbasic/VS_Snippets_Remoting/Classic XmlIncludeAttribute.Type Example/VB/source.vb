Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic


Public Class Group
    Public Employees() As Employee
End Class

' Instruct the XmlSerializer to accept Manager types as well.
<XmlInclude(GetType(Manager))> _
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
        test.SerializeObject("IncludeExample.xml")
        test.DeserializeObject("IncludeExample.xml")
    End Sub    
    
    
    Public Sub SerializeObject(ByVal filename As String)
        Dim s As New XmlSerializer(GetType(Group))
        Dim writer As New StreamWriter(filename)
        Dim group As New Group()
        
        Dim manager As New Manager()
        Dim emp1 As New Employee()
        Dim emp2 As New Employee()
        
        manager.Name = "Zeus"
        manager.Level = 2
        
        emp1.Name = "Ares"
        
        emp2.Name = "Artemis"
        
        Dim emps() As Employee = {manager, emp1, emp2}
        group.Employees = emps
        
        s.Serialize(writer, group)
        writer.Close()
    End Sub    
    
    Public Sub DeserializeObject(ByVal filename As String)
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim x As New XmlSerializer(GetType(Group))
        Dim g As Group = CType(x.Deserialize(fs), Group)
        Console.Write("Members:")
        
        Dim e As Employee
        For Each e In  g.Employees
            Console.WriteLine(ControlChars.Tab + e.Name)
        Next e
    End Sub
End Class

' </Snippet1>
