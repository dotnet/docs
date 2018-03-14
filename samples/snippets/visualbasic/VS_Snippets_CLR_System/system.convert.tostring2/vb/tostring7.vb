' Visual Basic .NET Document
Option Strict On

' <Snippet27>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Create a NumberFormatInfo object and set its NegativeSigns
      ' property to use for integer formatting.
      Dim provider As New NumberFormatInfo()
      provider.NegativeSign = "minus "

      Dim values() As Integer = { -20, 0, 100 }

      Console.WriteLine("{0,-8} --> {1,10} {2,10}", "Value",
                         CultureInfo.CurrentCulture.Name,
                         "Custom")
      Console.WriteLine()
      For Each value As Integer In values
         Console.WriteLine("{0,-8} --> {1,10} {2,10}",
                           value, Convert.ToString(value),
                           Convert.ToString(value, provider))
      Next
   End Sub
End Module
' The example displays output like the following:
'       Value    -->      en-US     Custom
'
'       -20      -->        -20   minus 20
'       0        -->          0          0
'       100      -->        100        100
' </Snippet27>

