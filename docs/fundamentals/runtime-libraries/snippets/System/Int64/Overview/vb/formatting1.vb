' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      CallToString()
      Console.WriteLine("-----")
      CallConvert()
   End Sub
   
   Private Sub CallToString()
      ' <Snippet1>
      Dim numbers() As Long = { -1403, 0, 169, 1483104 }
      For Each number In numbers
         ' Display value using default formatting.
         Console.Write("{0,-8}  -->   ", number.ToString())
         ' Display value with 3 digits and leading zeros.
         Console.Write("{0,8:D3}", number)
         ' Display value with 1 decimal digit.
         Console.Write("{0,13:N1}", number) 
         ' Display value as hexadecimal.
         Console.Write("{0,18:X2}", number)
         ' Display value with eight hexadecimal digits.
         Console.WriteLine("{0,18:X8}", number)
      Next   
      ' The example displays the following output:
      '    -1403     -->      -1403     -1,403.0  FFFFFFFFFFFFFA85  FFFFFFFFFFFFFA85
      '    0         -->        000          0.0                00          00000000
      '    169       -->        169        169.0                A9          000000A9
      '    1483104   -->    1483104  1,483,104.0            16A160          0016A160
      ' </Snippet1>
   End Sub
   
   Private Sub CallConvert()
      ' <Snippet2>
      Dim numbers() As Long = { -146, 11043, 2781913 }
      For Each number In numbers
         Console.WriteLine("{0} (Base 10):", number)
         Console.WriteLine("   Binary:  {0}", Convert.ToString(number, 2))
         Console.WriteLine("   Octal:   {0}", Convert.ToString(number, 8))
         Console.WriteLine("   Hex:     {0}", Convert.ToString(number, 16))
         Console.WriteLine()
      Next      
      ' The example displays the following output:
      '    -146 (Base 10):
      '       Binary:  1111111111111111111111111111111111111111111111111111111101101110
      '       Octal:   1777777777777777777556
      '       Hex:     ffffffffffffff6e
      '
      '    11043 (Base 10):
      '       Binary:  10101100100011
      '       Octal:   25443
      '       Hex:     2b23
      '
      '    2781913 (Base 10):
      '       Binary:  1010100111001011011001
      '       Octal:   12471331
      '       Hex:     2a72d9
      ' </Snippet2>
   End Sub
End Module

