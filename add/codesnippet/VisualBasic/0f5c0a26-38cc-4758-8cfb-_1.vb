        Dim longs() As Nullable(Of Long) = {Nothing, 10007L, 37L, 399846234235L}

        Dim average As Nullable(Of Double) = longs.AsQueryable().Average()

        MsgBox(String.Format("The average is {0}.", average))

        ' This code produces the following output:
        '
        ' The average is 133282081426.333. 
