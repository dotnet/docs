      Dim numbers() As UShort = { UInt16.MinValue, 216, 21453, UInt16.MaxValue }
      Dim result As Boolean
      
      For Each number As UShort In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-7:N0}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       0        -->  False
      '       216      -->  True
      '       21,453   -->  True
      '       65,535   -->  True