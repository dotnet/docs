        Dim ErrorNumber As Integer
        For ErrorNumber = 61 To 64   ' Loop through values 61 - 64.
            MsgBox(ErrorToString(ErrorNumber))   ' Display error names in message box.
        Next ErrorNumber