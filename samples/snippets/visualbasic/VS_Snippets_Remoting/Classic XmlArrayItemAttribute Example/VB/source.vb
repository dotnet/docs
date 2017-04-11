' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic


Public Class Group
    ' The XmlArrayItemAttribute allows the XmlSerializer to insert
    ' both the base type (Employee) and derived type (Manager)
    ' into serialized arrays. 
    
    <XmlArrayItem(GetType(Manager)), _
     XmlArrayItem(GetType(Employee))> _
    Public Employees() As Employee
    
    ' Use the XmlArrayItemAttribute to specify types allowed
    ' in an array of Object items. 
    <XmlArray(), _
     XmlArrayItem(GetType(Integer), ElementName := "MyNumber"), _
     XmlArrayItem(GetType(String), ElementName := "MyString"), _
     XmlArrayItem(GetType(Manager))> _
    Public ExtraInfo() As Object
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
        test.DeserializeObject("TypeDoc.xml")
    End Sub
    
       
    Public Sub SerializeObject(ByVal filename As String)
        ' Creates a new XmlSerializer.
        Dim s As New XmlSerializer(GetType(Group))
        
        ' Writing the XML file to disk requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        Dim group As New Group()
        
        Dim manager As New Manager()
        Dim emp1 As New Employee()
        Dim emp2 As New Employee()
        manager.Name = "Consuela"
        manager.Level = 3
        emp1.Name = "Seiko"
        emp2.Name = "Martina"
        Dim emps() As Employee = {manager, emp1, emp2}
        group.Employees = emps
        
        ' Creates an int and a string and assigns to ExtraInfo.
        group.ExtraInfo = New Object() {43, "Extra", manager}
        
        ' Serializes the object, and closes the StreamWriter.
        s.Serialize(writer, group)
        writer.Close()
    End Sub
    
    
    Public Sub DeserializeObject(ByVal filename As String)
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim x As New XmlSerializer(GetType(Group))
        Dim g As Group = CType(x.Deserialize(fs), Group)
        Console.WriteLine("Members:")
        
        Dim e As Employee
        For Each e In  g.Employees
            Console.WriteLine(ControlChars.Tab & e.Name)
        Next e
    End Sub
End Class

' </Snippet1>
