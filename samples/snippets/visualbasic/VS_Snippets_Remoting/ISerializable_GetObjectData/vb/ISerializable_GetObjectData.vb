'<snippet0>
Imports System
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports System.IO

<Assembly: SecurityPermission _
(SecurityAction.RequestMinimum, Execution:=True)> 

Class Program

    Public Shared Sub Main()
        Try
            Run()
        Catch exc As Exception
            Console.WriteLine("{0}: {1}", exc.Message, exc.StackTrace)
        Finally
            Console.WriteLine("Press Enter to exit....")
            Console.ReadLine()
        End Try

    End Sub

    Shared Sub Run()
        Dim binaryFmt As New BinaryFormatter()
        Dim p As New Person()
        p.IdNumber = 1010
        p.Name = "AAAAA"
        Dim fs As New FileStream("Person.xml", FileMode.OpenOrCreate)
        binaryFmt.Serialize(fs, p)
        fs.Close()
        Console.WriteLine _
        ("Original Name: {0}, Original ID: {1}", p.Name, p.IdNumber)

        ' Deserialize.
        fs = New FileStream("Person.xml", FileMode.OpenOrCreate)
        Dim p2 As Person = CType(binaryFmt.Deserialize(fs), Person)
        Console.WriteLine("New Name: {0}, New ID: {1}", _
        p2.Name, p2.IdNumber)
        fs.Close()
    End Sub
End Class

<Serializable()> _
Public Class Person
    Implements ISerializable
    Private name_value As String
    Private ID_value As Integer

    Public Sub New()

    End Sub

    Protected Sub New(ByVal info As SerializationInfo, _
    ByVal context As StreamingContext)
        If info Is Nothing Then
            Throw New System.ArgumentNullException("info")
        End If
        name_value = CStr(info.GetValue("AltName", GetType(String)))
        ID_value = Fix(info.GetValue("AltID", GetType(Integer)))

    End Sub

    <SecurityPermission(SecurityAction.LinkDemand, _
    Flags:=SecurityPermissionFlag.SerializationFormatter)> _
    Public Overridable Sub GetObjectData _
    (ByVal info As SerializationInfo, _
    ByVal context As StreamingContext) _
    Implements ISerializable.GetObjectData
        If info Is Nothing Then
            Throw New System.ArgumentNullException("info")
        End If
        info.AddValue("AltName", "XXX")
        info.AddValue("AltID", 9999)

    End Sub

    Public Property Name() As String
        Get
            Return name_value
        End Get
        Set(ByVal value As String)
            name_value = value
        End Set
    End Property

    Public Property IdNumber() As Integer
        Get
            Return ID_value
        End Get
        Set(ByVal value As Integer)
            ID_value = value
        End Set
    End Property
End Class
'</snippet0>