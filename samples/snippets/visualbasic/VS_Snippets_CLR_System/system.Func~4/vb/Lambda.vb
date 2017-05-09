' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module LambdaExpression
   Public Sub Main()
      Dim numericString As String = "-1,234"
      Dim parser As Func(Of String, NumberStyles, IFormatProvider, Integer) _
                         = Function(s, sty, p) Integer.Parse(s, sty, p)
      Console.WriteLine(parser(numericString, _
                        NumberStyles.Integer Or NumberStyles.AllowThousands, _
                        CultureInfo.InvariantCulture))
   End Sub
End Module
' </Snippet4>
