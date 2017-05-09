'<snippet1>
' Sample for String.Compare(String, Int32, String, Int32, Int32, Boolean, CultureInfo)
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Class Sample
   
   Public Shared Sub Main()
      '                       0123456
      Dim str1 As [String] = "MACHINE"
      Dim str2 As [String] = "machine"
      Dim str As [String]
      Dim result As Integer
      
      Console.WriteLine()
      Console.WriteLine("str1 = '{0}', str2 = '{1}'", str1, str2)
      Console.WriteLine("Ignore case, Turkish culture:")
      result = [String].Compare(str1, 4, str2, 4, 2, True, New CultureInfo("tr-TR"))
      str = IIf(result < 0, "less than", IIf(result > 0, "greater than", "equal to"))
      Console.Write("Substring '{0}' in '{1}' is ", str1.Substring(4, 2), str1)
      Console.Write("{0} ", str)
      Console.WriteLine("substring '{0}' in '{1}'.", str2.Substring(4, 2), str2)
      
      Console.WriteLine()
      Console.WriteLine("Ignore case, invariant culture:")
      result = [String].Compare(str1, 4, str2, 4, 2, True, CultureInfo.InvariantCulture)
      str = IIf(result < 0, "less than", IIf(result > 0, "greater than", "equal to"))
      Console.Write("Substring '{0}' in '{1}' is ", str1.Substring(4, 2), str1)
      Console.Write("{0} ", str)
      Console.WriteLine("substring '{0}' in '{1}'.", str2.Substring(4, 2), str2)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'str1 = 'MACHINE', str2 = 'machine'
'Ignore case, Turkish culture:
'Substring 'IN' in 'MACHINE' is less than substring 'in' in 'machine'.
'
'Ignore case, invariant culture:
'Substring 'IN' in 'MACHINE' is equal to substring 'in' in 'machine'.
'
'</snippet1>