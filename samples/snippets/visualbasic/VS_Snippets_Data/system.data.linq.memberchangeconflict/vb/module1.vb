Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Reflection

Module Module1

    Sub Main()

        ' <Snippet1>
        ' Add 'Imports System.Reflection' for this section.
        Dim db As New Northwnd("...")
        '...
        Try
            db.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As ChangeConflictException
            Console.WriteLine("Optimistic concurrency error.")
            Console.WriteLine(ex.Message)
            For Each occ As ObjectChangeConflict In db.ChangeConflicts
                Dim metatable As MetaTable = db.Mapping.GetTable(occ.Object.GetType)
                Dim entityInConflict As Object = occ.Object

                Console.WriteLine("Table name: " & metatable.TableName)
                Console.Write("Customer ID: ")
                Console.WriteLine(entityInConflict.CustomerID)

                For Each mcc As MemberChangeConflict In occ.MemberConflicts
                    Dim currVal = mcc.CurrentValue
                    Dim origVal = mcc.OriginalValue
                    Dim databaseVal = mcc.DatabaseValue
                    Dim mi As MemberInfo = mcc.Member

                    Console.WriteLine("Member: " & mi.Name)
                    Console.WriteLine("current value: " & currVal)
                    Console.WriteLine("original value: " & origVal)
                    Console.WriteLine("database value: " & databaseVal)
                    Console.ReadLine()
                Next
            Next
        End Try
        ' </Snippet1>


        Console.ReadLine()

    End Sub



End Module
