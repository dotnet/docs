Imports System.Data.Linq
Imports System.Data.Linq.SqlClient
Imports System.Reflection
Imports System.Data.Linq.Mapping
Imports System.Data.SqlClient
Imports System.Linq


Module Module1

    Sub Main()

        '        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet1>
        ' DataContext takes a connection string.
        Dim db As New DataContext("…\Northwind.mdf")

        ' Get a typed table to run queries.
        Dim Customers As Table(Of Customer) = db.GetTable(Of Customer)()

        ' Query for customer from London.
        Dim Query = _
            From cust In Customers _
            Where cust.City = "London" _
            Select cust

        For Each cust In Query
            Console.WriteLine("id=" & cust.CustomerID & _
                ", City=" & cust.City)
        Next
        ' </Snippet1>



        Console.ReadLine()

    End Sub

    ' <Snippet2>
    Partial Public Class Northwind
        Inherits DataContext
        Public Customers As Table(Of Customer)
        Public Orders As Table(Of Order)
        Public Sub New(ByVal connection As String)
            MyBase.New(connection)
        End Sub
    End Class
    ' </Snippet2>

    Sub NextSnippet()
        Dim db As New DataContext("…\Northwnd.mdf")
        ' <Snippet3>
        db.ExecuteCommand _
    ("UPDATE Products SET UnitPrice = UnitPrice + 1.00")
        ' </Snippet3>
    End Sub

    Sub thirdsnippet()
        ' <Snippet4>
        Dim conString = "Data Source=.\SQLEXPRESS;AttachDbFilename=c:\northwind.mdf; Integrated Security=True;Connect Timeout=30;User Instance=True"
        Dim northwindCon = New SqlConnection(conString)
        northwindCon.Open()

        Dim db = New Northwnd("...")
        Dim northwindTransaction = northwindCon.BeginTransaction()

        Try
            Dim cmd = New SqlCommand( _
                    "UPDATE Products SET QuantityPerUnit = 'single item' " & _
                    "WHERE ProductID = 3")
            cmd.Connection = northwindCon
            cmd.Transaction = northwindTransaction
            cmd.ExecuteNonQuery()

            db.Transaction = northwindTransaction

            Dim prod1 = (From prod In db.Products _
                         Where prod.ProductID = 4).First
            Dim prod2 = (From prod In db.Products _
                         Where prod.ProductID = 5).First
            prod1.UnitsInStock -= 3
            prod2.UnitsInStock -= 5

            db.SubmitChanges()

            northwindTransaction.Commit()

        Catch e As Exception

            Console.WriteLine(e.Message)
            Console.WriteLine("Error submitting changes... " & _
        "all changes rolled back.")
        End Try

        northwindCon.Close()
        ' </Snippet4>
    End Sub

    Sub other()
        ' <Snippet5>
        Dim db As New Northwind("...\Northwnd.mdf")

        Dim query = _
            From cust In db.Customers _
            Where cust.City = "London" _
            Select cust

        For Each cust In query
            Console.WriteLine("id=" & cust.CustomerID & _
                ", City=" & cust.City)
        Next
        ' </Snippet5>

    End Sub

End Module
