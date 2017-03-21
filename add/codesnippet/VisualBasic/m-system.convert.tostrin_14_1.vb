     Public Sub ConvertStringChar(ByVal stringVal As String)
         Dim charVal As Char = "a"c

         ' A string must be one character long to convert to char.
         Try
             charVal = System.Convert.ToChar(stringVal)
             System.Console.WriteLine("{0} as a char is {1}", _
                                       stringVal, charVal)
         Catch exception As System.FormatException
             System.Console.WriteLine( _
              "The string is longer than one character.")
         Catch exception As System.ArgumentNullException
             System.Console.WriteLine("The string is null.")
         End Try

         ' A char to string conversion will always succeed.
         stringVal = System.Convert.ToString(charVal)
         System.Console.WriteLine("The character as a string is {0}", _
                                   stringVal)
     End Sub