      Dim flags() As Boolean = { True, False }
      Dim result As Single
      
      For Each flag As Boolean In flags
         result = Convert.ToSingle(flag)
         Console.WriteLine("Converted {0} to {1}.", flag, result)
      Next
      ' The example displays the following output:
      '       Converted True to 1.
      '       Converted False to 0.      