'Imports ArraysAndListsInQueries_VB.AdventureWorksModel
Module Module1

    Sub Main()
        A()
        B()
        C()
        D()
    End Sub

    Public Sub A()
        '<snippet1> 
        Using AWEntities As New AdventureWorksEntities()
            Dim productModelIds As System.Nullable(Of Integer)() = {19, 26, 118}
            Dim products = From p In AWEntities.Products _
                Where productModelIds.Contains(p.ProductModelID) _
                Select p
            For Each product In products
                Console.WriteLine("{0}: {1}", product.ProductModelID, product.ProductID)
            Next
        End Using
        '</snippet1> 
    End Sub

    Public Sub B()
        '<snippet2> 
        Using AWEntities As New AdventureWorksEntities()
            Dim products = From p In AWEntities.Products _
                Where (New System.Nullable(Of Integer)() {19, 26, 18}).Contains(p.ProductModelID) _
                OrElse (New String() {"L", "XL"}).Contains(p.Size) _
                Select p
            For Each product In products
                Console.WriteLine("{0}: {1}, {2}", product.ProductID, _
                                                   product.ProductModelID, _
                                                   product.Size)
            Next
        End Using
        '</snippet2> 
    End Sub

    Public Sub C()
        '<snippet3> 
        Using AWEntities As New AdventureWorksEntities()
            Dim productModelIds As System.Nullable(Of Integer)() = {19, 26, 118}
            Dim products = AWEntities.Products. _
                Where(Function(p) productModelIds.Contains(p.ProductModelID))
            For Each product In products
                Console.WriteLine("{0}: {1}", product.ProductModelID, product.ProductID)
            Next
        End Using
        '</snippet3> 
    End Sub

    Public Sub D()
        '<snippet4> 
        Using AWEntities As New AdventureWorksEntities()
            Dim products = AWEntities.Products. _
                Where(Function(p) (New System.Nullable(Of Integer)() {19, 26, 18}). _
                                   Contains(p.ProductModelID) _
                      OrElse _
                                  (New String() {"L", "XL"}).Contains(p.Size))

            For Each product In products
                Console.WriteLine("{0}: {1}, {2}", product.ProductID, _
                                                   product.ProductModelID, _
                                                   product.Size)
            Next
        End Using
        '</snippet4> 
    End Sub
End Module
