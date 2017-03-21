      Dim numbers() As SByte = { SByte.MinValue, -1, 0, 10, 100, SByte.MaxValue }
      Dim result As Boolean
      
      For Each number As SByte In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-5}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -128   -->  True
      '       -1     -->  True
      '       0      -->  False
      '       10     -->  True
      '       100    -->  True
      '       127    -->  True