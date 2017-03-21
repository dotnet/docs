      Dim stringToParse As String = String.Empty
      Try
         ' Parse two strings.
         Dim string1, string2 As String
         string1 = "12347534159895123"
         string2 = "987654321357159852"
         stringToParse = string1
         Dim number1 As BigInteger = BigInteger.Parse(stringToParse)
         Console.WriteLine("Converted '{0}' to {1:N0}.", stringToParse, number1)
         stringToParse = string2
         Dim number2 As BigInteger = BigInteger.Parse(stringToParse)
         Console.WriteLine("Converted '{0}' to {1:N0}.", stringToParse, number2)
         ' Perform arithmetic operations on the two numbers.
         number1 *= 3
         number2 *= 2
         ' Compare the numbers.
         Select Case BigInteger.Compare(number1, number2)
            Case -1
               Console.WriteLine("{0} is greater than {1}.", number2, number1)
            Case 0
               Console.WriteLine("{0} is equal to {1}.", number1, number2)
            Case 1
               Console.WriteLine("{0} is greater than {1}.", number1, number2)
         End Select      
      Catch e As FormatException
         Console.WriteLine("Unable to parse {0}.", stringToParse)
      End Try
      ' The example displays the following output:
      '    Converted '12347534159895123' to 12,347,534,159,895,123.
      '    Converted '987654321357159852' to 987,654,321,357,159,852.
      '    1975308642714319704 is greater than 37042602479685369.      