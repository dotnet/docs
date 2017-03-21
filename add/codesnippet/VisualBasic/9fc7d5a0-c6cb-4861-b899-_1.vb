        Dim InitCost, SalvageVal, LifeTime, DepYear As Double
        Dim Fmt As String = "###,##0.00"

        InitCost = CDbl(InputBox("What's the initial cost of the asset?"))
        SalvageVal = CDbl(InputBox("Enter the asset's value at end of its life."))
        LifeTime = CDbl(InputBox("What's the asset's useful life in years?"))

        ' Use the SLN function to calculate the deprecation per year.
        Dim SlnDepr As Double = SLN(InitCost, SalvageVal, LifeTime)
        Dim msg As String = "The depreciation per year: " & Format(SlnDepr, Fmt)
        msg &= vbCrLf & "Year" & vbTab & "Linear" & vbTab & "Doubling" & vbCrLf

        ' Use the SYD and DDB functions to calculate the deprecation for each year.
        For DepYear = 1 To LifeTime
            msg &= DepYear & vbTab & 
                Format(SYD(InitCost, SalvageVal, LifeTime, DepYear), Fmt) & vbTab & 
                Format(DDB(InitCost, SalvageVal, LifeTime, DepYear), Fmt) & vbCrLf
        Next
        MsgBox(msg)