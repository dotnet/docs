let multiplicationTable =
    seq {
        for i in 1..9 do
            for j in 1..9 -> (i, j, i * j)
    }
