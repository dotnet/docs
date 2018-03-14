        Dim a As Integer = 10 ' 1010 in binary
        Dim b As Integer = 8  ' 1000 in binary
        Dim c As Integer = 6  ' 0110 in binary
        Dim firstPattern, secondPattern, thirdPattern As Integer
        firstPattern = (a Xor b)  '  2, 0010 in binary
        secondPattern = (a Xor c) ' 12, 1100 in binary
        thirdPattern = (b Xor c)  ' 14, 1110 in binary