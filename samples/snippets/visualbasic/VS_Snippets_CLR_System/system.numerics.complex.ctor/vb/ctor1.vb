' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim complex1 As New Complex(17.34, 12.87)
      Dim Complex2 As New Complex(8.76, 5.19)
      
      Console.WriteLine("{0} + {1} = {2}", complex1, complex2, 
                                          complex1 + complex2)
      Console.WriteLine("{0} - {1} = {2}", complex1, complex2, 
                                          complex1 - complex2)
      Console.WriteLine("{0} * {1} = {2}", complex1, complex2, 
                                          complex1 * complex2)
      Console.WriteLine("{0} / {1} = {2}", complex1, complex2, 
                                          complex1 / complex2)
   End Sub
End Module
' The example displays the following output:
'    (17.34, 12.87) + (8.76, 5.19) = (26.1, 18.06)
'    (17.34, 12.87) - (8.76, 5.19) = (8.58, 7.68)
'    (17.34, 12.87) * (8.76, 5.19) = (85.1031, 202.7358)
'    (17.34, 12.87) / (8.76, 5.19) = (2.10944241403558, 0.219405693054265)
' </Snippet1>
