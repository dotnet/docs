' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      ' Create a custom culture for ru-US.
      Dim car1 As New CultureAndRegionInfoBuilder("ru-US", CultureAndRegionModifiers.None)
      car1.LoadDataFromCultureInfo(CultureInfo.CreateSpecificCulture("ru-RU"))
      car1.LoadDataFromRegionInfo(New RegionInfo("en-US"))
      
      car1.CultureEnglishName = "Russian (United States)"
      car1.CultureNativeName = "русский (США)"
      car1.CurrencyNativeName = "Доллар (США)"
      car1.RegionNativeName = "США"

      ' Register the culture.
      Try
         car1.Register()
      Catch e As InvalidOperationException
         ' Swallow the exception: the culture already is registered.
      End Try
      
      ' Use the custom culture.
      Dim ci As CultureInfo = CultureInfo.CreateSpecificCulture("ru-US")
      Thread.CurrentThread.CurrentCulture = ci
      Console.WriteLine("Current Culture: {0}", 
                        Thread.CurrentThread.CurrentCulture.Name)
      Console.WriteLine("Writing System: {0}", 
                        Thread.CurrentThread.CurrentCulture.TextInfo)
   End Sub
End Module
' The example displays the following output:
'     Current Culture: ru-US
'     Writing System: TextInfo - ru-US
' </Snippet1>
