      Dim string1 As String = "244"
      Try
         Dim byte1 As Byte = Byte.Parse(string1)
         Console.WriteLine(byte1)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range of a byte.", string1)
      Catch e As FormatException
         Console.WriteLine("'{0}' is out of range of a byte.", string1)
      End Try

      Dim string2 As String = "F9"
      Try
         Dim byte2 As Byte = Byte.Parse(string2,
                                   System.Globalization.NumberStyles.HexNumber)
         Console.WriteLine(byte2)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range of a byte.", string2)
      Catch e As FormatException
         Console.WriteLine("'{0}' is out of range of a byte.", string2)
      End Try
      ' The example displays the following output:
      '       244
      '       249