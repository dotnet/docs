      Dim number As UInteger = UInt32.MaxValue
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      Console.WriteLine("{0,-8}  -->  {1,8}", _
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                        Convert.ToString(number, nfi))
      ' The example displays the following output:
      '       4294967295  -->  4294967295