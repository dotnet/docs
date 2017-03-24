       Dim phone As XElement = 
            <phone number-type=" work">425-555-0145</phone>

        Console.WriteLine("Phone type: " & phone.@<number-type>)