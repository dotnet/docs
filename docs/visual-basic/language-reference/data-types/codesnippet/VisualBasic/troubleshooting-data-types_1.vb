    Dim oneThird As Double = 1.0 / 3.0
    Dim pointThrees As Double = 0.333333333333333

    ' The following comparison does not indicate equality.
    Dim exactlyEqual As Boolean = (oneThird = pointThrees)

    ' The following comparison indicates equality.
    Dim closeEnough As Double = 0.000000000000001
    Dim absoluteDifference As Double = Math.Abs(oneThird - pointThrees)
    Dim practicallyEqual As Boolean = (absoluteDifference < closeEnough)

    MsgBox("1.0 / 3.0 is represented as " & oneThird.ToString("G17") &
        vbCrLf & "0.333333333333333 is represented as " &
        pointThrees.ToString("G17") &
        vbCrLf & "Exact comparison generates " & CStr(exactlyEqual) &
        vbCrLf & "Acceptable difference comparison generates " &
        CStr(practicallyEqual))