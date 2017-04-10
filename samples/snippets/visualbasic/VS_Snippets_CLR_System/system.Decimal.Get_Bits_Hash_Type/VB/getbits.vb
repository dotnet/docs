' <Snippet2>
Module Example
   Public Sub Main()
      ' Define an array of decimal values.
      Dim values() As Decimal = { 1d, 100000000000000d, 
                                  10000000000000000000000000000d,
                                  100000000000000.00000000000000d, 
                                  1.0000000000000000000000000000d,
                                  123456789d, 0.123456789d, 
                                  0.000000000123456789d,
                                  0.000000000000000000123456789d, 
                                  4294967295d,
                                  18446744073709551615d, 
                                  Decimal.MaxValue, Decimal.MinValue, 
                                  -7.9228162514264337593543950335d }

      Console.WriteLine("{0,31}  {1,10:X8}{2,10:X8}{3,10:X8}{4,10:X8}", 
                        "Argument", "Bits[3]", "Bits[2]", "Bits[1]", 
                        "Bits[0]" )
      Console.WriteLine( "{0,31}  {1,10:X8}{2,10:X8}{3,10:X8}{4,10:X8}", 
                         "--------", "-------", "-------", "-------", 
                         "-------" )

      ' Iterate each element and display its binary representation
      For Each value In values
         Dim bits() As Integer = Decimal.GetBits(value)
        Console.WriteLine("{0,31}  {1,10:X8}{2,10:X8}{3,10:X8}{4,10:X8}", 
                          value, bits(3), bits(2), bits(1), bits(0))

       Next
    End Sub
End Module 
' The example displays the following output:
'
'                        Argument     Bits(3)   Bits(2)   Bits(1)   Bits(0)
'                        --------     -------   -------   -------   -------
'                               1    00000000  00000000  00000000  00000001
'                 100000000000000    00000000  00000000  00005AF3  107A4000
'   10000000000000000000000000000    00000000  204FCE5E  3E250261  10000000
'  100000000000000.00000000000000    000E0000  204FCE5E  3E250261  10000000
'  1.0000000000000000000000000000    001C0000  204FCE5E  3E250261  10000000
'                       123456789    00000000  00000000  00000000  075BCD15
'                     0.123456789    00090000  00000000  00000000  075BCD15
'            0.000000000123456789    00120000  00000000  00000000  075BCD15
'   0.000000000000000000123456789    001B0000  00000000  00000000  075BCD15
'                      4294967295    00000000  00000000  00000000  FFFFFFFF
'            18446744073709551615    00000000  00000000  FFFFFFFF  FFFFFFFF
'   79228162514264337593543950335    00000000  FFFFFFFF  FFFFFFFF  FFFFFFFF
'  -79228162514264337593543950335    80000000  FFFFFFFF  FFFFFFFF  FFFFFFFF
' -7.9228162514264337593543950335    801C0000  FFFFFFFF  FFFFFFFF  FFFFFFFF
'</Snippet2>