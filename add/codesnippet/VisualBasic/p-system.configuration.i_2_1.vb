        Dim valBase As ConfigurationValidatorBase
        Dim intValAttr As IntegerValidatorAttribute
        intValAttr = New IntegerValidatorAttribute()

        Dim badValue As Long = 10
        Dim goodValue As Integer = 10

        Try
            valBase = intValAttr.ValidatorInstance
            valBase.Validate(goodValue)
            ' valBase.Validate(badValue);
        Catch e As ArgumentException
            ' Display error message.
            Dim msg As String = e.ToString()
#If DEBUG Then
            Console.WriteLine(msg)
#End If
        End Try '