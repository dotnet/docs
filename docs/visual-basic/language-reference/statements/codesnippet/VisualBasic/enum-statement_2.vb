    Public Sub Scramble(ByVal size As Egg.EggSizeEnum)
        ' Process for the three largest sizes.
        ' Throw an exception for any other size.
        Select Case size
            Case Egg.EggSizeEnum.Jumbo
                ' Process.
            Case Egg.EggSizeEnum.ExtraLarge
                ' Process.
            Case Egg.EggSizeEnum.Large
                ' Process.
            Case Else
                Throw New ApplicationException("size is invalid: " & size.ToString)
        End Select
    End Sub