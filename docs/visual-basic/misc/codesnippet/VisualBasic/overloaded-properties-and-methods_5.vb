    Sub ShowTax()
        ' 8% tax rate.
        Const TaxRate As Single = 0.08
        ' $64.00 Purchase as a String.
        Dim strPrice As String = "64.00"
        ' $64.00 Purchase as a Decimal.
        Dim decPrice As Decimal = 64
        Dim aclass As New TaxClass
        'Call the same method with two different kinds of data.
        MsgBox(aclass.TaxAmount(strPrice, TaxRate))
        MsgBox(aclass.TaxAmount(decPrice, TaxRate))
    End Sub