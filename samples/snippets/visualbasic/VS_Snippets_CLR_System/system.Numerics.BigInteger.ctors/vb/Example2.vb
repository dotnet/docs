' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example
   Public Sub Main()
      DecimalConstructor()
      Console.WriteLine("-----")
      DoubleConstructor()
      Console.WriteLine("-----")
      IntegerConstructor()
      Console.WriteLine("-----")
      LongConstructor()
      Console.WriteLine("-----")
      SingleConstructor()
      Console.WriteLine("----")
      UInt32Constructor()
      Console.WriteLine("-----")
      UInt64Constructor()
   End Sub
   
   Private Sub DecimalConstructor()
      ' <Snippet4>
      Dim decimalValues() As Decimal = { -1790.533d, -15.1514d, 18903.79d, 9180098.003d }
      For Each decimalValue As Decimal In decimalValues
         Dim number As New BigInteger(decimalValue)
         Console.WriteLine("Instantiated BigInteger value {0} from the Decimal value {1}.",
                           number, decimalValue)
      Next                 
      ' The example displays the following output:
      '    Instantiated BigInteger value -1790 from the Decimal value -1790.533.
      '    Instantiated BigInteger value -15 from the Decimal value -15.1514.
      '    Instantiated BigInteger value 18903 from the Decimal value 18903.79.
      '    Instantiated BigInteger value 9180098 from the Decimal value 9180098.003.
      ' </Snippet4>
   End Sub
   
   Private Sub DoubleConstructor()
      ' <Snippet5>
      ' Create a BigInteger from a large double value.
      Dim doubleValue As Double = -6e20
      Dim bigIntValue As New BigInteger(doubleValue)
      Console.WriteLine("Original Double value: {0:N0}", doubleValue)
      Console.WriteLine("Original BigInteger value: {0:N0}", bigIntValue)
      ' Increment and then display both values.
      doubleValue += 1
      bigIntValue += BigInteger.One
      Console.WriteLine("Incremented Double value: {0:N0}", doubleValue)
      Console.WriteLine("Incremented BigInteger value: {0:N0}", bigIntValue)
      ' The example displays the following output:
      '    Original Double value: -600,000,000,000,000,000,000
      '    Original BigInteger value: -600,000,000,000,000,000,000
      '    Incremented Double value: -600,000,000,000,000,000,000
      '    Incremented BigInteger value: -599,999,999,999,999,999,999
      ' </Snippet5>   
   End Sub
   
   Private Sub IntegerConstructor()
      ' <Snippet6>
      Dim integers() As Integer = { Int32.MinValue, -10534, -189, 0, 17, 113439,
                                    Int32.MaxValue }
      Dim constructed, assigned As BigInteger
      
      For Each number As Integer In integers
         constructed = New BigInteger(number)
         assigned = number
         Console.WriteLine("{0} = {1}: {2}", constructed, assigned, 
                           constructed.Equals(assigned)) 
      Next
      ' The example displays the following output:
      '       -2147483648 = -2147483648: True
      '       -10534 = -10534: True
      '       -189 = -189: True
      '       0 = 0: True
      '       17 = 17: True
      '       113439 = 113439: True
      '       2147483647 = 2147483647: True
      ' </Snippet6>
   End Sub   

   Private Sub LongConstructor()
      ' <Snippet7>
      Dim longs() As Long = { Int64.MinValue, -10534, -189, 0, 17, 113439,
                                    Int64.MaxValue }
      Dim constructed, assigned As BigInteger
      
      For Each number As Long In longs
         constructed = New BigInteger(number)
         assigned = number
         Console.WriteLine("{0} = {1}: {2}", constructed, assigned, 
                           constructed.Equals(assigned)) 
      Next
      ' The example displays the following output:
      '       -2147483648 = -2147483648: True
      '       -10534 = -10534: True
      '       -189 = -189: True
      '       0 = 0: True
      '       17 = 17: True
      '       113439 = 113439: True
      '       2147483647 = 2147483647: True
      ' </Snippet7>
   End Sub   

   Private Sub SingleConstructor()
      ' <Snippet8>
      ' Create a BigInteger from a large negative Single value
      Dim negativeSingle As Single = Single.MinValue
      Dim negativeNumber As New BigInteger(negativeSingle)
      
      Console.WriteLine(negativeSingle.ToString("N0"))
      Console.WriteLine(negativeNumber.ToString("N0"))
      
      negativeSingle += 1
      negativeNumber += 1
      Console.WriteLine(negativeSingle.ToString("N0"))
      Console.WriteLine(negativeNumber.ToString("N0"))
      ' The example displays the following output:
      '       -340,282,300,000,000,000,000,000,000,000,000,000,000
      '       -340,282,346,638,528,859,811,704,183,484,516,925,440
      '       -340,282,300,000,000,000,000,000,000,000,000,000,000
      '       -340,282,346,638,528,859,811,704,183,484,516,925,439
      ' </Snippet8>
   End Sub

   Private Sub UInt32Constructor()
      ' <Snippet9>
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
      ' </Snippet9>
   End Sub
   
   Private Sub UInt64Constructor()
      ' <Snippet10>
      Dim unsignedValue As ULong = UInt64.MaxValue
      Dim number As New BigInteger(unsignedValue)
      Console.WriteLine(number.ToString("N0"))       
      ' The example displays the following output:
      '       18,446,744,073,709,551,615      
      ' </Snippet10>   
   End Sub
End Module

