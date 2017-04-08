Imports System.Transactions


Module Module1

    Sub Main()

        Dim db As New Northwnd("")

        ' <Snippet1>
        db.Connection.Close()
        ' </Snippet1>

        ' <Snippet2>
        Using ts As New TransactionScope()
            db.SubmitChanges()
            ts.Complete()
        End Using
        ' </Snippet2>

        ' <Snippet3>
        Dim results As IEnumerable(Of Customer) = _
    db.ExecuteQuery(Of Customer)( _
    "SELECT [c1].custID as CustomerID," & _
        "[c2].custName as ContactName" & _
        "FROM customer1 AS [c1], customer2 as [c2]" & _
        "WHERE [c1].custid = [c2].custid")
        ' </Snippet3>



    End Sub

    Sub second()
        Dim db As New Northwnd("")

        ' <Snippet4>
        Dim results As IEnumerable(Of Customer) = _
    db.ExecuteQuery(Of Customer)( _
        "SELECT contactname FROM customers WHERE city = {0}, 'London'")
    End Sub
    ' </Snippet4>

End Module
