'<snippet1>
' Sample for String.GetTypeCode()
Imports System

Class Sample
   Public Shared Sub Main()
      Dim str As [String] = "abc"
      Dim tc As TypeCode = str.GetTypeCode()
      Console.WriteLine("The type code for '{0}' is {1}, which represents {2}.", _
                           str, tc.ToString("D"), tc.ToString("F"))
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'The type code for 'abc' is 18, which represents String.
'
'</snippet1>