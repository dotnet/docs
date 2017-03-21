      Dim dtfi As DateTimeFormatInfo
      
      dtfi = DateTimeFormatInfo.CurrentInfo
      Console.WriteLine(dtfi.IsReadOnly)
      
      dtfi = CultureInfo.CurrentCulture.DateTimeFormat
      Console.WriteLine(dtfi.IsReadOnly)
      
      dtfi = DateTimeFormatInfo.GetInstance(CultureInfo.CurrentCulture)
      Console.WriteLine(dtfi.IsReadOnly)
      ' The example displays the following output:
      '     True
      '     True
      '     True