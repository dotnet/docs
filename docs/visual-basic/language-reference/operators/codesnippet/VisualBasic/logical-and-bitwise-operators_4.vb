        If amount > highestAllowed And checkIfValid(amount) Then
            ' The preceding statement calls checkIfValid().
        End If
        If amount > highestAllowed AndAlso checkIfValid(amount) Then
            ' The preceding statement does not call checkIfValid().
        End If
        If amount < highestAllowed Or checkIfValid(amount) Then
            ' The preceding statement calls checkIfValid().
        End If
        If amount < highestAllowed OrElse checkIfValid(amount) Then
            ' The preceding statement does not call checkIfValid().
        End If