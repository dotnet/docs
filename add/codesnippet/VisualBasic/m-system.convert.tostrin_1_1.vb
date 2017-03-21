      Dim number As UShort = UInt16.MaxValue
      Dim nfi As New System.Globalization.NumberFormatInfo()
      nfi.NegativeSign = "~"
      nfi.PositiveSign = "!"
      
      Console.WriteLine("{0,-6}  -->  {1,6}", _
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), _
                        Convert.ToString(number, nfi))
      ' The example displays the following output:
      '       65535   -->   65535