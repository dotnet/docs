' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Public Class CurrentCultureFormatProvider : Implements IFormatProvider
   Public Function GetFormat(formatType As Type) As Object _
                   Implements IFormatProvider.GetFormat
      Console.WriteLine("Requesting an object of type {0}", 
                        formatType.Name)
      If formatType Is GetType(NumberFormatInfo) Then
         Return NumberFormatInfo.CurrentInfo
      Else If formatType Is GetType(DateTimeFormatInfo) Then
         Return DateTimeFormatInfo.CurrentInfo
      Else
         Return Nothing
      End If
   End Function
End Class

Module Example
   Public Sub Main()
      Dim amount As Decimal = 1203.541d
      Dim value As String = amount.ToString("C2", New CurrentCultureFormatProvider())
      Console.WriteLine(value)
      Console.WriteLine()
      Dim composite As String = String.Format(New CurrentCultureFormatProvider, 
                                              "Date: {0}   Amount: {1}   Description: {2}",
                                              Date.Now, 1264.03d, "Service Charge")
      Console.WriteLine(composite)
      Console.WriteLine()
   End Sub
End Module
' The example displays output like the following:
'    Requesting an object of type NumberFormatInfo
'    $1,203.54
'    
'    Requesting an object of type ICustomFormatter
'    Requesting an object of type DateTimeFormatInfo
'    Requesting an object of type NumberFormatInfo
'    Date: 11/15/2012 2:00:01 PM   Amount: 1264.03   Description: Service Charge
' </Snippet1>
