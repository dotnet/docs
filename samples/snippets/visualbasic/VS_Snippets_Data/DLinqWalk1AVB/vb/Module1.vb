Imports System.Data.Linq
Imports System.Data.Linq.Mapping


Module Module1

    Sub Main()
        ' Use a connection string.
        Dim db As New DataContext _
            ("c:\linqtest\northwnd.mdf")

        ' Get a typed table to run queries.
        Dim Customers As Table(Of Customer) = _
            db.GetTable(Of Customer)()

        ' <Snippet5>
        ' Attach the log to show generated SQL in a console window.
        db.Log = Console.Out

        ' Query for customers in London.
        Dim custQuery = _
            From cust In Customers _
            Where cust.City = "London" _
            Select cust
        ' </Snippet5>

        ' <Snippet6>
        ' Format the message box.
        Dim msg As String = "", title As String = "London customers:", _
            response As MsgBoxResult, style As MsgBoxStyle = _
            MsgBoxStyle.Information

        ' Execute the query.
        For Each custObj In custQuery
            msg &= String.Format(custObj.CustomerID & vbCrLf)
        Next

        ' Display the results.
        response = MsgBox(msg, style, title)
        ' </Snippet6>


    End Sub

End Module


<Table(Name:="Customers")> _
Public Class Customer

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
