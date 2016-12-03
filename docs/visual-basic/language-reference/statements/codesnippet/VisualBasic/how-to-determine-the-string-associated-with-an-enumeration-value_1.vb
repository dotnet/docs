  Public Enum flavorEnum
    salty
    sweet
    sour
    bitter
  End Enum

  Private Sub TestMethod()
    MsgBox("The strings in the flavorEnum are:")
    Dim i As String
    For Each i In [Enum].GetNames(GetType(flavorEnum))
        MsgBox(i)
    Next
  End Sub