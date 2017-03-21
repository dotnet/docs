        Dim valBase As _
        ConfigurationValidatorBase

        Dim rstrValAttr As _
        New RegexStringValidatorAttribute("\w+\S*")

        ' Get the regular expression string.
        Dim regex As String = _
        rstrValAttr.Regex
        Console.WriteLine( _
        "Regular expression: {0}", regex)