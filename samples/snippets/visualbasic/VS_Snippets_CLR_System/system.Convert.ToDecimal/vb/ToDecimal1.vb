' Visual Basic .NET Document
Option Strict On
Imports System

Module modMain

Public Sub Main()
   ConvertSingleToDecimal()
   ConvertDoubleToDecimal()
End Sub
   
Private Sub ConvertSingleToDecimal()
   ' <Snippet1>
   Console.WriteLine(Convert.ToDecimal(1234567500.12f))   ' Displays 1234568000
   Console.WriteLine(Convert.ToDecimal(1234568500.12f))   ' Displays 1234568000
   
   Console.WriteLine(Convert.ToDecimal(10.980365f))       ' Displays 10.98036 
   Console.WriteLine(Convert.ToDecimal(10.980355f))       ' Displays 10.98036
   ' </Snippet1>
End Sub

Private Sub ConvertDoubleToDecimal()
   ' <Snippet2>
   Console.WriteLine(Convert.ToDecimal(123456789012345500.12R))   ' Displays 123456789012346000
   Console.WriteLine(Convert.ToDecimal(123456789012346500.12R))   ' Displays 123456789012346000
   
   Console.WriteLine(Convert.ToDecimal(10030.12345678905R))       ' Displays 10030.123456789 
   Console.WriteLine(Convert.ToDecimal(10030.12345678915R))       ' Displays 10030.1234567892
   ' </Snippet2>
End Sub
End Module

