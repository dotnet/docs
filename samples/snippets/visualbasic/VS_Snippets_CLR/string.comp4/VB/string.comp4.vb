 '<snippet1>
Imports System
Imports System.Globalization
 _

Class Sample
   Public Shared Sub Main()
      Dim str1 As [String] = "change"
      Dim str2 As [String] = "dollar"
      Dim relation As [String] = Nothing
      
      relation = symbol([String].Compare(str1, str2, False, New CultureInfo("en-US")))
      Console.WriteLine("For en-US: {0} {1} {2}", str1, relation, str2)
      
      relation = symbol([String].Compare(str1, str2, False, New CultureInfo("cs-CZ")))
      Console.WriteLine("For cs-CZ: {0} {1} {2}", str1, relation, str2)
   End Sub 'Main
   
   Private Shared Function symbol(r As Integer) As [String]
      Dim s As [String] = "="
      If r < 0 Then
         s = "<"
      Else
         If r > 0 Then
            s = ">"
         End If
      End If
      Return s
   End Function 'symbol
End Class 'Sample
'
'This example produces the following results.
'For en-US: change < dollar
'For cs-CZ: change > dollar
'
'</snippet1>