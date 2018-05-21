        Dim numEvens = (From num In numbers
                        Where num Mod 2 = 0
                        Select num).Count()