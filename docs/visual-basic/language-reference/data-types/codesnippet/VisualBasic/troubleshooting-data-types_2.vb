    Dim two As Double = 2.0
    Dim zeroPointTwo As Double = 0.2
    Dim quotient As Double = two / zeroPointTwo
    Dim doubleRemainder As Double = two Mod zeroPointTwo

    MsgBox("2.0 is represented as " & two.ToString("G17") &
        vbCrLf & "0.2 is represented as " & zeroPointTwo.ToString("G17") &
        vbCrLf & "2.0 / 0.2 generates " & quotient.ToString("G17") &
        vbCrLf & "2.0 Mod 0.2 generates " &
        doubleRemainder.ToString("G17"))

    Dim decimalRemainder As Decimal = 2D Mod 0.2D
    MsgBox("2.0D Mod 0.2D generates " & CStr(decimalRemainder))