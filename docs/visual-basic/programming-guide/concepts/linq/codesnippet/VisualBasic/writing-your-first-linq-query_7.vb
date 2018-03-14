        ' Immediate execution.
        Dim evensList = (From num In numbers
                         Where num Mod 2 = 0
                         Select num).ToList()

        ' Deferred execution.
        Dim evensQuery3 = From num In numbers
                          Where num Mod 2 = 0
                          Select num
        ' . . .
        Dim evensArray = evensQuery3.ToArray()