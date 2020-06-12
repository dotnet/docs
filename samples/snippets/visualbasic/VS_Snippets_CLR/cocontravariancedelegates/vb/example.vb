'<Snippet1>
'<Snippet2>
Public Class Base
End Class
Public Class Derived
    Inherits Base
End Class

Public Class Program
    Public Shared Function MyMethod(ByVal b As Base) As Derived
        Return If(TypeOf b Is Derived, b, New Derived())
    End Function

    Shared Sub Main()
        Dim f1 As Func(Of Base, Derived) = AddressOf MyMethod
        '</Snippet2>

        '<Snippet3>
        ' Covariant return type.
        Dim f2 As Func(Of Base, Base) = f1
        Dim b2 As Base = f2(New Base())
        '</Snippet3>

        '<Snippet4>
        ' Contravariant parameter type.
        Dim f3 As Func(Of Derived, Derived) = f1
        Dim d3 As Derived = f3(New Derived())
        '</Snippet4>

        '<Snippet5>
        ' Covariant return type and contravariant parameter type.
        Dim f4 As Func(Of Derived, Base) = f1
        Dim b4 As Base = f4(New Derived())
        '</Snippet5>
    End Sub
End Class
'</Snippet1>

