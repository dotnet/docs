        Dim londonCusts4 = From cust In customers
                           Where cust.City = "London"
                           Order By cust.Name Ascending
                           Select Name = cust.Name, Phone = cust.Phone

        For Each londonCust In londonCusts4
            Console.WriteLine(londonCust.Name & " " & londonCust.Phone)
        Next
