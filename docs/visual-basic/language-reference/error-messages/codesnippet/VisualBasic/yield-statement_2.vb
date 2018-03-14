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