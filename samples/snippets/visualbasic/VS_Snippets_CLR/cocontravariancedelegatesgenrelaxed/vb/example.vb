'<Snippet1>
Public Class Type1 
End Class
Public Class Type2
    Inherits Type1
End Class
Public Class Type3
    Inherits Type2
End Class

Public Class Program
    Public Shared Function MyMethod(ByVal t As Type1) As Type3
        Return If(TypeOf t Is Type3, t, New Type3())
    End Function

    Shared Sub Main() 
        Dim f1 As Func(Of Type2, Type2) = AddressOf MyMethod

        ' Covariant return type and contravariant parameter type.
        Dim f2 As Func(Of Type3, Type1) = f1
        Dim t1 As Type1 = f2(New Type3())
    End Sub
End Class
'</Snippet1>

