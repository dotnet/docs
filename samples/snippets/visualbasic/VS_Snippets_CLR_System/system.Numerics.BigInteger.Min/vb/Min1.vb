' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim numbers() As BigInteger = { Int64.MaxValue * BigInteger.MinusOne, 
                                      BigInteger.MinusOne, 
                                      10359321239000, 
                                      BigInteger.Pow(103988, 2),
                                      BigInteger.Multiply(Int32.MaxValue, Int16.MaxValue), 
                                      BigInteger.Add(BigInteger.Pow(Int64.MaxValue, 2), 
                                                     BigInteger.Pow(Int32.MaxValue, 2)),
                                      BigInteger.Zero }
      If numbers.Length < 2 Then 
         Console.WriteLine("Cannot determine which is the smaller of {0} numbers.",
                            numbers.Length)
         Exit Sub
      End If
           
      Dim smallest As BigInteger = numbers(numbers.GetLowerBound(0))
      
      For ctr As Integer = numbers.GetLowerBound(0) + 1 To numbers.GetUpperBound(0)
         smallest = BigInteger.Min(smallest, numbers(ctr))
      Next
      Console.WriteLine("The values:")
      For Each number As BigInteger In numbers
         Console.WriteLine("{0,55:N0}", number)
      Next   
      Console.WriteLine()
      Console.WriteLine("The smallest number of the series is:")
      Console.WriteLine("   {0:N0}", smallest)   
   End Sub
End Module
' The example displays the following output:
'       The values:
'                                    -9,223,372,036,854,775,807
'                                                            -1
'                                            10,359,321,239,000
'                                                10,813,504,144
'                                            70,366,596,661,249
'            85,070,591,730,234,615,852,008,593,798,364,921,858
'                                                             0
'       
'       The smallest number of the series is:
'          -9,223,372,036,854,775,807.
' </Snippet1>
