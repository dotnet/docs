      ' Create Long and Validator.
      Dim testLong As Int64 = 17592186044416
      Dim minLongVal As Int64 = 1099511627776
      Dim maxLongVal As Int64 = 281474976710656
      Dim myLongValidator As LongValidator = _
       New LongValidator(minLongVal, maxLongVal, False)