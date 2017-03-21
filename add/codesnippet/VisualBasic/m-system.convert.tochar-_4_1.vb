      Dim nullString As String = Nothing
      Dim strings() As String = { "A", "This", vbTab, nullString }
      Dim result As Char
      For Each strng As String In strings
         Try
            result = Convert.ToChar(strng)
            Console.WriteLine("'{0}' converts to '{1}'.", strng, result)
         Catch e As FormatException
            Console.WriteLine("'{0}' is not in the correct format for conversion to a Char.", _
                              strng)
         Catch e As ArgumentNullException
            Console.WriteLine("A null string cannot be converted to a Char.")
         End Try
      Next
      ' The example displays the following output:
      '       'A' converts to 'A'.
      '       'This' is not in the correct format for conversion to a Char.
      '       '       ' converts to ' '.
      '       A null string cannot be converted to a Char.