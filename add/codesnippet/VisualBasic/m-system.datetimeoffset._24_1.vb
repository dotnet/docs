      Dim offsetDate As New DateTimeOffset(#12/3/2007 11:30AM#, _
                                     New TimeSpan(-8, 0, 0)) 
      Dim duration As New TimeSpan(7, 18, 0, 0)
      Console.WriteLine(offsetDate.Subtract(duration))    ' Displays 11/25/2007 5:30:00 PM -08:00