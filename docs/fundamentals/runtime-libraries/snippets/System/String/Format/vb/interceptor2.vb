' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Globalization

Public Class InterceptProvider : Implements IFormatProvider, ICustomFormatter
   Public Function GetFormat(formatType As Type) As Object _
         Implements IFormatProvider.GetFormat
      If formatType Is GetType(ICustomFormatter) Then
         Return Me
      Else
         Return Nothing
      End If
   End Function
   
   Public Function Format(fmt As String, obj As Object, provider As IFormatProvider) As String _
         Implements ICustomFormatter.Format

      Dim formatString As String = If(fmt IsNot Nothing, fmt, "<null>")
      Console.WriteLine("Provider: {0}, Object: {1}, Format String: {2}",
                        provider, If(obj IsNot Nothing, obj, "<null>"), formatString)

      If obj Is Nothing Then Return String.Empty
            
      ' If this is a byte and the "R" format string, format it with Roman numerals.
      If TypeOf(obj) Is Byte AndAlso formatString.ToUpper.Equals("R") Then
         Dim value As Byte = CByte(obj)
         Dim remainder As Integer
         Dim result As Integer
         Dim returnString As String = String.Empty

         ' Get the hundreds digit(s)
         result = Math.DivRem(value, 100, remainder)
         If result > 0 Then returnString = New String("C"c, result)
         value = CByte(remainder)
         ' Get the 50s digit
         result = Math.DivRem(value, 50, remainder)
         If result = 1 Then returnString += "L"
         value = CByte(remainder)
         ' Get the tens digit.
         result = Math.DivRem(value, 10, remainder)
         If result > 0 Then returnString += New String("X"c, result)
         value = CByte(remainder) 
         ' Get the fives digit.
         result = Math.DivRem(value, 5, remainder)
         If result > 0 Then returnString += "V"
         value = CByte(remainder)
         ' Add the ones digit.
         If remainder > 0 Then returnString += New String("I"c, remainder)
         
         ' Check whether we have too many X characters.
         Dim pos As Integer = returnString.IndexOf("XXXX")
         If pos >= 0 Then
            Dim xPos As Integer = returnString.IndexOf("L") 
            If xPos >= 0 And xPos = pos - 1 Then
               returnString = returnString.Replace("LXXXX", "XC")
            Else
               returnString = returnString.Replace("XXXX", "XL")   
            End If         
         End If
         ' Check whether we have too many I characters
         pos = returnString.IndexOf("IIII")
         If pos >= 0 Then
            If returnString.IndexOf("V") >= 0 Then
               returnString = returnString.Replace("VIIII", "IX")
            Else
               returnString = returnString.Replace("IIII", "IV")    
            End If
         End If
         Return returnString 
      End If   

      ' Use default for all other formatting.
      If obj Is GetType(IFormattable)
         Return CType(obj, IFormattable).ToString(fmt, CultureInfo.CurrentCulture)
      Else
         Return obj.ToString()
      End If
   End Function
End Class

Module Example
   Public Sub Main()
      Dim n As Integer = 10
      Dim value As Double = 16.935
      Dim day As DateTime = Date.Now
      Dim provider As New InterceptProvider()
      Console.WriteLine(String.Format(provider, "{0:N0}: {1:C2} on {2:d}", n, value, day))
      Console.WriteLine()
      Console.WriteLine(String.Format(provider, "{0}: {1:F}", "Today", 
                                      CType(Date.Now.DayOfWeek, DayOfWeek)))
      Console.WriteLine()
      Console.WriteLine(String.Format(provider, "{0:X}, {1}, {2}\n", 
                                      CByte(2), CByte(12), CByte(199)))
      Console.WriteLine()
      Console.WriteLine(String.Format(provider, "{0:R}, {1:R}, {2:R}", 
                                      CByte(2), CByte(12), CByte(199)))
   End Sub
End Module
' The example displays the following output:
'    Provider: InterceptProvider, Object: 10, Format String: N0
'    Provider: InterceptProvider, Object: 16.935, Format String: C2
'    Provider: InterceptProvider, Object: 1/31/2013 6:10:28 PM, Format String: d
'    10: $16.94 on 1/31/2013
'    
'    Provider: InterceptProvider, Object: Today: , Format String: <null>
'    Provider: InterceptProvider, Object: Thursday, Format String: F
'    Today: : Thursday
'    
'    Provider: InterceptProvider, Object: 2, Format String: X
'    Provider: InterceptProvider, Object: 12, Format String: <null>
'    Provider: InterceptProvider, Object: 199, Format String: <null>
'    2, 12, 199
'    
'    Provider: InterceptProvider, Object: 2, Format String: R
'    Provider: InterceptProvider, Object: 12, Format String: R
'    Provider: InterceptProvider, Object: 199, Format String: R
'    II, XII, CXCIX
' </Snippet11>
