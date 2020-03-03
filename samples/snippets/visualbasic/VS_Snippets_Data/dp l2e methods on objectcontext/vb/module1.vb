Imports System.Data.Objects
Imports System.Data.Objects.DataClasses

Module Module1

    Sub Main()
        A()
        C()
    End Sub

    Public Function A()
        '<snippet3> 
        Using AWEntities As New AdventureWorksEntities()

            Dim productId As Integer = 776

            Dim details = From s In AWEntities.SalesOrderDetails _
                Where s.ProductID = productId _
                Select s

            Console.WriteLine(AWEntities.GetProductRevenue(details))
        End Using
        '</snippet3> 
    End Function

    Public Sub C()
        '<snippet6> 
        Using AWEntities As New AdventureWorksEntities()
            Dim productId As Integer = 776

            Dim details = From s In AWEntities.SalesOrderDetails _
                Where s.ProductID = productId _
                Select s

            Console.WriteLine([MyClass].GetProductRevenue(details))
        End Using
        '</snippet6> 
    End Sub

    Public Sub D()
        '<snippet9>
        Using AWEntities As New AdventureWorksEntities()
            Dim productId As Integer = 776

            Dim lineTotals = AWEntities.GetDetailsById(productId).[Select](Function(d) d.LineTotal)

            For Each lineTotal In lineTotals
                Console.WriteLine(lineTotal)
            Next
            '</snippet9>
        End Using
    End Sub
End Module

