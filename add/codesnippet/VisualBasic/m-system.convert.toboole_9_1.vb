      Dim numbers() As Long = { Int64.MinValue, -2016493, -689, 0, 6121, _
                                403890774, Int64.MaxValue }
      Dim result As Boolean
      
      For Each number As Long In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-26:N0}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -9,223,372,036,854,775,808  -->  True
      '       -2,016,493                  -->  True
      '       -689                        -->  True
      '       0                           -->  False
      '       6,121                       -->  True
      '       403,890,774                 -->  True
      '       9,223,372,036,854,775,807   -->  True