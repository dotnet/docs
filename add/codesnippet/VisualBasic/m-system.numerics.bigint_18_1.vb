      Dim unsignedValues() As UInteger = { 0, 16704, 199365, UInt32.MaxValue }
      For Each unsignedValue As UInteger In unsignedValues
         Dim constructedNumber As New BigInteger(unsignedValue)
         Dim assignedNumber As BigInteger = unsignedValue
         If constructedNumber.Equals(assignedNumber) Then
            Console.WriteLine("Both methods create a BigInteger whose value is {0:N0}.",
                              constructedNumber)
         Else
            Console.WriteLine("{0:N0} ≠ {1:N0}", constructedNumber, assignedNumber)
         End If                         
      Next
      ' The example displays the following output:
      '    Both methods create a BigInteger whose value is 0.
      '    Both methods create a BigInteger whose value is 16,704.
      '    Both methods create a BigInteger whose value is 199,365.
      '    Both methods create a BigInteger whose value is 4,294,967,295.