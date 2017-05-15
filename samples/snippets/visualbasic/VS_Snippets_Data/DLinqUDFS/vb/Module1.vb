Imports System.Linq


Module Module1

    Sub Main()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet2>
        Dim q = _
    From p In db.ProductsCostingMoreThan(80.5), p1 In db.Products _
    Where p.ProductID = p1.ProductID _
    Select p.ProductID, p1.UnitPrice
        ' </Snippet2>
    End Sub

    Sub method4()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet4>
        Dim str As String = db.ReverseCustName("LINQ to SQL")
        ' </Snippet4>
    End Sub

    Sub method5()
        Dim db As New Northwnd("c:\northwnd.mdf")
        ' <Snippet5>
        Dim custQuery = _
            From cust In db.Customers _
            Select cust.ContactName, Title = _
            db.ReverseCustName(cust.ContactTitle)
        ' </Snippet5>
    End Sub

End Module
