        Dim cust12 = 
            New Customer With {.Name = "Toni Poe", 
                               .Address = 
                                   New AddressClass With {.City = "Louisville", 
                                                          .State = "Kentucky"}}
        Console.WriteLine(cust12.Address.State)