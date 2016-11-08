    Interface Interface1
        Sub sub1(ByVal i As Integer)
    End Interface

    ' Demonstrates interface inheritance.
    Interface Interface2
        Inherits Interface1
        Sub M1(ByVal y As Integer)
        ReadOnly Property Num() As Integer
    End Interface