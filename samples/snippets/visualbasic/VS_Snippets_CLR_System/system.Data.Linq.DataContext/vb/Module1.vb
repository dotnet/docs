Imports System.Linq

Module Module1

    Sub Main()
        Dim db As New Northwnd("c:\northwnd.mdf")


        ' <Snippet1>
        If Not db.DatabaseExists Then
            db.CreateDatabase()
        End If
        ' ...
        db.DeleteDatabase()
        ' </Snippet1>

    End Sub

    Sub method2()

        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet2>
        db.Log = Console.Out
        Dim custQuery = _
        From cust In db.Customers _
        Where cust.City = "London" _
        Select cust

        For Each custObj In custQuery
            Console.WriteLine(custObj.ContactName)
        Next
        ' </Snippet2>

    End Sub

End Module
