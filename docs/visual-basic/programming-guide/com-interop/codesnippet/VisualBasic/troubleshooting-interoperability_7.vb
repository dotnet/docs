    Sub PassByVal(ByVal pError As ADODB.Error)
        ' The extra set of parentheses around the arguments
        ' forces them to be passed by value.
        ProcessParams((pError.Description))
    End Sub