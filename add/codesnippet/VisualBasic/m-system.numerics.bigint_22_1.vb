      Dim number1 As BigInteger = BigInteger.Zero
      Dim number2 As BigInteger = BigInteger.Zero
      Dim succeeded1 As Boolean = BigInteger.TryParse("-12347534159895123", number1)
      Dim succeeded2 As Boolean = BigInteger.TryParse("987654321357159852", number2)
      If succeeded1 AndAlso succeeded2
         number1 *= 3
         number2 *= 2
         Select Case BigInteger.Compare(number1, number2)
            Case -1
               Console.WriteLine("{0} is greater than {1}.", number2, number1)
            Case 0
               Console.WriteLine("{0} is equal to {1}.", number1, number2)
            Case 1
               Console.WriteLine("{0} is greater than {1}.", number1, number2)
         End Select      
      Else
         If Not succeeded1 Then 
            Console.WriteLine("Unable to initialize the first BigInteger value.")
         End If
         If Not succeeded2 Then
            Console.WriteLine("Unable to initialize the second BigInteger value.")
         
         End If
      End If
      ' The example displays the following output:
      '      1975308642714319704 is greater than -37042602479685369.