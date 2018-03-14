' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module modMain
   Public Sub Main()
      If MsgBox("Show constructor?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         CreateBigIntegers()
      End If
      If MsgBox("Show overloads of Byte constructor?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         CreatePositiveValueFromByteArray()
         CreateNegativeValueFromByteArray()
      End If
      If MsgBox("Create through operation?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         CreateThroughOperation()
      End If
      If MsgBox("Use CompareTo to compare values?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         CallCompareTo()
      End If
      If MsgBox("Perform BigInteger multiplication?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         MultiplyIfOverflow()
      End If
      If MsgBox("Compare star distances for equality?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         StarDistances.CompareStarDistances()
      End If
      
      If MsgBox("Calculate greatest common denominator?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         GCD()
      End If
      
      If MsgBox("Execute basic mathematical operations?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         Multiply()
         Add()
         Divide()
         Decrement()
         Equality()
         GreaterThan()
         GreaterThanOrEqualTo()
         Increment()
         Inequality()
         LessThan()
         LessThanOrEqualTo()
         Modulus()
      End If
      
      If MsgBox("Illustrate ModPow?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         ShowModPow()
      End If
      
      If MsgBox("Show negation methods?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         ShowNegationMethods()
      End If
      
      If MsgBox("Show exponentiation?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         ShowExponentiation()
      End If
   End Sub
   
   Private Sub CreateBigIntegers()
      ' <Snippet3>
      Dim bigIntFromDouble As New BigInteger(179032.6541)
      Dim bigIntFromInt64 As New BigInteger(934157136952)
      ' </Snippet3>
      Console.WriteLine(bigIntFromDouble)
      Console.WriteLine(bigIntFromInt64)
      ' <Snippet4>
      Dim assignedFromLong As BigInteger = 6315489358112

      Dim assignedFromDouble As BigInteger = CType(179032.6541, BigInteger)
      Dim assignedFromDecimal As BigInteger = CType(64312.65d, BigInteger)      
      ' </Snippet4>
      Console.WriteLine(assignedFromLong)
      Console.WriteLine(assignedFromDecimal)
      Console.WriteLine(assignedFromDouble)   
      
      ' <Snippet34>
      Dim fractionalNumber As Decimal = 13456.921d
      Dim wholeNumber As New BigInteger(fractionalNumber)
      Console.WriteLIne(wholeNumber)        ' Displays 13456
      ' </Snippet34>
      
      ' <Snippet35>
      ' Create a BigInteger from a large double value
      Dim impreciseNumber As Double = -6e35
      Dim preciseNumber As New BigInteger(impreciseNumber)
      Console.WriteLine(impreciseNumber.ToString("F"))
      Console.WriteLine(preciseNumber)
      impreciseNumber += 1
      preciseNumber += BigInteger.One
      Console.WriteLine(impreciseNumber.ToString("F"))
      Console.WriteLine(preciseNumber)
      ' The example displays the following output to the console:
      '       -600000000000000000000000000000000000.00
      '       -599999999999999981180196647507853312
      '       -600000000000000000000000000000000000.00
      '       -599999999999999981180196647507853311
      ' </Snippet35>
      
      ' <Snippet36>
      ' Create a BigInteger from a large negative Single value
      Dim negativeSingle As Single = Single.MinValue
      Dim negativeNumber As New BigInteger(negativeSingle)
      Console.WriteLine(negativeSingle.ToString("F"))
      Console.WriteLine(negativeNumber)
      negativeSingle += 1
      negativeNumber += 1
      Console.WriteLine(negativeSingle.ToString("F"))
      Console.WriteLine(negativeNumber)
      ' The example displays the following output to the console:
      '       -340282300000000000000000000000000000000.00
      '       -340282346638528859811704183484516925440
      '       -340282300000000000000000000000000000000.00
      '       -340282346638528859811704183484516925439   
      ' </Snippet36>
   End Sub
   
   Private Sub CreatePositiveValueFromByteArray()
      ' <Snippet1>
      Dim byteArray() As Byte = { 5, 4, 3, 2, 1}
      Dim newBigInt As New BigInteger(byteArray)
      Console.WriteLine("Value of newBigInt is {0} (or 0x{0:x} hex)", newBigInt) 
      '
      ' The code produces the following output:
      '
      '    Value of newBigInt is 4328719365 (or 0x102030405 hex)   
      ' </Snippet1>
   End Sub
   
   Private Sub CreateNegativeValueFromByteArray()
      ' <Snippet2>
      Dim byteArray() As Byte = { 5, 4, 3, 2, 1}
      Dim newBigInt As New BigInteger(byteArray)
      Console.WriteLine("Value of newBigInt is {0} (or 0x{0:x} hex)", newBigInt)    
      ' </Snippet2>
   End Sub
   
   Private Sub CreateThroughOperation()
      ' <Snippet33>
      Dim longValue As BigInteger = 987654321
      Dim number As BigInteger = BigInteger.Pow(longValue, 3)
      Console.WriteLine(number)        ' Displays 963418328693495609108518161
      ' </Snippet33>      
   End Sub
   
   Private Sub CallCompareTo()
      ' <Snippet6>
      Dim bigIntegerInstance As BigInteger = BigInteger.Parse("3221123045552")

      Dim byteInteger As Byte = 16
      Dim sByteInteger As SByte = -16
      Dim shortInteger As Short = 1233      
      Dim uShortInteger As UShort = 1233
      Dim normalInteger As Integer = -12233
      Dim normalUInteger As UInteger = 12233
      Dim longInteger As Long = 12382222
      Dim uLongInteger As Integer = 1238222
      Dim singleValue As Single = -123.49951
      Dim doubleValue As Double = 123.49951992
      Dim decimalValue As Decimal = 1234.556d

      Console.WriteLine("Comparison of {0} with {1}: {2}", _
                        bigIntegerInstance, byteInteger, _
                        bigIntegerInstance.CompareTo(byteInteger))
      Console.WriteLine("Comparison of {0} with {1}: {2}", _
                        bigIntegerInstance, sByteInteger, _
                        bigIntegerInstance.CompareTo(sByteInteger)) 
      Console.WriteLine("Comparison of {0} with {1}: {2}", _
                        bigIntegerInstance, shortInteger, _
                        bigIntegerInstance.CompareTo(shortInteger)) 
      Console.WriteLine("Comparison of {0} with {1}: {2}", _
                        bigIntegerInstance, uShortInteger, _
                        bigIntegerInstance.CompareTo(uShortInteger)) 
      Console.WriteLine("Comparison of {0} with {1}: {2}", _
                        bigIntegerInstance, normalInteger, _
                        bigIntegerInstance.CompareTo(normalInteger)) 
      Console.WriteLine("Comparison of {0} with {1}: {2}", _
                        bigIntegerInstance, NormalUInteger, _
                        bigIntegerInstance.CompareTo(normalUInteger)) 
      Console.WriteLine("Comparison of {0} with {1}: {2}", _
                        bigIntegerInstance, longInteger, _
                        bigIntegerInstance.CompareTo(longInteger)) 
      Console.WriteLine("Comparison of {0} with {1}: {2}", _
                        bigIntegerInstance, uLongInteger, _
                        bigIntegerInstance.CompareTo(uLongInteger))
      Try
         Console.WriteLine("Comparison of {0} with {1}: {2}", _
                           bigIntegerInstance, singleValue, _
                           bigIntegerInstance.CompareTo(singleValue))
      Catch e As ArgumentException
         Console.WriteLine("Unable to compare {0} with a {1} value of {2}", _
                           bigIntegerInstance, singleValue.GetType().Name, _
                           singleValue)
      End Try                         
      Try
         Console.WriteLine("Comparison of {0} with {1}: {2}", _
                           bigIntegerInstance, doubleValue, _
                           bigIntegerInstance.CompareTo(doubleValue))
      Catch e As ArgumentException
         Console.WriteLine("Unable to compare {0} with a {1} value of {2}", _
                           bigIntegerInstance, doubleValue.GetType().Name, _
                           doubleValue)
      End Try                         
      Try
         Console.WriteLine("Comparison of {0} with {1}: {2}", _
                           bigIntegerInstance, decimalValue, _
                           bigIntegerInstance.CompareTo(decimalValue))
      Catch e As ArgumentException
         Console.WriteLine("Unable to compare {0} with a {1} value of {2}", _
                           bigIntegerInstance, decimalValue.GetType().Name, _
                           decimalValue)
      End Try 
      '
      ' The code produces the following output to the console:
      '
      ' Comparison of 3221123045552 with 16: 1
      ' Comparison of 3221123045552 with -16: 1
      ' Comparison of 3221123045552 with 1233: 1
      ' Comparison of 3221123045552 with 1233: 1
      ' Comparison of 3221123045552 with -12233: 1
      ' Comparison of 3221123045552 with 12233: 1
      ' Comparison of 3221123045552 with 12382222: 1
      ' Comparison of 3221123045552 with 1238222: 1
      ' Unable to compare 3221123045552 with a Single value of -123.4995
      ' Unable to compare 3221123045552 with a Double value of 123.49951992
      ' Unable to compare 3221123045552 with a Decimal value of 1234.556                              
      ' </Snippet6>
   End Sub
   
   Private Sub MultiplyIfOverflow()
      ' <Snippet7> 
      Dim number1 As Long = 1234567890
      Dim number2 As Long = 9876543210
      Try
         Dim product As Long
         product = number1 * number2
         Console.WriteLine(product.ToString("N0"))
      Catch e As OverflowException
         Dim product As BigInteger
         product = BigInteger.Multiply(number1, number2)
         Console.WriteLine(product.ToString)
      End Try   
      ' </Snippet7>
   End Sub
   
   Private Sub CompareDivisionResults(dividend As BigInteger, divisor As BigInteger)
      ' <Snippet8>
      Dim remainder As BigInteger = 0
      Dim quotient As BigInteger
      quotient = BigInteger.DivRem(dividend, divisor, remainder)
      Console.WriteLine("DivRem({0}, {1}) returns {2} with a remainder of {3}", _
                        dividend, _
                        divisor, _
                        quotient, _
                        remainder)
      Console.WriteLine("Result of division: {0}", _
                        BigInteger.Divide(dividend, divisor))
      Console.WriteLine("Remainder after division: {0}", _
                        BigInteger.Remainder(dividend, divisor))
      ' </Snippet8>                                          
   End Sub
   
   Private Sub GCD()
      ' <Snippet10>
      Dim n1 As BigInteger = BigInteger.Pow(154382190, 3)
      Dim n2 As BigInteger = BigInteger.Multiply(1643590, 166935)
      Try
         Console.WriteLine("The greatest common divisor of {0} and {1} is {2}.", _
                           n1, n2, BigInteger.GreatestCommonDivisor(n1, n2))
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine("Unable to calculate the greatest common divisor:")
         Console.WriteLine("   {0} is an invalid value for {1}", _
                           e.ActualValue, e.ParamName)
      End Try                           
      ' </Snippet10>
   End Sub  

   Private Sub ShowModPow()
      ' <Snippet15>
      Dim number As BigInteger = 10
      Dim exponent As Integer = 3
      Dim modulus As BigInteger = 30
      Console.WriteLine("({0}^{1}) Mod {2} = {3}", _
                        number, exponent, modulus, _
                        BigInteger.ModPow(number, exponent, modulus))    ' Displays 10
      ' </Snippet15>
   End Sub
   
   Private Sub ShowNegationMethods()
      ' <Snippet16> 
      Dim number As BigInteger = 12645002
      
      Console.WriteLine(BigInteger.Negate(number))          ' Displays -12645002
      Console.WriteLine(-number)                            ' Displays -12645002
      Console.WriteLine(number * BigInteger.MinusOne)       ' Displays -12645002
      ' </Snippet16> 
   End Sub
   
   Private Sub Decrement()
      ' <Snippet18>
      Dim number As BigInteger = 93843112
      Console.WriteLine(BigInteger.op_Decrement(number))    ' Displays 93843111
      ' </Snippet18>
   End Sub      
   
   Private Sub Equality()
      Console.WriteLine()
      Console.WriteLine("Equality:")
      ' <Snippet19>
      Dim number1 As BigInteger = 945834723
      Dim number2 As BigInteger = 345145625
      Dim number3 As BigInteger = 945834723 
      Console.WriteLine(number1 = number2)                  ' Displays False
      Console.WriteLine(number1 = number3)                  ' Displays True
      ' </Snippet19>
   End Sub
     
   Private Sub GreaterThan()
      Console.WriteLine()
      Console.WriteLine("Greater Than:")
      ' <Snippet20>
      Dim number1 As BigInteger = 945834723
      Dim number2 As BigInteger = 345145625
      Dim number3 As BigInteger = 945834724 
      Console.WriteLine(number1 > number2)                  ' Displays True
      Console.WriteLine(number1 > number3)                  ' Displays False
      ' </Snippet20>
      Console.WriteLine()
      ' <Snippet21>
      Dim numberA As BigInteger = 945834723
      Dim numberB As BigInteger = 345145625
      Dim numberC As BigInteger = 945834724 
      Console.WriteLine(BigInteger.op_GreaterThan(numberA, numberB))    ' Displays True
      Console.WriteLine(BigInteger.op_GreaterThan(numberA, numberC))    ' Displays False
      ' </Snippet21>
      Console.WriteLine()
   End Sub  
   
   Private Sub GreaterThanOrEqualTo()
      Console.WriteLine("Greater Than Or Equal To:")
      ' <Snippet22>
      Dim number1 As BigInteger = 945834723
      Dim number2 As BigInteger = 345145625
      Dim number3 As BigInteger = 945834724 
      Dim number4 As BigInteger = 945834723
      Console.WriteLine(number1 >= number2)                 ' Displays True
      Console.WriteLine(number1 >= number3)                 ' Displays False
      Console.WriteLine(number1 >= number4)                 ' Displays True
      ' </Snippet22>
      Console.WriteLine()
      ' <Snippet23>
      Dim numberA As BigInteger = 945834723
      Dim numberB As BigInteger = 345145625
      Dim numberC As BigInteger = 945834724 
      Dim numberD As BigInteger = 945834723
      Console.WriteLine( _
              BigInteger.op_GreaterThanOrEqual(numberA, numberB))    ' Displays True
      Console.WriteLine( _
              BigInteger.op_GreaterThanOrEqual(numberA, numberC))    ' Displays False
      Console.WriteLine( _
              BigInteger.op_GreaterThanOrEqual(numberA, numberD))    ' Displays True       
      ' </Snippet23>
      Console.WriteLine()
   End Sub
         
   Private Sub Multiply()
      ' <Snippet11>
      Dim num1 As BigInteger = 1000456321
      Dim num2 As BigInteger = 90329434
      Dim result As BigInteger = num1 * num2
      ' </Snippet11>
   End Sub
   
   Private Sub Add()
      ' <Snippet12>
      Dim num1 As BigInteger = 1000456321
      Dim num2 As BigInteger = 90329434
      Dim sum As BigInteger = num1 + num2
      ' </Snippet12>
   End Sub 

   Private Sub Divide()
      ' <Snippet13>
      Dim num1 As BigInteger = 100045632194
      Dim num2 As BigInteger = 90329434
      Dim quotient As BigInteger = num1 / num2
      ' </Snippet13>
   End Sub 

   Private Sub Subtract()
      ' <Snippet14>
      Dim num1 As BigInteger = 100045632194
      Dim num2 As BigInteger = 90329434
      Dim result As BigInteger = num1 - num2
      ' </Snippet14>
   End Sub
   
   Private Sub Increment()
      Console.Write("Decrement operation: ")
      ' <Snippet25>
      Dim number As BigInteger = 93843112
      Console.WriteLine(BigInteger.op_Increment(number))    ' Displays 93843113
      ' </Snippet25>
   End Sub      

   Private Sub Inequality()
      Console.WriteLine()
      Console.WriteLine("Inequality:")
      ' <Snippet26>
      Dim number1 As BigInteger = 945834723
      Dim number2 As BigInteger = 345145625
      Dim number3 As BigInteger = 945834723 
      Console.WriteLine(number1 <> number2)                  ' Displays True
      Console.WriteLine(number1 <> number3)                  ' Displays False
      ' </Snippet26>
   End Sub
   
   Private Sub LessThan()
      Console.WriteLine()
      Console.WriteLine("Less Than:")
      ' <Snippet27>
      Dim number1 As BigInteger = 945834723
      Dim number2 As BigInteger = 345145625
      Dim number3 As BigInteger = 945834724 
      Console.WriteLine(number1 < number2)                  ' Displays False
      Console.WriteLine(number1 < number3)                  ' Displays True
      ' </Snippet27>
      Console.WriteLine()
      ' <Snippet28>
      Dim numberA As BigInteger = 945834723
      Dim numberB As BigInteger = 345145625
      Dim numberC As BigInteger = 945834724 
      Console.WriteLine(BigInteger.op_LessThan(numberA, numberB))    ' Displays False
      Console.WriteLine(BigInteger.op_LessThan(numberA, numberC))    ' Displays True
      ' </Snippet28>
      Console.WriteLine()
   End Sub 
   
   Private Sub LessThanOrEqualTo()
      Console.WriteLine("Less Than Or Equal To:")
      ' <Snippet29>
      Dim number1 As BigInteger = 945834723
      Dim number2 As BigInteger = 345145625
      Dim number3 As BigInteger = 945834724 
      Dim number4 As BigInteger = 945834723
      Console.WriteLine(number1 <= number2)                 ' Displays False
      Console.WriteLine(number1 <= number3)                 ' Displays True
      Console.WriteLine(number1 <= number4)                 ' Displays True
      ' </Snippet29>
      Console.WriteLine()
      ' <Snippet30>
      Dim numberA As BigInteger = 945834723
      Dim numberB As BigInteger = 345145625
      Dim numberC As BigInteger = 945834724 
      Dim numberD As BigInteger = 945834723
      Console.WriteLine( _
              BigInteger.op_LessThanOrEqual(numberA, numberB))    ' Displays False
      Console.WriteLine( _
              BigInteger.op_LessThanOrEqual(numberA, numberC))    ' Displays True
      Console.WriteLine( _
              BigInteger.op_LessThanOrEqual(numberA, numberD))    ' Displays True       
      ' </Snippet30>
      Console.WriteLine()
   End Sub
       
   Private Sub Modulus()
      Console.Write("Modulus operation: ")
      ' <Snippet31>
      Dim num1 As BigInteger = 100045632194
      Dim num2 As BigInteger = 90329434
      Dim remainder As BigInteger = num1 Mod num2
      Console.WriteLine(remainder)                 ' Displays  50948756 
      ' </Snippet31>
      Console.WriteLine()
   End Sub 
   
   Public Sub ShowExponentiation()
      ' <Snippet32>
      Dim base As BigInteger = 3040506
      For ctr As Integer = 0 To 10
         Console.WriteLine(BigInteger.Pow(base, ctr))
      Next
      ' 
      ' The example produces the following output to the console:
      '
      ' 1
      ' 3040506
      ' 9244676736036
      ' 28108495083977874216
      ' 85464047953805230420993296
      ' 259853950587832525926412642447776
      ' 790087495886008322074413197838317614656
      ' 2402265771766383619317185774506591737267255936
      ' 7304103492650319992835619250501939216711515276943616
      ' 22208170494024253840136657344866649200046662468638726109696
      ' 67524075636103707946458547477011116092637077515870858568887346176     '
      ' </Snippet32>
   End Sub
   
End Module

' <Snippet9>
Public Module StarDistances
   Private Const LIGHT_YEAR As Long = 5878625373183

   Public Sub CompareStarDistances()
      Dim altairDistance As BigInteger = 17 * LIGHT_YEAR
      Dim epsilonIndiDistance As BigInteger = 12 * LIGHT_YEAR
      Dim ursaeMajoris47Distance As BigInteger = 46 * LIGHT_YEAR
      Dim tauCetiDistance As BigInteger = 12 * LIGHT_YEAR
      Dim procyon2Distance As Long = 12 * LIGHT_YEAR
      Dim wolf424ABDistance As Object = 14 * LIGHT_YEAR
      
      Console.WriteLine("Approx. equal distances from Epsilon Indi to:")
      Console.WriteLine("   Altair: {0}", _
                        epsilonIndiDistance.Equals(altairDistance))
      Console.WriteLine("   Ursae Majoris 47: {0}", _
                        epsilonIndiDistance.Equals(ursaeMajoris47Distance))
      Console.WriteLine("   TauCeti: {0}", _
                        epsilonIndiDistance.Equals(tauCetiDistance))
      Console.WriteLine("   Procyon 2: {0}", _
                        epsilonIndiDistance.Equals(procyon2Distance))
      Console.WriteLine("   Wolf 424 AB: {0}", _
                        epsilonIndiDistance.Equals(wolf424ABDistance))
   End Sub
End Module
' </Snippet9>
