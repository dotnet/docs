      ' Define an uninitialized date.
      Dim date1 As Date
      Console.Write(date1)
      If date1.Equals(Date.MinValue) Then _
         Console.WriteLine("  (Equals Date.MinValue)")
      ' The example displays the following output:
      '    1/1/0001 12:00:00 AM  (Equals Date.MinValue)