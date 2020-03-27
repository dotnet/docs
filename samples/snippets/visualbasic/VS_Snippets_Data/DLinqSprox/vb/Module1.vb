Imports System.Linq
Imports System.Data.Linq
Imports System.Data.Linq.Mapping

Module Module1

    Sub Main()

        ' <Snippet3>
        Dim db As New Northwnd("C:\...\northwnd.mdf")
        Dim totalSales As Decimal? = 0
        db.CustOrderTotal("alfki", totalSales)

        Console.WriteLine(totalSales)
        ' </Snippet3>

    End Sub

    Sub CallMultiple()

        ' <Snippet5>
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' Assign the results of the procedure with an argument
        ' of (1) to local variable 'result'.
        Dim result As IMultipleResults = db.VariableResultShapes(1)

        ' Iterate through the list and write results (the company name)
        ' to the console.
        For Each compName As VariableResultShapesResult1 _
            In result.GetResult(Of VariableResultShapesResult1)()
            Console.WriteLine(compName.CompanyName)
        Next

        ' Pause to view company names; press Enter to continue.
        Console.ReadLine()

        ' Assign the results of the procedure with an argument
        ' of (2) to local variable 'result.'
        Dim result2 As IMultipleResults = db.VariableResultShapes(2)

        ' Iterate through the list and write results (the order IDs)
        ' to the console.
        For Each ord As VariableResultShapesResult2 _
            In result2.GetResult(Of VariableResultShapesResult2)()
            Console.WriteLine(ord.OrderID)
        Next
        ' </Snippet5>

    End Sub

    Sub method7()
        ' <Snippet7>
        Dim db As New Northwnd("c:\northwnd.mdf")

        Dim sprocResults As IMultipleResults = _
            db.MultipleResultTypesSequentially

        ' First read products.
        For Each prod As Product In sprocResults.GetResult(Of Product)()
            Console.WriteLine(prod.ProductID)
        Next

        ' Next read customers.
        For Each cust As Customer In sprocResults.GetResult(Of Customer)()
            Console.WriteLine(cust.CustomerID)
        Next
        ' </Snippet7>

    End Sub
End Module
