        Dim prod3 = New With {Key .Name = "paperclips", Key .Price = 1.29}
        Dim prod4 = New With {Key .Name = "paperclips", Key .Price = 1.29}
        ' The following line displays True, because prod3 and prod4 are
        ' instances of the same anonymous type, and the values of their
        ' key properties are equal.
        Console.WriteLine(prod3.Equals(prod4))

        Dim prod5 = New With {Key .Name = "paperclips", Key .Price = 1.29}
        Dim prod6 = New With {Key .Name = "paperclips", Key .Price = 1.29,
                              .OnHand = 423}
        ' The following line displays False, because prod5 and prod6 do not 
        ' have the same properties.
        Console.WriteLine(prod5.Equals(prod6))

        Dim prod7 = New With {Key .Name = "paperclips", Key .Price = 1.29,
                              .OnHand = 24}
        Dim prod8 = New With {Key .Name = "paperclips", Key .Price = 1.29,
                              .OnHand = 423}
        ' The following line displays True, because prod7 and prod8 are
        ' instances of the same anonymous type, and the values of their
        ' key properties are equal. The equality check does not compare the
        ' values of the non-key field.
        Console.WriteLine(prod7.Equals(prod8))