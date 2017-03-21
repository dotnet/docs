      Dim string1 As String = "244681"
      Try
         Dim number1 As Integer = Int32.Parse(string1)
         Console.WriteLine(number1)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range of a 32-bit integer.", string1)
      Catch e As FormatException
         Console.WriteLine("The format of '{0}' is invalid.", string1)
      End Try

      Dim string2 As String = "F9A3C"
      Try
         Dim number2 As Integer = Int32.Parse(string2,
                                  System.Globalization.NumberStyles.HexNumber)
         Console.WriteLine(number2)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range of a 32-bit integer.", string2)
      Catch e As FormatException
         Console.WriteLine("The format of '{0}' is invalid.", string2)
      End Try
      ' The example displays the following output:
      '       244681
      '       1022524