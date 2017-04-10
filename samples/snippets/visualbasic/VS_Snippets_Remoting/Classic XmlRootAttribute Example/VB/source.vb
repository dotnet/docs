' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

<XmlRoot(Namespace:="www.contoso.com", _
    ElementName:="MyGroupName", _
    DataType:="string", _
    IsNullable:=True)> _
Public Class Group

    Private groupNameValue As String
    ' Insert code for the Group class.
    Public Sub New()

    End Sub

    Public Sub New(ByVal groupNameVal As String)

        groupNameValue = groupNameVal
    End Sub

    Property GroupName() As String
        Get
            Return groupNameValue
        End Get

        Set(ByVal Value As String)
            groupNameValue = Value
        End Set
    End Property
End Class

Public Class Test

    Shared Sub Main()

        Dim t As Test = New Test()
        t.SerializeGroup()
    End Sub

    Private Sub SerializeGroup()

        ' Create an instance of the Group class, and an
        ' instance of the XmlSerializer to serialize it.
        Dim myGroup As Group = New Group("Redmond")
        Dim ser As XmlSerializer = New XmlSerializer(GetType(Group))

        ' A FileStream is used to write the file.
        Dim fs As FileStream = New FileStream("group.xml", FileMode.Create)
        ser.Serialize(fs, myGroup)
        fs.Close()
        Console.WriteLine(myGroup.GroupName)
        Console.WriteLine("Done... Press any key to exit.")
        Console.ReadLine()
    End Sub

End Class
' </Snippet1>



