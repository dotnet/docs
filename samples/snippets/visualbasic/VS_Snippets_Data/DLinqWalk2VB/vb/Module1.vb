Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Windows.Forms


Module Module1

    Sub Main()

        ' Use a connection string.
        Dim db As New DataContext _
            ("c:\linqtest\northwnd.mdf")

        ' Get a typed table to run queries.
        Dim Customers As Table(Of Customer) = _
            db.GetTable(Of Customer)()



        ' <Snippet3>
        ' Query for customers who have no orders.
        Dim custQuery = _
            From cust In Customers _
            Where Not cust.Orders.Any() _
            Select cust

        Dim msg As String = "", title As String = _
            "Customers With No Orders", response As MsgBoxResult, _
            style As MsgBoxStyle = MsgBoxStyle.Information

        For Each custObj In custQuery
            msg &= String.Format(custObj.CustomerID & vbCrLf)
        Next
        response = MsgBox(msg, style, title)
        ' </Snippet3>

    End Sub

    Sub method5()
        ' <Snippet5>
        ' Use a connection string.
        Dim db As New Northwind _
            ("C:\linqtest\northwnd.mdf")

        ' Query for customers from Seattle.
        Dim custs = _
            From cust In db.Customers _
            Where cust.City = "Seattle" _
            Select cust

        For Each custObj In custs
            Console.WriteLine("ID=" & custObj.CustomerID)
        Next

        ' Freeze the console window.
        Console.ReadLine()
        ' </Snippet5>

    End Sub


End Module

' <Snippet4>
Public Class Northwind
    Inherits DataContext
    ' Table(Of T) abstracts database details  per
    ' table/data type.
    Public Customers As Table(Of Customer)
    Public Orders As Table(Of Order)

    Public Sub New(ByVal connection As String)
        MyBase.New(connection)
    End Sub
End Class
' </Snippet4>



' <Snippet1>
<Table(Name:="Orders")> _
Public Class Order
    Private _OrderID As Integer
    Private _CustomerID As String
    Private _Customers As EntityRef(Of Customer)

    Public Sub New()
        Me._Customers = New EntityRef(Of Customer)()
    End Sub

    <Column(Storage:="_OrderID", DbType:="Int NOT NULL IDENTITY", _
        IsPrimaryKey:=True, IsDBGenerated:=True)> _
    Public ReadOnly Property OrderID() As Integer
        Get
            Return Me._OrderID
        End Get
    End Property
    ' No need to specify a setter because IsDBGenerated is true.

    <Column(Storage:="_CustomerID", DbType:="NChar(5)")> _
    Public Property CustomerID() As String
        Get
            Return Me._CustomerID
        End Get
        Set(ByVal value As String)
            Me._CustomerID = value
        End Set
    End Property

    <Association(Storage:="_Customers", ThisKey:="CustomerID")> _
    Public Property Customers() As Customer
        Get
            Return Me._Customers.Entity
        End Get
        Set(ByVal value As Customer)
            Me._Customers.Entity = value
        End Set
    End Property
End Class
' </Snippet1>


<Table(Name:="Customers")> _
Public Class Customer

    ' <Snippet2>
    Private _Orders As EntitySet(Of Order)

    Public Sub New()
        Me._Orders = New EntitySet(Of Order)()
    End Sub

    <Association(Storage:="_Orders", OtherKey:="CustomerID")> _
    Public Property Orders() As EntitySet(Of Order)
        Get
            Return Me._Orders
        End Get
        Set(ByVal value As EntitySet(Of Order))
            Me._Orders.Assign(value)
        End Set
    End Property
    ' </Snippet2>




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

End Class
