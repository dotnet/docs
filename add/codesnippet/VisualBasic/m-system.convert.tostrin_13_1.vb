      Dim numbers() As Short = { Int16.MinValue, Int16.MaxValue}
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      For Each number As Short In numbers
         Console.WriteLine("{0,-8}  -->  {1,8}", _
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                           Convert.ToString(number, nfi))
      Next
      ' The example displays the following output:
      '       -32768    -->    ~32768
      '       32767     -->     32767