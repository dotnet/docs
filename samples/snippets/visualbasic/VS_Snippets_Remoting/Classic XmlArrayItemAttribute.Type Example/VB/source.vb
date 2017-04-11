' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization



Public Class Group
    ' The Type property instructs the XmlSerializer to accept both
    ' the Person and Manager types in the array. 
    <XmlArrayItem(Type := GetType(Manager)), _
     XmlArrayItem(Type := GetType(Person))> _
    Public Staff() As Person
        
End Class 'Group


Public Class Person
    Public Name As String
End Class 


Public Class Manager
    Inherits Person
    Public Rank As Integer
End Class 


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeOrder("TypeEx.xml")
    End Sub 
        
    
    Public Sub SerializeOrder(filename As String)
        ' Creates an XmlSerializer.
        Dim xSer As New XmlSerializer(GetType(Group))
        
        ' Creates the Group object, and two array items.
        Dim myGroup As New Group()
        
        Dim p1 As New Person()
        p1.Name = "Jacki"
        Dim p2 As New Manager()
        
        p2.Name = "Megan"
        p2.Rank = 2
        
        Dim myStaff() As Person =  {p1, p2}
        myGroup.Staff = myStaff
        
        ' Serializes the object, and closes the StreamWriter.
        Dim writer As New StreamWriter(filename)
        xSer.Serialize(writer, myGroup)
    End Sub 
End Class 'Run
' </Snippet1>
