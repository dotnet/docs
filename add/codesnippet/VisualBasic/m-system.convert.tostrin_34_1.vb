      Dim numbers() As Integer = { Int32.MinValue, Int32.MaxValue}
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      For Each number As Integer In numbers
         Console.WriteLine("{0,-12}  -->  {1,12}", _
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                           Convert.ToString(number, nfi))
      Next
      ' The example displays the following output:
      '       -2147483648  -->  ~2147483648
      '       2147483647   -->  2147483647