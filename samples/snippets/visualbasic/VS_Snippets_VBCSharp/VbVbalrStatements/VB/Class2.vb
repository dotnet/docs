Option Explicit Off
Option Strict Off

Public Class Class2
    Sub TestExplicit()
        ' Option Explicit Statement (Visual Basic)
        ' e82ac1ad-2cd3-49b2-b985-8bcf016f3fcc
        '<Snippet48>
        Dim thisVar As Integer
        thisVar = 10
        ' The following assignment produces a COMPILER ERROR because
        ' the variable is not declared and Option Explicit is On.
        thisInt = 10 ' causes ERROR
        '</Snippet48>
    End Sub

    Class widget
    End Class
End Class

Public Class Example98
    ' Yield Statement (Visual Basic)
    ' f33126c5-d7c4-43e2-8e36-4ae3f0703d97

    ' Iterator (Visual Basic)
    ' 69cb0b04-ac87-49d0-bcfe-810c0d60daff

    '<Snippet98>
    Sub Main()
        For Each number In Power(2, 8)
            Console.Write(number & " ")
        Next
        ' Output: 2 4 8 16 32 64 128 256
        Console.ReadKey()
    End Sub

    Private Iterator Function Power(
    ByVal base As Integer, ByVal highExponent As Integer) _
    As System.Collections.Generic.IEnumerable(Of Integer)

        Dim result = 1

        For counter = 1 To highExponent
            result = result * base
            Yield result
        Next
    End Function
    '</Snippet98>
End Class

Public Class Example99
    ' Yield Statement (Visual Basic)
    ' f33126c5-d7c4-43e2-8e36-4ae3f0703d97

    ' Iterator (Visual Basic)
    ' 69cb0b04-ac87-49d0-bcfe-810c0d60daff

    '<Snippet99>
    Sub Main()
        Dim theGalaxies As New Galaxies
        For Each theGalaxy In theGalaxies.NextGalaxy
            With theGalaxy
                Console.WriteLine(.Name & "  " & .MegaLightYears)
            End With
        Next
        Console.ReadKey()
    End Sub

    Public Class Galaxies
        Public ReadOnly Iterator Property NextGalaxy _
        As System.Collections.Generic.IEnumerable(Of Galaxy)
            Get
                Yield New Galaxy With {.Name = "Tadpole", .MegaLightYears = 400}
                Yield New Galaxy With {.Name = "Pinwheel", .MegaLightYears = 25}
                Yield New Galaxy With {.Name = "Milky Way", .MegaLightYears = 0}
                Yield New Galaxy With {.Name = "Andromeda", .MegaLightYears = 3}
            End Get
        End Property
    End Class

    Public Class Galaxy
        Public Property Name As String
        Public Property MegaLightYears As Integer
    End Class
    '</Snippet99>

End Class
