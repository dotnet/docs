Imports System
Imports System.Collections.Generic
Imports System.LINQ

'<Snippet1>
Public Class Product
    Implements IEquatable(Of Product)

    Public Property Name As String
    Public Property Code As Integer

    Public Function Equals1(
        ByVal other As Product
        ) As Boolean Implements IEquatable(Of Product).Equals

        ' Check whether the compared object is null.
        If other Is Nothing Then Return False

        ' Check whether the compared object references the same data.
        If Me Is Other Then Return True

        ' Check whether the products' properties are equal.
        Return Code.Equals(other.Code) AndAlso Name.Equals(other.Name)
    End Function

    Public Overrides Function GetHashCode() As Integer

        ' Get hash code for the Name field if it is not null.
        Dim hashProductName = If(Name Is Nothing, 0, Name.GetHashCode())

        ' Get hash code for the Code field.
        Dim hashProductCode = Code.GetHashCode()

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

        Dim duplicates = store1.Intersect(store2)

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

        Dim union = store1.Union(store2)

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

        Dim noduplicates = products.Distinct()

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

        Dim except = fruits1.Except(fruits2)

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

        Dim equalAB = storeA.SequenceEqual(storeB)

        Console.WriteLine("Equal? " & equalAB)

        ' This code produces the following output:

        ' Equal? True
        ' </Snippet8>

        Console.ReadLine()


    End Sub
End Module
