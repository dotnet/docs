        Dim points As Nullable(Of Single)() = {Nothing, 0, 92.83F, Nothing, 100.0F, 37.46F, 81.1F}

        Dim sum As Nullable(Of Single) = points.AsQueryable().Sum()

        MsgBox("Total points earned: " & sum)

        'This code produces the following output:

        'Total points earned: 311.39
