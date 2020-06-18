Imports System.Linq
Imports System.Data.Linq
Imports System.Data.Common


Module Module1

    Sub Main()

        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet1>
        db.Log = Console.Out
        Dim custQuery = _
            From cust In db.Customers _
            Where cust.City = "London" _
            Select cust

        For Each custObj In custQuery
            Console.WriteLine(custObj.CustomerID)
        Next
        ' </Snippet1>

    End Sub



    Sub method2()
        ' <Snippet2>
        Dim db As New Northwnd("c:\northwnd.mdf")

        Dim custQuery = _
            From cust In db.Customers _
            Where (cust.City = "London") _
            Select cust

        For Each custObj As Customer In custQuery
            Console.WriteLine("CustomerID: {0}", custObj.CustomerID)
            Console.WriteLine(vbTab & "Original value: {0}", custObj.City)
            custObj.City = "Paris"
            Console.WriteLine(vbTab & "Updated value: {0}", custObj.City)
        Next

        Dim cs As ChangeSet = db.GetChangeSet()
        Console.Write("Total changes: {0}", cs)
        ' Freeze the console window.
        Console.ReadLine()

        db.SubmitChanges()
        ' </Snippet2>
    End Sub

    Sub method3()
        ' <Snippet3>
        ' Imports System.Data.Common

        Dim db As New Northwnd("c:\northwnd.mdf")

        Dim q = _
        From cust In db.Customers _
        Where cust.City = "London" _
        Select cust

        Console.WriteLine("Customers from London:")
        For Each z As Customer In q
            Console.WriteLine(vbTab & z.ContactName)
        Next

        Dim dc As DbCommand = db.GetCommand(q)
        Console.WriteLine(vbNewLine & "Command Text: " & vbNewLine & dc.CommandText)
        Console.WriteLine(vbNewLine & "Command Type: {0}", dc.CommandType)
        Console.WriteLine(vbNewLine & "Connection: {0}", dc.Connection)

        Console.ReadLine()
        ' </Snippet3>
    End Sub

End Module
