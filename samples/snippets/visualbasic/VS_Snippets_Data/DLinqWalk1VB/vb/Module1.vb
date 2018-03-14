' <Snippet1>
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Windows.Forms
' </Snippet1>


Module Module1

    Sub Main()

        ' <Snippet4>
        ' Use a connection string.
        Dim db As New DataContext _
            ("c:\linqtest\northwnd.mdf")

        ' Get a typed table to run queries.
        Dim Customers As Table(Of Customer) = _
            db.GetTable(Of Customer)()
        ' </Snippet4>

    End Sub

End Module

' <Snippet2>
<Table(Name:="Customers")> _
Public Class Customer
End Class
' </Snippet2>

Public Class Snippet3
    ' <Snippet3>
    Private _CustomerID As String
    <Column(IsPrimaryKey:=True, Storage:="_CustomerID")> _
    Public Property CustomerID() As String
        Get
            Return Me._CustomerID
        End Get
        Set(ByVal value As String)
            Me._CustomerID = value
        End Set
    End Property

    Private _City As String
    <Column(Storage:="_City")> _
    Public Property City() As String
        Get
            Return Me._City
        End Get
        Set(ByVal value As String)
            Me._City = value
        End Set
    End Property
    ' </Snippet3>

End Class

