Imports System.Data.Linq
Imports System.Data.Linq.Mapping


Module Module1

    Sub Main()

    End Sub

End Module


' <Snippet1>
<Table(Name:="Customers")> _
Public Class Customer
    ' ...
End Class
' </Snippet1>

Namespace ns


    ' <Snippet2>
    <Table(Name:="Customers")> _
    Public Class Customer
        <Column(Name:="CustomerID")> _
        Public CustomerID As String
        ' ...
    End Class
    ' </Snippet2>

End Namespace

Namespace ns2

    'Public Class Order

    'End Class

    ' <Snippet3>
    <Table(Name:="Customers")> _
    Public Class Customer
        <Column(IsPrimaryKey:=True)> _
    Public CustomerID As String
        ' ...
        Private _Orders As EntitySet(Of Order)
        <Association(Storage:="_Orders", OtherKey:="CustomerID")> _
        Public Property Orders() As EntitySet(Of Order)
            Get
                Return Me._Orders
            End Get
            Set(ByVal value As EntitySet(Of Order))
                Me._Orders.Assign(value)
            End Set
        End Property
    End Class
    ' </Snippet3>

    ' <Snippet4>
    <Table()> _
    <InheritanceMapping(Code:="C", Type:=GetType(Car))> _
    <InheritanceMapping(Code:="T", Type:=GetType(Truck))> _
    <InheritanceMapping(Code:="V", Type:=GetType(Vehicle), _
        IsDefault:=True)> _
    Public Class Vehicle
        <Column(IsDiscriminator:=True)> _
            Private DiscKey As String
        <Column(IsPrimaryKey:=True)> _
            Private VIN As String
        <Column()> _
            Private MfgPlant As String
    End Class

    Public Class Car
        Inherits Vehicle
        <Column()> _
            Private TrimCode As Integer
        <Column()> _
            Private ModelName As String
    End Class

    Public Class Truck
        Inherits Vehicle
        <Column()> _
            Private Tonnage As Integer
        <Column()> _
            Private Axles As Integer
    End Class
    ' </Snippet4>

    ' <Snippet5>
    <Table(Name:="Orders")> _
    Public Class Order
        <Column(IsPrimaryKey:=True)> _
        Public OrderID As Integer
        <Column()> _
        Public CustomerID As String
        Private _Customer As EntityRef(Of Customer)
        <Association(Storage:="Customer", ThisKey:="CustomerID")> _
        Public Property Customer() As Customer
            Get
                Return Me._Customer.Entity
            End Get
            Set(ByVal value As Customer)
                Me._Customer.Entity = value
            End Set
        End Property
    End Class
    ' </Snippet5>


End Namespace