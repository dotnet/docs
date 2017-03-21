      Dim numbers() As ULong = { UInt64.MinValue, 6121, 403890774, UInt64.MaxValue }
      Dim result As Boolean
      
      For Each number As ULong In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-26:N0}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       0                           -->  False
      '       6,121                       -->  True
      '       403,890,774                 -->  True
      '       18,446,744,073,709,551,615  -->  True