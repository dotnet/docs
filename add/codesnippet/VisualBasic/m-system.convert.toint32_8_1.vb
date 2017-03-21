      Dim chars() As Char = { "a"c, "z"c, ChrW(7), ChrW(1023), _
                              ChrW(Short.MaxValue), ChrW(&hFFFE) }
      Dim result As Integer
                              
      For Each ch As Char in chars
         Try
            result = Convert.ToInt32(ch)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              ch.GetType().Name, ch, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("Unable to convert u+{0} to an Int32.", _
                              AscW(ch).ToString("X4"))
         End Try
      Next   
      ' The example displays the following output:
      '       Converted the Char value 'a' to the Int32 value 97.
      '       Converted the Char value 'z' to the Int32 value 122.
      '       Converted the Char value '' to the Int32 value 7.
      '       Converted the Char value '?' to the Int32 value 1023.
      '       Converted the Char value '?' to the Int32 value 32767.
      '       Converted the Char value '?' to the Int32 value 65534.