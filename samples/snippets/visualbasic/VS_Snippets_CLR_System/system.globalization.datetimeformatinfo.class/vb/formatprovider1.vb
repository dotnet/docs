' Visual Basic .NET Document
Option Strict On

' <Snippet9>
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
      Dim dateValue As New Date(2013, 05, 28, 13, 30, 0)
      Dim value As String = dateValue.ToString("F", New CurrentCultureFormatProvider())
      Console.WriteLine(value)
      Console.WriteLine()
      Dim composite As String = String.Format(New CurrentCultureFormatProvider, 
                                              "Date: {0:d}   Amount: {1:C}   Description: {2}",
                                              dateValue, 1264.03d, "Service Charge")
      Console.WriteLine(composite)
      Console.WriteLine()
   End Sub
End Module
' The example displays output like the following:
'       Requesting an object of type DateTimeFormatInfo
'       Tuesday, May 28, 2013 1:30:00 PM
'       
'       Requesting an object of type ICustomFormatter
'       Requesting an object of type DateTimeFormatInfo
'       Requesting an object of type NumberFormatInfo
'       Date: 5/28/2013   Amount: $1,264.03   Description: Service Charge
' </Snippet9>
