' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Delegate Function ParseNumber(Of T)(input As String, styles As NumberStyles, _
                                    provider As IFormatProvider) As T

Module DelegateExample
   Public Sub Main()
      Dim numericString As String = "-1,234"
      Dim parser As ParseNumber(Of Integer) = AddressOf Integer.Parse
      Console.WriteLine(parser(numericString, _
                        NumberStyles.Integer Or NumberStyles.AllowThousands, _
                        CultureInfo.InvariantCulture))
   End Sub
End Module
' </Snippet1>
