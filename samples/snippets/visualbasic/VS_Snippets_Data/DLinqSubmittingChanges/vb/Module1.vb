Imports System.Data.Linq
Imports System.Transactions
Imports System.Data.Linq.Mapping
Imports System.Reflection
Imports System.Linq


Module Module1

    Sub Main()

        ' <Snippet2>
        ' Imports System.Reflection

        Dim newCust As New Customer()
        newCust.City = "Auburn"
        newCust.CustomerID = "AUBUR"
        newCust.CompanyName = "AubCo"
        db.Customers.InsertOnSubmit(newCust)

        Try
            db.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch e As ChangeConflictException
            Console.WriteLine("Optimistic concurrency error.")
            Console.WriteLine(e.Message)
            Console.ReadLine()
            For Each occ In db.ChangeConflicts

                Dim metatable As MetaTable = db.Mapping.GetTable(occ.Object.GetType())
                Dim entityInConflict = CType(occ.Object, Customer)
                Console.WriteLine("Table name: {0}", metatable.TableName)
                Console.Write("Customer ID: ")
                Console.WriteLine(entityInConflict.CustomerID)
                For Each mcc In occ.MemberConflicts

                    Dim currVal = mcc.CurrentValue
                    Dim origVal = mcc.OriginalValue
                    Dim databaseVal = mcc.DatabaseValue
                    Dim mi = mcc.Member
                    Console.WriteLine("Member: {0}", mi.Name)
                    Console.WriteLine("current value: {0}", currVal)
                    Console.WriteLine("original value: {0}", origVal)
                    Console.WriteLine("database value: {0}", databaseVal)
                Next
            Next

        Catch ee As Exception
            ' Catch other exceptions.
            Console.WriteLine(ee.Message)
        Finally
            Console.WriteLine("TryCatch block has finished.")
        End Try
        ' </Snippet2>

    End Sub


    ' <Snippet1>
    Dim db As New Northwnd("c:\northwnd.mdf")

    ' Make changes here.
    Sub MakeChanges()
        Try
            db.SubmitChanges()
        Catch e As ChangeConflictException
            Console.WriteLine(e.Message)
            ' Make some adjustments 
            '...
            ' Try again.
            db.SubmitChanges()
        End Try
    End Sub
    ' </Snippet1>

    Sub method2()
        ' this will be s2
    End Sub

    Sub method3()
        ' <Snippet3>
        Dim db As New Northwnd("c:\northwnd.mdf")
        Using ts = New TransactionScope()
            Try

                Dim prod1 = db.Products.First(Function(p) p.ProductID = 4)
                Dim prod2 = db.Products.First(Function(p) p.ProductID = 5)
                prod1.UnitsInStock -= 3
                prod2.UnitsInStock -= 5
                db.SubmitChanges()
                ts.Complete()

            Catch e As Exception
                Console.WriteLine(e.Message)
            End Try
        End Using
        ' </Snippet3>

    End Sub

    ' <Snippet6>
    Public Sub CreateDatabase()
        Dim db As New MyDVDs("c:\...\mydvds.mdf")
        db.CreateDatabase()
    End Sub
    ' </Snippet6>

    ' <Snippet7>
    Public Sub CreateDatabase2()
        Dim db As MyDVDs = New MyDVDs("c:\...\mydvds.mdf")
        If db.DatabaseExists() Then
            Console.WriteLine("Deleting old database...")
            db.DeleteDatabase()
        End If
        db.CreateDatabase()
    End Sub
    ' </Snippet7>


End Module


' <Snippet4>
' Code-generating tool defines a partial class, including 
' two partial methods. 
Partial Class ExampleClass
    Partial Private Sub OnFindingMaxOutput()
    End Sub

    Partial Private Sub OnFindingMinOutput()
    End Sub

    Sub ExportResults()
        OnFindingMaxOutput()
        OnFindingMinOutput()
    End Sub
End Class

' Developer implements one of the partial methods. Compiler
' discards the other method.
Class ExampleClass
    Private Sub OnFindingMaxOutput()
        Console.WriteLine("Maximum has been found.")
    End Sub
End Class
' </Snippet4>

' <Snippet5>
Public Class MyDVDs
    Inherits DataContext
    Public DVDs As Table(Of DVD)
    Public Sub New(ByVal connection As String)
        MyBase.New(connection)
    End Sub
End Class

<Table(Name:="DVDTable")> _
Public Class DVD
    <Column(IsPrimaryKey:=True)> _
    Public Title As String
    <Column()> _
    Public Rating As String
End Class
' </Snippet5>
