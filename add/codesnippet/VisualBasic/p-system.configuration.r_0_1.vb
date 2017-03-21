
        Dim valBase As _
        ConfigurationValidatorBase

        Dim rstrValAttr As _
        New RegexStringValidatorAttribute("\w+\S*")

        ' Get the regular expression string.
        Dim regex As String = _
        rstrValAttr.Regex
        Console.WriteLine( _
        "Regular expression: {0}", regex)

        Dim badValue As _
        String = "&%$bbb"
        Dim goodValue As _
        String = "filename.txt"

        Try
            valBase = rstrValAttr.ValidatorInstance
            valBase.Validate(goodValue)
            ' valBase.Validate(badValue);
        Catch e As ArgumentException
            ' Display error message.
            Dim msg As String = e.ToString()

#If DEBUG Then
            Console.WriteLine(msg)
#End If

        End Try '