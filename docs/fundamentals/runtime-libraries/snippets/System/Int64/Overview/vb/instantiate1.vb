' Visual Basic .NET Document
Option Strict Off

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
      Dim number1 As Long = -64301728
      Dim number2 As Long = 255486129307
      ' </Snippet1>
   End Sub
   
   Private Sub InstantiateByNarrowingConversion()
      ' <Snippet2>
      Dim ulNumber As ULong = 163245617943825
      Try
         Dim number1 As Long = CLng(ulNumber)
         Console.WriteLine(number1)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of an Int64.", ulNumber)
      End Try
      
      Dim dbl2 As Double = 35901.997
      Try
         Dim number2 As Long = CLng(dbl2)
         Console.WriteLine(number2)
      Catch e As OverflowException
         Console.WriteLine("{0} is out of range of an Int64.", dbl2)
      End Try
         
      Dim bigNumber As BigInteger = 1.63201978555e30
      Try
         Dim number3 As Long = CLng(bigNumber)
         Console.WriteLine(number3)
      Catch e As OverflowException
         Console.WriteLine("{0:N0} is out of range of an Int64.", bigNumber)
      End Try    
      ' The example displays the following output:
      '    163245617943825
      '    35902
      '    1,632,019,785,549,999,969,612,091,883,520 is out of range of an Int64.
      ' </Snippet2>
   End Sub

   Private Sub Parse()
      ' <Snippet3>
      Dim string1 As String = "244681903147"
      Try
         Dim number1 As Long = Int64.Parse(string1)
         Console.WriteLine(number1)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range of a 64-bit integer.", string1)
      Catch e As FormatException
         Console.WriteLine("The format of '{0}' is invalid.", string1)
      End Try

      Dim string2 As String = "F9A3CFF0A"
      Try
         Dim number2 As Long = Int64.Parse(string2,
                                  System.Globalization.NumberStyles.HexNumber)
         Console.WriteLine(number2)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range of a 64-bit integer.", string2)
      Catch e As FormatException
         Console.WriteLine("The format of '{0}' is invalid.", string2)
      End Try
      ' The example displays the following output:
      '    244681903147
      '    67012198154
      ' </Snippet3>     
   End Sub
   
   Private Sub InstantiateByWideningConversion()
      ' <Snippet4>
      Dim value1 As SByte = 124
      Dim value2 As Int16 = 1618
      Dim value3 As Int32 = Int32.MaxValue
      
      Dim number1 As Long = value1
      Dim number2 As Long = value2
      Dim number3 As Long = value3
      ' </Snippet4>
   End Sub
End Module

