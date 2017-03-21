      Dim bytes() As Byte = {0, 1, 14, 168, 255}
      For Each byteValue As Byte In Bytes
         Console.WriteLine(byteValue)
      Next   
      ' The example displays the following output to the console if the current
      ' culture is en-US:
      '       0
      '       1
      '       14
      '       168
      '       255      