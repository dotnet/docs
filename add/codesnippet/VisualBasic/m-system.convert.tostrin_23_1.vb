      Dim numbers() As SByte = { SByte.MinValue, -12, 17, SByte.MaxValue}
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      For Each number As SByte In numbers
         Console.WriteLine(Convert.ToString(number, nfi))
      Next
      ' The example displays the following output:
      '       ~128
      '       ~12
      '       17
      '       127          