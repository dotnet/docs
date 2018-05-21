    Public Class Egg
        Enum EggSizeEnum
            Jumbo
            ExtraLarge
            Large
            Medium
            Small
        End Enum

        Public Sub Poach()
            Dim size As EggSizeEnum

            size = EggSizeEnum.Medium
            ' Continue processing...
        End Sub
    End Class