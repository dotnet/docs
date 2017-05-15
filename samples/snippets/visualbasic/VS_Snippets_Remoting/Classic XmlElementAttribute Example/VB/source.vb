Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.Collections
Imports System.IO
Imports System.Xml.Serialization


Public Class Group
    ' Set the element name and namespace of the XML element.
    <XmlElement(ElementName := "Members", _
     Namespace := "http://www.cpandl.com")> _    
    Public Employees() As Employee
    
    <XmlElement(DataType := "double", _
     ElementName := "Building")> _
    Public GroupID As Double
    
    <XmlElement(DataType := "hexBinary")> _
    Public HexBytes() As Byte
    
    <XmlElement(DataType := "boolean")> _
    Public IsActive As Boolean
    
    <XmlElement(GetType(Manager))> _
    Public Manager As Employee
    
    <XmlElement(GetType(Integer), _
        ElementName := "ObjectNumber"), _
     XmlElement(GetType(String), _
        ElementName := "ObjectString")> _
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
        test.SerializeObject("FirstDoc.xml")
        test.DeserializeObject("FirstDoc.xml")
    End Sub
    
    Public Sub SerializeObject(filename As String)
        ' Create the XmlSerializer.
        Dim s As New XmlSerializer(GetType(Group))
        
        ' To write the file, a TextWriter is required.
        Dim writer As New StreamWriter(filename)
        
        ' Create an instance of the group to serialize, and set
        ' its properties. 
        Dim group As New Group()
        group.GroupID = 10.089f
        group.IsActive = False
        
        group.HexBytes = New Byte() {Convert.ToByte(100)}
        
        Dim x As New Employee()
        Dim y As New Employee()
        
        x.Name = "Jack"
        y.Name = "Jill"
        
        group.Employees = New Employee() {x, y}
        
        Dim mgr As New Manager()
        mgr.Name = "Sara"
        mgr.Level = 4
        group.Manager = mgr
        
        ' Add a number and a string to the
        ' ArrayList returned by the ExtraInfo property. 
        group.ExtraInfo = New ArrayList()
        group.ExtraInfo.Add(42)
        group.ExtraInfo.Add("Answer")
        
        ' Serialize the object, and close the TextWriter.      
        s.Serialize(writer, group)
        writer.Close()
    End Sub    
    
    Public Sub DeserializeObject(filename As String)
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim x As New XmlSerializer(GetType(Group))
        Dim g As Group = CType(x.Deserialize(fs), Group)
        Console.WriteLine(g.Manager.Name)
        Console.WriteLine(g.GroupID)
        Console.WriteLine(g.HexBytes(0))

        Dim e As Employee
        For Each e In g.Employees
            Console.WriteLine(e.Name)
        Next e
    End Sub
End Class

' </Snippet1>
