' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example1
   Public Sub Main()
      InstantiateByAssignment()
      Console.WriteLine("----")
      InstantiateByNarrowingConversion()
      Console.WriteLine("----")
      Parse()
      Console.WriteLine("----")
      InstantiateByWideningConversion()
   End Sub
   
   Private Sub InstantiateByAssignment()
      ' <Snippet1>
      Dim number1 As Integer = 64301
      Dim number2 As Integer = 25548612
      ' </Snippet1>
   End Sub
   
   Private Sub InstantiateByNarrowingConversion()
      ' <Snippet2>
      Dim lNumber As Long = 163245617
      Try
         Dim number1 As Integer = CInt(lNumber)
         Console.WriteLine(number1)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of an Int32.", lNumber)
      End Try
      
      Dim dbl2 As Double = 35901.997
      Try
         Dim number2 As Integer = CInt(dbl2)
         Console.WriteLine(number2)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of an Int32.", dbl2)
      End Try
         
      Dim bigNumber As BigInteger = 132451
      Try
         Dim number3 As Integer = CInt(bigNumber)
         Console.WriteLine(number3)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of an Int32.", bigNumber)
      End Try    
      ' The example displays the following output:
      '       163245617
      '       35902
      '       132451
      ' </Snippet2> 
   End Sub

   Private Sub Parse()
      ' <Snippet3>
      Dim string1 As String = "244681"
      Try
         Dim number1 As Integer = Int32.Parse(string1)
         Console.WriteLine(number1)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range of a 32-bit integer.", string1)
      Catch e As FormatException
         Console.WriteLine("The format of '{0}' is invalid.", string1)
      End Try

      Dim string2 As String = "F9A3C"
      Try
         Dim number2 As Integer = Int32.Parse(string2,
                                  System.Globalization.NumberStyles.HexNumber)
         Console.WriteLine(number2)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range of a 32-bit integer.", string2)
      Catch e As FormatException
         Console.WriteLine("The format of '{0}' is invalid.", string2)
      End Try
      ' The example displays the following output:
      '       244681
      '       1022524
      ' </Snippet3>     
   End Sub
   
   Private Sub InstantiateByWideningConversion()
      ' <Snippet4>
      Dim value1 As SByte = 124
      Dim value2 As Int16 = 1618
      
      Dim number1 As Integer = value1
      Dim number2 As Integer = value2
      ' </Snippet4>
   End Sub
End Module

