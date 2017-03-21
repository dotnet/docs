      Dim chars() As Char = { "a"c, "z"c, ChrW(7), ChrW(1023), _
                              ChrW(Short.MaxValue), ChrW(&hFFFE) }
      Dim result As Short
                              
      For Each ch As Char in chars
         Try
            result = Convert.ToInt16(ch)
            Console.WriteLine("'{0}' converts to {1}.", ch, result)
         Catch e As OverflowException
            Console.WriteLine("Unable to convert u+{0} to an Int16.", _
                              AscW(ch).ToString("X4"))
         End Try
      Next   
      ' The example displays the following output:
      '       'a' converts to 97.
      '       'z' converts to 122.
      '       '' converts to 7.
      '       '?' converts to 1023.
      '       '?' converts to 32767.
      '       Unable to convert u+FFFE to a UInt16.