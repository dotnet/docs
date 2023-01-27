Class BinSearch1

    Sub New()
        _storedNames = Array.Empty(Of String)
    End Sub

    '<no_compare>
    ' Incorrect
    Dim _storedNames As String()

    Sub StoreNames(names As String())
        ReDim _storedNames(names.Length - 1)

        ' Copy the array contents into a new array
        Array.Copy(names, _storedNames, names.Length)

        Array.Sort(_storedNames) ' Line A
    End Sub

    Function DoesNameExist(name As String) As Boolean
        Return Array.BinarySearch(_storedNames, name) >= 0 ' Line B
    End Function
    '</no_compare>

End Class

Class BinSearch2

    Sub New()
        _storedNames = Array.Empty(Of String)
    End Sub

    '<ordinal>
    ' Correct
    Dim _storedNames As String()

    Sub StoreNames(names As String())
        ReDim _storedNames(names.Length - 1)

        ' Copy the array contents into a new array
        Array.Copy(names, _storedNames, names.Length)

        Array.Sort(_storedNames, StringComparer.Ordinal) ' Line A
    End Sub

    Function DoesNameExist(name As String) As Boolean
        Return Array.BinarySearch(_storedNames, name, StringComparer.Ordinal) >= 0 ' Line B
    End Function
    '</ordinal>

End Class

Class BinSearch3

    Sub New()
        _storedNames = Array.Empty(Of String)
    End Sub

    '<invariant>
    ' Correct
    Dim _storedNames As String()

    Sub StoreNames(names As String())
        ReDim _storedNames(names.Length - 1)

        ' Copy the array contents into a new array
        Array.Copy(names, _storedNames, names.Length)

        Array.Sort(_storedNames, StringComparer.InvariantCulture) ' Line A
    End Sub

    Function DoesNameExist(name As String) As Boolean
        Return Array.BinarySearch(_storedNames, name, StringComparer.InvariantCulture) >= 0 ' Line B
    End Function
    '</invariant>

End Class
