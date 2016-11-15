        ' The valid range of a Byte variable is 0 through 255.
        Dim b As Byte
        b = 30
        ' The following statement causes an error because the value is too large.
        'b = 256
        ' The following statement causes an error because the value is negative.
        'b = -5
        ' The following statement sets b to 6.
        b = CByte(5.7)

        ' The following statements apply bit-shift operators to b.
        ' The initial value of b is 6.
        Console.WriteLine(b)
        ' Bit shift to the right divides the number in half. In this 
        ' example, binary 110 becomes 11.
        b >>= 1
        ' The following statement displays 3.
        Console.WriteLine(b)
        ' Now shift back to the original position, and then one more bit
        ' to the left. Each shift to the left doubles the value. In this
        ' example, binary 11 becomes 1100.
        b <<= 2
        ' The following statement displays 12.
        Console.WriteLine(b)