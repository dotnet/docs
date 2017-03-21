      Dim values() As String = { "12", "31.", "5.8:32:16", "12:12:15.95", ".12"}
      For Each value As String In values
         Try
            Dim ts As TimeSpan = TimeSpan.Parse(value)
            Console.WriteLine("'{0}' --> {1}", value, ts)
         Catch e As FormatException
            Console.WriteLine("Unable to parse '{0}'", value)
         Catch e As OverflowException
            Console.WriteLine("'{0}' is outside the range of a TimeSpan.", value)
         End Try   
      Next
      ' The example displays the following output:
      '       '12' --> 12.00:00:00
      '       Unable to parse '31.'
      '       '5.8:32:16' --> 5.08:32:16
      '       '12:12:15.95' --> 12:12:15.9500000
      '       Unable to parse '.12'  