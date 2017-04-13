'<snippet1>
' Sample for String.CompareOrdinal(String, String)
Imports System
Imports Microsoft.VisualBasic

Class Sample
   Public Shared Sub Main()
      Dim str1 As [String] = "ABCD"
      Dim str2 As [String] = "abcd"
      Dim str As [String]
      Dim result As Integer
      
      Console.WriteLine()
      Console.WriteLine("Compare the numeric values of the corresponding Char objects in each string.")
      Console.WriteLine("str1 = '{0}', str2 = '{1}'", str1, str2)
      result = [String].CompareOrdinal(str1, str2)
      str = IIf(result < 0, "less than", IIf(result > 0, "greater than", "equal to"))
      Console.Write("String '{0}' is ", str1)
      Console.Write("{0} ", str)
      Console.WriteLine("String '{0}'.", str2)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'Compare the numeric values of the corresponding Char objects in each string.
'str1 = 'ABCD', str2 = 'abcd'
'String 'ABCD' is less than String 'abcd'.
'
'</snippet1>