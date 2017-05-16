Imports System
Imports System.Collections.Generic
Imports System.LINQ

'<Snippet1>
Public Class Product
    Public Property Name As String
    Public Property Code As Integer
End Class

' Custom comparer for the Product class
Public Class ProductComparer
    Implements IEqualityComparer(Of Product)

    Public Function Equals1(
        ByVal x As Product, 
        ByVal y As Product
        ) As Boolean Implements IEqualityComparer(Of Product).Equals

        ' Check whether the compared objects reference the same data.
        If x Is y Then Return True

        'Check whether any of the compared objects is null.
        If x Is Nothing OrElse y Is Nothing Then Return False

        ' Check whether the products' properties are equal.
        Return (x.Code = y.Code) AndAlso (x.Name = y.Name)
    End Function

    Public Function GetHashCode1(
        ByVal product As Product
        ) As Integer Implements IEqualityComparer(Of Product).GetHashCode

        ' Check whether the object is null.
        If product Is Nothing Then Return 0

        ' Get hash code for the Name field if it is not null.
        Dim hashProductName = 
            If(product.Name Is Nothing, 0, product.Name.GetHashCode())

        ' Get hash code for the Code field.
        Dim hashProductCode = product.Code.GetHashCode()

        ' Calculate the hash code for the product.
        Return hashProductName Xor hashProductCode
    End Function
End Class
'</Snippet1>

Module Module1

    Sub Main()
        ' <Snippet2>
        Dim store1() As Product = 
            {New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "orange", .Code = 4}}

        Dim store2() As Product = 
            {New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "lemon", .Code = 12}}
        '</Snippet2>

        ' INTERSECT

        '<Snippet3>
        ' Get the products from the first array 
        ' that have duplicates in the second array.

        Dim duplicates = store1.Intersect(store2, New ProductComparer())

        For Each product In duplicates
            Console.WriteLine(product.Name & " " & product.Code)
        Next

        ' This code produces the following output:
        '
        ' apple 9
        ' 
        ' </Snippet3>

        ' UNION

        ' <Snippet4>
        ' Get the products from the both arrays
        ' excluding duplicates.

        Dim union = store1.Union(store2, New ProductComparer())

        For Each product In union
            Console.WriteLine(product.Name & " " & product.Code)
        Next

        ' This code produces the following output:
        '
        ' apple 9
        ' orange 4
        ' lemon 12
        ' 
        ' </Snippet4>

        'DISTINCT

        ' <Snippet5>

        Dim products() As Product = 
            {New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "orange", .Code = 4}, 
             New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "lemon", .Code = 12}}

        ' Exclude duplicates.

        Dim noduplicates = products.Distinct(New ProductComparer())

        For Each product In noduplicates
            Console.WriteLine(product.Name & " " & product.Code)
        Next

        ' This code produces the following output:
        '
        ' apple 9
        ' orange 4
        ' lemon 12
        ' 
        ' </Snippet5>

        ' CONTAINS

        ' <Snippet6>

        Dim fruits() As Product = 
           {New Product With {.Name = "apple", .Code = 9}, 
            New Product With {.Name = "orange", .Code = 4}, 
            New Product With {.Name = "lemon", .Code = 12}}

        Dim apple = New Product With {.Name = "apple", .Code = 9}
        Dim kiwi = New Product With {.Name = "kiwi", .Code = 8}

        Dim prodc As New ProductComparer()

        Dim hasApple = fruits.Contains(apple, prodc)
        Dim hasKiwi = fruits.Contains(kiwi, prodc)

        Console.WriteLine("Apple? " & hasApple)
        Console.WriteLine("Kiwi? " & hasKiwi)


        ' This code produces the following output:
        '
        ' Apple? True
        ' Kiwi? False
        ' </Snippet6>

        ' EXCEPT

        ' <Snippet7>
        Dim fruits1() As Product = 
            {New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "orange", .Code = 4}, 
             New Product With {.Name = "lemon", .Code = 12}}

        Dim fruits2() As Product = 
            {New Product With {.Name = "apple", .Code = 9}}

        ' Get all the elements from the first array
        ' except for the elements from the second array.

        Dim except = fruits1.Except(fruits2, New ProductComparer())

        For Each product In except
            Console.WriteLine(product.Name & " " & product.Code)
        Next

        ' This code produces the following output:
        '
        ' orange 4
        ' lemon 12

        ' </Snippet7>

        ' SEQUENCEEQUAL

        ' <Snippet8>

        Dim storeA() As Product = 
            {New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "orange", .Code = 4}}

        Dim storeB() As Product = 
            {New Product With {.Name = "apple", .Code = 9}, 
             New Product With {.Name = "orange", .Code = 4}}

        Dim equalAB = storeA.SequenceEqual(storeB, New ProductComparer())

        Console.WriteLine("Equal? " & equalAB)

        ' This code produces the following output:

        ' Equal? True
        ' </Snippet8>

        Console.ReadLine()


    End Sub
End Module
