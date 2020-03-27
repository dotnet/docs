Module Module1

    Sub Main()
        '<snippet1>
        Dim context As New NorthwindDataContext()

        ' This query does not retrieve an object from
        ' the query cache because it is the first query.
        ' There are no objects in the cache. 
        Dim a = context.Customers.First()
        Console.WriteLine("First query gets customer {0}. ", a.CustomerID)

        ' This query returns an object from the query cache.
        Dim b = context.Customers.Where(Function(c) c.CustomerID = a.CustomerID)
        For Each customer In b
            Console.WriteLine(customer.CustomerID)
        Next

        ' This query returns an object from the identity cache.
        ' Note that calling FirstOrDefault(), Single(), or SingleOrDefault()
        ' instead of First() will also return an object from the cache.
        Dim x = context.Customers. _
            Where(Function(c) c.CustomerID = a.CustomerID). _
            First()
        Console.WriteLine(x.CustomerID)

        ' This query returns an object from the identity cache.
        ' Note that calling FirstOrDefault(), Single(), or SingleOrDefault()
        ' instead of First() (each with the same predicate) will also
        ' return an object from the cache.
        Dim y = context.Customers.First(Function(c) c.CustomerID = a.CustomerID)
        Console.WriteLine(y.CustomerID)
        '</snippet1>

        '<snippet3>
        Dim z = context.Customers. _
            Where(Function(c) c.CustomerID = a.CustomerID). _
            MyFirst()
        Console.WriteLine(z.CustomerID)
        '</snippet3>
    End Sub

End Module

'<snippet2>
Module MyQueryable
    <System.Runtime.CompilerServices.Extension()> _
    Public Function MyFirst(Of TSource)(ByVal source _
                                        As IQueryable(Of TSource)) _
                                        As TSource
        Return source.First()
    End Function
End Module
'</snippet2>
