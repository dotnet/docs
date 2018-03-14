' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module GenericFunc
   Public Sub Main()
      Dim numericString As String = "-1,234"
      Dim parser As Func(Of String, NumberStyles, IFormatProvider, Integer) _
                         = AddressOf Integer.Parse
      Console.WriteLine(parser(numericString, _
                        NumberStyles.Integer Or NumberStyles.AllowThousands, _
                        CultureInfo.InvariantCulture))
   End Sub
End Module
' </Snippet2>
