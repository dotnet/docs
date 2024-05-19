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
      Dim numbers() As Integer = { -1403, 0, 169, 1483104 }
      For Each number As Integer In numbers
         ' Display value using default formatting.
         Console.Write("{0,-8}  -->   ", number.ToString())
         ' Display value with 3 digits and leading zeros.
         Console.Write("{0,11:D3}", number) 
         ' Display value with 1 decimal digit.
         Console.Write("{0,13:N1}", number) 
         ' Display value as hexadecimal.
         Console.Write("{0,12:X2}", number) 
         ' Display value with eight hexadecimal digits.
         Console.WriteLine("{0,14:X8}", number)
      Next   
      ' The example displays the following output:
      '    -1403     -->         -1403     -1,403.0    FFFFFA85      FFFFFA85
      '    0         -->           000          0.0          00      00000000
      '    169       -->           169        169.0          A9      000000A9
      '    1483104   -->       1483104  1,483,104.0      16A160      0016A160
      ' </Snippet1>
   End Sub
   
   Private Sub CallConvert()
      ' <Snippet2>
      Dim numbers() As Integer = { -146, 11043, 2781913 }
      Console.WriteLine("{0,8}   {1,32}   {2,11}   {3,10}", _
                        "Value", "Binary", "Octal", "Hex")
      For Each number As Integer In numbers
         Console.WriteLine("{0,8}   {1,32}   {2,11}   {3,10}", _
                           number, Convert.ToString(number, 2), _
                           Convert.ToString(number, 8), _
                           Convert.ToString(number, 16))
      Next      
      ' The example displays the following output:
      '       Value                             Binary         Octal          Hex
      '        -146   11111111111111111111111101101110   37777777556     ffffff6e
      '       11043                     10101100100011         25443         2b23
      '     2781913             1010100111001011011001      12471331       2a72d9
      ' </Snippet2>
   End Sub
End Module

