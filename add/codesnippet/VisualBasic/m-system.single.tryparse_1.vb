      Dim value As String
      Dim number As Single
      
      ' Parse a floating-point value with a thousands separator.
      value = "1,643.57"
      If Single.TryParse(value, number) Then
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)      
      End If   
      
      ' Parse a floating-point value with a currency symbol and a 
      ' thousands separator.
      value = "$1,643.57"
      If Single.TryParse(value, number) Then
         Console.WriteLine(number)  
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      
      ' Parse value in exponential notation.
      value = "-1.643e6"
      If Single.TryParse(value, number)
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      
      ' Parse a negative integer number.
      value = "-168934617882109132"
      If Single.TryParse(value, number)
         Console.WriteLine(number)
      Else
         Console.WriteLine("Unable to parse '{0}'.", value)   
      End If
      ' The example displays the following output:
      '       1643.57
      '       Unable to parse '$1,643.57'.
      '       -1643000
      '       -1.68934617882109E+17