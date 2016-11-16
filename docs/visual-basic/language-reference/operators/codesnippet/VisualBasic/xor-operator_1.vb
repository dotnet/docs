        Dim a As Integer = 10
        Dim b As Integer = 8
        Dim c As Integer = 6
        Dim firstCheck, secondCheck, thirdCheck As Boolean
        firstCheck = a > b Xor b > c
        secondCheck = b > a Xor b > c
        thirdCheck = b > a Xor c > b