Public Class MyFontList
    Inherits BindingList(Of Font)

    Protected Overrides ReadOnly Property SupportsSearchingCore() As Boolean
        Get
            Return True
        End Get
    End Property
    
    Protected Overrides Function FindCore(ByVal prop As PropertyDescriptor, _
        ByVal key As Object) As Integer
        ' Ignore the prop value and search by family name.
        Dim i As Integer
        While i < Count
            If Items(i).FontFamily.Name.ToLower() = CStr(key).ToLower() Then
                Return i
            End If
            i += 1
        End While

        Return -1
    End Function
End Class