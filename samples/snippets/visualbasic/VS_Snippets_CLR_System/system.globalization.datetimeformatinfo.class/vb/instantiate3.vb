' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim culture As CultureInfo
      Dim dtfi As DateTimeFormatInfo
      
      culture = CultureInfo.CurrentCulture
      dtfi = culture.DateTimeFormat
      Console.WriteLine("Culture Name:      {0}", culture.Name)
      Console.WriteLine("User Overrides:    {0}", culture.UseUserOverride)
      Console.WriteLine("Long Time Pattern: {0}", culture.DateTimeFormat.LongTimePattern)
      Console.WriteLine()
            
      culture = New CultureInfo(CultureInfo.CurrentCulture.Name, False)
      Console.WriteLine("Culture Name:      {0}", culture.Name)
      Console.WriteLine("User Overrides:    {0}", culture.UseUserOverride)
      Console.WriteLine("Long Time Pattern: {0}", culture.DateTimeFormat.LongTimePattern)
   End Sub
End Module
' The example displays the following output:
'       Culture Name:      en-US
'       User Overrides:    True
'       Long Time Pattern: HH:mm:ss
'       
'       Culture Name:      en-US
'       User Overrides:    False
'       Long Time Pattern: h:mm:ss tt
' </Snippet8>
