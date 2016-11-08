        Dim flight2 = New With {Key .Airline = "Blue Yonder Airlines",
                                Key .FlightNo = 3554, .Gate = "D14"}
        ' The following statement displays True. The values of the non-key 
        ' property, Gate, do not have to be equal.
        Console.WriteLine(flight1.Equals(flight2))

        Dim flight3 = New With {Key .Airline = "Blue Yonder Airlines",
                                Key .FlightNo = 431, .Gate = "C33"}
        ' The following statement displays False, because flight3 has a
        ' different value for key property FlightNo.
        Console.WriteLine(flight1.Equals(flight3))

        Dim flight4 = New With {Key .Airline = "Blue Yonder Airlines",
                                .FlightNo = 3554, .Gate = "C33"}
        ' The following statement displays False. Instance flight4 is not the 
        ' same type as flight1 because they have different key properties. 
        ' FlightNo is a key property of flight1 but not of flight4.
        Console.WriteLine(flight1.Equals(flight4))