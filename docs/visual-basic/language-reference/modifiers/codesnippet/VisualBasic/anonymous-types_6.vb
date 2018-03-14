        ' prod1 and prod2 have no key values.
        Dim prod1 = New With {.Name = "paperclips", .Price = 1.29}
        Dim prod2 = New With {.Name = "paperclips", .Price = 1.29}

        ' The following line displays False, because prod1 and prod2 have no
        ' key properties.
        Console.WriteLine(prod1.Equals(prod2))

        ' The following statement displays True because prod1 is equal to itself.
        Console.WriteLine(prod1.Equals(prod1))