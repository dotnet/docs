' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Retrieve a writable NumberFormatInfo object.
      Dim enUS As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim nfi As NumberFormatInfo = enUS.NumberFormat

      ' Use the ISO currency symbol instead of the native currency symbol.
      nfi.CurrencySymbol =  (New RegionInfo(enUS.Name)).ISOCurrencySymbol
      ' Change the positive currency pattern to <code><space><value>.
      nfi.CurrencyPositivePattern = 2
      ' Change the negative currency pattern to <code><space><sign><value>.     
      nfi.CurrencyNegativePattern = 12
      
      ' Produce the result strings by calling ToString.
      Dim values() As Decimal = { 1065.23d, 19.89d, -.03d, -175902.32d }
      For Each value In values
         Console.WriteLine(value.ToString("C", enUS))
      Next      
      Console.WriteLine()
      
      ' Produce the result strings by calling a composite formatting method.
      For Each value In values
         Console.WriteLine(String.Format(enUS, "{0:C}", value))      
      Next
   End Sub
End Module
' The example displays the following output:
'       USD 1,065.23
'       USD 19.89
'       USD -0.03
'       USD -175,902.32
'       
'       USD 1,065.23
'       USD 19.89
'       USD -0.03
'       USD -175,902.32
' </Snippet1>
