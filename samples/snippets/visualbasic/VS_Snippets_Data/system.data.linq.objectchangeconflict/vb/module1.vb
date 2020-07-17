Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Reflection

Module Module1

    Sub Main()
        ' <Snippet1>
        Dim db As New Northwnd("...")

        Try
            db.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As ChangeConflictException
            Console.WriteLine("Optimistic concurrency error.")
            Console.WriteLine(ex.Message)
            For Each occ As ObjectChangeConflict In db.ChangeConflicts
                Dim metatable As MetaTable = db.Mapping.GetTable(occ.Object.GetType())
                Dim entityInConflict = occ.Object

                Console.WriteLine("Table name: " & metatable.TableName)
                Console.Write("Customer ID: ")
                Console.WriteLine(entityInConflict.CustomerID)
                Console.ReadLine()
            Next
        End Try
        ' </Snippet1>




        Console.ReadLine()

    End Sub



End Module
