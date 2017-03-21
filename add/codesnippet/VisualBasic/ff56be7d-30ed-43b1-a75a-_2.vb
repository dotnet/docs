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
