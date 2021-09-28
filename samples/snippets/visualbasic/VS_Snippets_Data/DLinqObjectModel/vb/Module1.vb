Imports System.Data.Linq
Imports System.Linq
Imports System.Data.Linq.Mapping
Imports System.Reflection



Module Module1

    Sub Main()

    End Sub

    ' <Snippet1>
    <Table(Name:="Customers")> _
    Public Class Customer
        Public CustomerID As String
        ' ...
        Public City As String
    End Class
    ' </Snippet1>

End Module

Module Module2

    ' <Snippet2>
    <Table(Name:="Customers")> _
    Public Class Customer
        <Column(IsPrimaryKey:=True)> _
        Public CustomerID As String

        <Column()> _
        Public City As String
    End Class
    ' </Snippet2>



End Module

