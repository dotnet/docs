      Dim bytes() As Byte = { Byte.MinValue, 100, 200, Byte.MaxValue }
      Dim result As Boolean
      
      For Each byteValue As Byte In bytes
         result = Convert.ToBoolean(byteValue) 
         Console.WriteLine("{0,-5}  -->  {1}", byteValue, result)
      Next           
      ' The example displays the following output:
      '       0      -->  False
      '       100    -->  True
      '       200    -->  True
      '       255    -->  True