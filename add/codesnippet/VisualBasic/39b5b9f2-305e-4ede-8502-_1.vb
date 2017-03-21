            ' Create Validator for the range of 1 to 10 inclusive
            Dim minIntVal As Int32 = 1
            Dim maxIntVal As Int32 = 10
            Dim exclusive As Boolean = False
            Dim validator As IntegerValidator = _
                New IntegerValidator(minIntVal, maxIntVal, exclusive)