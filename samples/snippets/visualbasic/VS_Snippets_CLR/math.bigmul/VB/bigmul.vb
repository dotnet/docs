'<snippet1>
' This example demonstrates Math.BigMul()
Imports System

Class Sample
   Public Shared Sub Main()
      Dim int1 As Integer = Int32.MaxValue
      Dim int2 As Integer = Int32.MaxValue
      Dim longResult As Long
      '
      longResult = Math.BigMul(int1, int2)
      Console.WriteLine("Calculate the product of two Int32 values:")
      Console.WriteLine("{0} * {1} = {2}", int1, int2, longResult)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'Calculate the product of two Int32 values:
'2147483647 * 2147483647 = 4611686014132420609
'
'</snippet1>