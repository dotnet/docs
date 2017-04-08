' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim culture As CultureInfo
      Dim nfi As NumberFormatInfo
      
      nfi = CultureInfo.GetCultureInfo("id-ID").NumberFormat
      Console.WriteLine("Read-only: {0}", nfi.IsReadOnly)
      
      culture = New CultureInfo("id-ID")
      nfi = NumberFormatInfo.GetInstance(culture)
      Console.WriteLine("Read-only: {0}", nfi.IsReadOnly)
      
      culture = CultureInfo.CreateSpecificCulture("id-ID")
      nfi = culture.NumberFormat
      Console.WriteLine("Read-only: {0}", nfi.IsReadOnly)
      
      culture = New CultureInfo("id-ID")
      nfi = culture.NumberFormat
      Console.WriteLine("Read-only: {0}", nfi.IsReadOnly)
   End Sub
End Module
' The example displays the following output:
'       Read-only: True
'       Read-only: False
'       Read-only: False
'       Read-only: False
' </Snippet5>
