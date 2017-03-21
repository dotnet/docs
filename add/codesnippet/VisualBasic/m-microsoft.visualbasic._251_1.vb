    Function GetChoice(ByVal Ind As Integer) As String
        GetChoice = CStr(Choose(Ind, "Speedy", "United", "Federal"))
    End Function