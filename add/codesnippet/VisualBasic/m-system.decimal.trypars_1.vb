      Dim value As String
      Dim number As Decimal
      
      ' Parse a floating-point value with a thousands separator.
      value = "1,643.57"
      If Decimal.TryParse(value, number) Then
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)      
      End If   
      
      ' Parse a floating-point value with a currency symbol and a 
      ' thousands separator.
      value = "$1,643.57"
      If Decimal.TryParse(value, number) Then
         Console.WriteLine(number)  
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      
      ' Parse value in exponential notation.
      value = "-1.643e6"
      If Decimal.TryParse(value, number)
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      
      ' Parse a negative integer value.
      value = "-1689346178821"
      If Decimal.TryParse(value, number)
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      ' The example displays the following output to the console:
      '       1643.57
      '       Unable to parse '$1,643.57'.
      '       Unable to parse '-1.643e6'.
      '       -1689346178821      