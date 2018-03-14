' <Snippet2>
Imports System.Globalization

Module Example
   Sub Main()
       Dim cultures() As CultureInfo = CultureInfo.GetCultures(CultureTypes.UserCustomCulture Or
                                                               CultureTypes.SpecificCultures)
      Dim ctr As Integer = 0
      For Each culture In cultures
         If (culture.CultureTypes And CultureTypes.UserCustomCulture) = CultureTypes.UserCustomCulture Then
            ctr += 1
         End If
      Next
      Console.WriteLine("Number of Specific Custom Cultures: {0}", ctr)
   End Sub
End Module
' If run under Windows 8, the example displays output like the following:
'      Number of Specific Custom Cultures: 6
' If run under Windows 10, the example displays output like the following:
'      Number of Specific Custom Cultures: 279
' </Snippet2>