' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      Dim uiCulture1 As CultureInfo = CultureInfo.CurrentUICulture
      Dim uiCulture2 As CultureInfo = Thread.CurrentThread.CurrentUICulture
      Console.WriteLine("The current UI culture is {0}", uiCulture1.Name)
      Console.WriteLine("The two CultureInfo objects are equal: {0}",
                        uiCulture1.Equals(uiCulture2))
   End Sub
End Module
' The example displays output like the following:
'     The current UI culture is en-US
'     The two CultureInfo objects are equal: True
' </Snippet2>
