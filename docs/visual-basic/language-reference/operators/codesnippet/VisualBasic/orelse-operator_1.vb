        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstCheck, secondCheck, thirdCheck As Boolean
        firstCheck = a > b OrElse b > c
        secondCheck = b > a OrElse b > c
        thirdCheck = b > a OrElse c > b