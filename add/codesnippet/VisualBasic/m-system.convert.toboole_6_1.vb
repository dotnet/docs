      Dim numbers() As Single = { Single.MinValue, -193.0012, 20e-15, 0, _
                                  10551e-10, 100.3398, Single.MaxValue }
      Dim result As Boolean
      
      For Each number As Single In numbers
         result = Convert.ToBoolean(number)                                 
         Console.WriteLine("{0,-15}  -->  {1}", number, result)
      Next
      ' The example displays the following output:
      '       -3.402823E+38    -->  True
      '       -193.0012        -->  True
      '       2E-14            -->  True
      '       0                -->  False
      '       1.0551E-06       -->  True
      '       100.3398         -->  True
      '       3.402823E+38     -->  True