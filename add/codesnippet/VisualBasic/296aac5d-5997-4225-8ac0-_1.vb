    Function checkIt(ByVal testMe As Integer) As String
        Return CStr(IIf(testMe > 1000, "Large", "Small"))
    End Function