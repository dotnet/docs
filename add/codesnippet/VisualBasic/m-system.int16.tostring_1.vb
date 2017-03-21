      Dim numbers() As Short = {0, 14624, 13982, Short.MaxValue, _
                               Short.MinValue, -16667}
      For Each number As Short In numbers
         Console.WriteLine(number.ToString())
      Next        
      ' The example displays the following output to the console:
      '       0
      '       14624
      '       13982
      '       32767
      '       -32768
      '       -16667                             