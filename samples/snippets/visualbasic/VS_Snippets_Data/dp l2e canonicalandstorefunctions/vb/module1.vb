Imports System.Linq
Imports System.Data.Objects
Imports System.Data.Objects.SqlClient

Module Module1

    Sub Main()
        A()
        B()
        C1()
        D()
    End Sub

    Public Function A()
        '<snippet1>
        Using AWEntities As New AdventureWorksEntities()
            Dim products = From p In AWEntities.Products _
                           Where EntityFunctions.DiffDays(p.SellEndDate, p.SellStartDate) < 365 _
                           Select p

            For Each product In products
                Console.WriteLine(product.ProductID)
            Next
        End Using
        '</snippet1>
    End Function

    Public Function B()
        '<snippet2>
        Using AWEntities As New AdventureWorksEntities()
            Dim stdDev As Double? = EntityFunctions.StandardDeviation( _
                From o In AWEntities.SalesOrderHeaders _
                Select o.SubTotal)

            Console.WriteLine(stdDev)
        End Using
        '</snippet2>
    End Function

    Public Function C1()
        '<snippet3>
        Using AWEntities As New AdventureWorksEntities()

            ' SqlFunctions.CharIndex is executed in the database.
            Dim contacts = From c In AWEntities.Contacts _
                           Where SqlFunctions.CharIndex("Si", c.LastName) = 1 _
                           Select c

            For Each contact In contacts
                Console.WriteLine(contact.LastName)
            Next
        End Using
        '</snippet3>
    End Function

    Public Function D()
        '<snippet4>
        Using AWEntities As New AdventureWorksEntities()

            ' SqlFunctions.ChecksumAggregate is executed in the database.
            Dim checkSum As Integer = SqlFunctions.ChecksumAggregate( _
                From o In AWEntities.SalesOrderHeaders _
                Select o.SalesOrderID)

            Console.WriteLine(checkSum)
        End Using
        '</snippet4>
    End Function
End Module
