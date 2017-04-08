' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim values() As String = { "100", "(100)", "-123,456,789", "123.45e+6", _
                                 "+500", "5e2", "3.1416", "600.", "-.123", _
                                 "-Infinity", "-1E-16", Double.MaxValue.ToString(), _
                                 Single.MinValue.ToString(), String.Empty }
      For Each value As String In values
         Try   
            Dim number As Single = Single.Parse(value)
            Console.WriteLine("{0} -> {1}", value, number)
         Catch e As FormatException
            Console.WriteLine("'{0}' is not in a valid format.", value)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of a Single.", value)
         End Try
      Next                                  
   End Sub
End Module
' The example displays the following output:
'       100 -> 100
'       '(100)' is not in a valid format.
'       -123,456,789 -> -1.234568E+08
'       123.45e+6 -> 1.2345E+08
'       +500 -> 500
'       5e2 -> 500
'       3.1416 -> 3.1416
'       600. -> 600
'       -.123 -> -0.123
'       -Infinity -> -Infinity
'       -1E-16 -> -1E-16
'       1.79769313486232E+308 is outside the range of a Single.
'       -3.402823E+38 -> -3.402823E+38
'       '' is not in a valid format.
' </Snippet2>
