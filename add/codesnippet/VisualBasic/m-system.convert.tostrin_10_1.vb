      Dim number As ULong = UInt64.MaxValue
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      Console.WriteLine("{0,-12}  -->  {1,12}", _
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                        Convert.ToString(number, nfi))
      ' The example displays the following output:
      '    18446744073709551615  -->  18446744073709551615