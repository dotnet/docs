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