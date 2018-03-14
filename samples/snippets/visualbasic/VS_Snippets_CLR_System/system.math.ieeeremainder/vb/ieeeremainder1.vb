' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Console.WriteLine("{0,35} {1,20}", "IEEERemainder", "Modulus")
      ShowRemainders(3, 2)
      ShowRemainders(4, 2)
      ShowRemainders(10, 3)
      ShowRemainders(11, 3)
      ShowRemainders(27, 4)
      ShowRemainders(28, 5)
      ShowRemainders(17.8, 4)
      ShowRemainders(17.8, 4.1)
      ShowRemainders(-16.3, 4.1)
      ShowRemainders(17.8, -4.1)
      ShowRemainders(-17.8, -4.1)
   End Sub

   Private Sub ShowRemainders(number1 As Double, number2 As Double)
      Dim formula As String = String.Format("{0} / {1} = ", number1, number2)
      Console.WriteLine("{0,-16} {1,18} {2,20}", _
                       formula, _
                       Math.IEEERemainder(number1, number2), _
                       number1 Mod number2)  
   End Sub
End Module
' The example displays the following output:
'       
'                             IEEERemainder              Modulus
'       3 / 2 =                          -1                    1
'       4 / 2 =                           0                    0
'       10 / 3 =                          1                    1
'       11 / 3 =                         -1                    2
'       27 / 4 =                         -1                    3
'       28 / 5 =                         -2                    3
'       17.8 / 4 =                      1.8                  1.8
'       17.8 / 4.1 =                    1.4                  1.4
'       -16.3 / 4.1 =    0.0999999999999979                   -4
'       17.8 / -4.1 =                   1.4                  1.4
'       -17.8 / -4.1 =                 -1.4                 -1.4
' </Snippet1>
