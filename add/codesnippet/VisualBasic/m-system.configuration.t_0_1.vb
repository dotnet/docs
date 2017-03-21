        Dim valBase As ConfigurationValidatorBase
        Dim tsValAttr As TimeSpanValidatorAttribute
        tsValAttr = New TimeSpanValidatorAttribute()

        Dim goodValue As TimeSpan = TimeSpan.FromMinutes(10)
        Dim badValue As Int16 = 10

        Try
            valBase = tsValAttr.ValidatorInstance
            valBase.Validate(goodValue)
            ' valBase.Validate(badValue);
        Catch e As ArgumentException
            ' Display error message.
            Dim msg As String = e.ToString()

#If DEBUG Then
            Console.WriteLine(msg)
#End If
        End Try '