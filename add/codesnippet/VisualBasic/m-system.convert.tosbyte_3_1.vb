      Dim chars() As Char = { "a"c, "z"c, ChrW(7), ChrW(200), ChrW(1023) }
      For Each ch As Char in chars
         Try
            Dim result As SByte = Convert.ToSByte(ch)
            Console.WriteLine("{0} is converted to {1}.", ch, result)
         Catch e As OverflowException
            Console.WriteLine("Unable to convert u+{0} to a byte.", _
                              AscW(ch).ToString("X4"))
         End Try
      Next   
      ' The example displays the following output:
      '    a is converted to 97.
      '    z is converted to 122.
      '     is converted to 7.
      '    Unable to convert u+00C8 to a byte.
      '    Unable to convert u+03FF to a byte.