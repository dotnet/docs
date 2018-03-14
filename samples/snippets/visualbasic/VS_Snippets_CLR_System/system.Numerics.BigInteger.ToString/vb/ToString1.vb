' Visual Basic .NET Document
Option Strict On

Imports System.Globalization
Imports System.Numerics

Module Example
   Public Sub Main()
      ToStringDft()
      Console.WriteLine("-----")
      RoundtripValue()
      Console.WriteLine("-----")
      ToFormattedString()
      Console.WriteLIne("-----")
      FormatStringWithProvider()
   End Sub
   
   Private Sub ToStringDft()
      ' <Snippet1>
      ' Initialize a BigInteger value.
      Dim value As BigInteger = BigInteger.Add(UInt64.MaxValue, 1024)

      ' Display value using the default ToString method.
      Console.WriteLine(value.ToString())        
      ' Display value using some standard format specifiers.
      Console.WriteLine(value.ToString("G"))
      Console.WriteLine(value.ToString("C"))
      Console.WriteLine(value.ToString("D"))
      Console.WriteLine(value.ToString("F"))
      Console.WriteLine(value.ToString("N"))
      Console.WriteLine(value.ToString("X"))       
      ' The example displays the following output on a system whose current 
      ' culture is en-US:
      '       18446744073709552639
      '       18446744073709552639
      '       $18,446,744,073,709,552,639.00
      '       18446744073709552639
      '       18446744073709552639.00
      '       18,446,744,073,709,552,639.00
      '       100000000000003FF      
      ' </Snippet1>
   End Sub
   
   Private Sub RoundTripValue()
      ' <Snippet2>
      ' Create number with 50+ digits and store it to two strings.
      Dim originalNumber As BigInteger = BigInteger.Pow(UInt64.MaxValue, Byte.MaxValue)
      Dim generalString As String = originalNumber.ToString("G")
      Dim roundTripString As String = originalNumber.ToString("R")
      Console.WriteLine("The original value has {0} hexadecmal digits.", originalNumber.ToString("X").Length)
      Console.WriteLine
      
      ' Attempt to round-trip strings and compare them with the original.
      Console.WriteLine("Parsing the string formatted with the 'G' format string.")
      Dim generalBigInteger As BigInteger = BigInteger.Parse(generalString, 
                                            NumberStyles.AllowExponent Or NumberStyles.AllowDecimalPoint)
      If originalNumber.Equals(generalBigInteger) Then
         Console.WriteLine("The values are equal. No data has been lost.")
      Else            
         Console.WriteLine("The values are not equal. Data has been lost.")
      End If    
      Console.WriteLine()
      
      Console.wRiteLine("Parsing the string formatted with the 'R' format string.")
      Dim roundTripBigInteger As BigInteger = BigInteger.Parse(roundTripString)
      If originalNumber.Equals(roundTripBigInteger) Then
         Console.WriteLine("The values are equal. No data has been lost.")
      Else            
         Console.WriteLine("The values are not equal. Data has been lost.")
      End If    
      ' The example displays the following output:
      '       The original value has 4080 hexadecmal digits.
      '       
      '       Parsing the string formatted with the 'G' format string.
      '       The values are not equal. Data has been lost.
      '       
      '       Parsing the string formatted with the 'R' format string.
      '       The values are equal. No data has been lost.
      ' </Snippet2>
   End Sub
   
   Private Sub ToFormattedString()
      ' <Snippet3>
      Dim value As BigInteger = BigInteger.Parse("-903145792771643190182")
      Dim specifiers() As String = { "C", "D", "D25", "E", "E4", "e8", "F0", 
                                     "G", "N0", "P", "R", "X", "0,0.000", 
                                     "#,#.00#;(#,#.00#)" }
      
      For Each specifier As String In specifiers
         Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier))
      Next   
      ' The example displays the following output:
      '       C: ($903,145,792,771,643,190,182.00)
      '       D: -903145792771643190182
      '       D25: -0000903145792771643190182
      '       E: -9.031457E+020
      '       E4: -9.0314E+020
      '       e8: -9.03145792e+020
      '       F0: -903145792771643190182
      '       G: -903145792771643190182
      '       N0: -903,145,792,771,643,190,182
      '       P: -90,314,579,277,164,319,018,200.00 %
      '       R: -903145792771643190182
      '       X: CF0A55968BB1A7545A
      '       0,0.000: -903,145,792,771,643,190,182.000
      '       #,#.00#;(#,#.00#): (903,145,792,771,643,190,182.00)
      ' </Snippet3>
   End Sub
   
   Private Sub FormatStringWithProvider()
      ' <Snippet4>
      ' Redefine the negative sign as the tilde for the invariant culture.
      Dim bigIntegerFormatter As New NumberFormatInfo()
      bigIntegerFormatter.NegativeSign = "~"

      Dim value As BigInteger = BigInteger.Parse("-903145792771643190182")
      Dim specifiers() As String = { "C", "D", "D25", "E", "E4", "e8", "F0", 
                                     "G", "N0", "P", "R", "X", "0,0.000", 
                                     "#,#.00#;(#,#.00#)" }
      
      For Each specifier As String In specifiers
         Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier, 
                           bigIntegerformatter))
      Next   
      ' The example displays the following output:
      '    C: (☼903,145,792,771,643,190,182.00)
      '    D: ~903145792771643190182
      '    D25: ~0000903145792771643190182
      '    E: ~9.031457E+020
      '    E4: ~9.0314E+020
      '    e8: ~9.03145792e+020
      '    F0: ~903145792771643190182
      '    G: ~903145792771643190182
      '    N0: ~903,145,792,771,643,190,182
      '    P: ~90,314,579,277,164,319,018,200.00 %
      '    R: ~903145792771643190182
      '    X: CF0A55968BB1A7545A
      '    0,0.000: ~903,145,792,771,643,190,182.000
      '    #,#.00#;(#,#.00#): (903,145,792,771,643,190,182.00)
      ' </Snippet4>
   End Sub
End Module

