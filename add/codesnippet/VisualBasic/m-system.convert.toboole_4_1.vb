      Dim numbers() As Short = { Int16.MinValue, -10000, -154, 0, 216, _
                                 21453, Int16.MaxValue }
      Dim result As Boolean
      
      For Each number As Short In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-7:N0}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -32,768  -->  True
      '       -10,000  -->  True
      '       -154     -->  True
      '       0        -->  False
      '       216      -->  True
      '       21,453   -->  True
      '       32,767   -->  True