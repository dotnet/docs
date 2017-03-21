      Dim numbers() As Long = { CLng(Int32.MinValue) * 2, CLng(Int32.MaxValue) * 2 }
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      For Each number As Long In numbers
         Console.WriteLine("{0,-12}  -->  {1,12}", _
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                           Convert.ToString(number, nfi))
      Next
      ' The example displays the following output:
      '       -4294967296  -->  ~4294967296
      '       4294967294   -->  4294967294