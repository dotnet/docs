        Dim valBase As ConfigurationValidatorBase
        Dim strValAttr As New StringValidatorAttribute()

        Dim badValue As Long = 10
        Dim goodValue As String = "10"

        Try
            valBase = strValAttr.ValidatorInstance
            valBase.Validate(goodValue)
            ' valBase.Validate(badValue);
        Catch e As ArgumentException
            ' Display error message.
            Dim msg As String = e.ToString()

#If DEBUG Then
            Console.WriteLine(msg)
#End If
        End Try '