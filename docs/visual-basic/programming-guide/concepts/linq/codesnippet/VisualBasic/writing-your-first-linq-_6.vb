        Dim numEvensAgg = Aggregate num In numbers
                          Where num Mod 2 = 0
                          Select num
                          Into Count()