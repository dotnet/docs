    Function checkIfValid(ByVal checkValue As Integer) As Boolean
        If checkValue > 15 Then
            MsgBox(CStr(checkValue) & " is not a valid value.")
            ' The MsgBox warning is not displayed if the call to
            ' checkIfValid() is part of a short-circuited expression.
            Return False
        Else
            grandTotal += checkValue
            ' The grandTotal value is not updated if the call to
            ' checkIfValid() is part of a short-circuited expression.
            Return True
        End If
    End Function