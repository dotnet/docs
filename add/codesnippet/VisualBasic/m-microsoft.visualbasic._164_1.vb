    Sub demonstrateIsError(ByVal firstArg As Integer)
        Dim returnVal As New Object
        Dim badArg As String = "Bad argument value"
        Dim errorCheck As Boolean
        If firstArg > 10000 Then
            returnVal = New System.ArgumentOutOfRangeException(badArg)
        End If
        errorCheck = IsError(returnVal)
    End Sub