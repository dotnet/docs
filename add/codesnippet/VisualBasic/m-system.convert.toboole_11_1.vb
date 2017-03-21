      Dim numbers() As Decimal = { Decimal.MinValue, -12034.87d, -100d, _
                                   0d, 300d, 6790823.45d, Decimal.MaxValue }
      Dim result As Boolean
      
      For Each number As Decimal In numbers
         result = Convert.ToBoolean(number) 
         Console.WriteLine("{0,-30}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -79228162514264337593543950335  -->  True
      '       -12034.87                       -->  True
      '       -100                            -->  True
      '       0                               -->  False
      '       300                             -->  True
      '       6790823.45                      -->  True
      '       79228162514264337593543950335   -->  True