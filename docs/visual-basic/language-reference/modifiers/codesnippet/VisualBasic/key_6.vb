        ' The following statement will not compile, because FlightNo is a key
        ' property and cannot be changed.
        ' flight1.FlightNo = 1234
        '
        ' Gate is not a key property. Its value can be changed.
        flight1.Gate = "C5"