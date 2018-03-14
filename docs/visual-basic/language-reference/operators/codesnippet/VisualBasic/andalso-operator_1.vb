        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstCheck, secondCheck, thirdCheck As Boolean
        firstCheck = a > b AndAlso b > c
        secondCheck = b > a AndAlso b > c
        thirdCheck = a > b AndAlso c > b