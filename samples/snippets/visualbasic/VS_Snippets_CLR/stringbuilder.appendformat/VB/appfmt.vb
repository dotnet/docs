' This example demonstrates the StringBuilder.AppendFormat method
'<snippet1>
Imports System
Imports System.Text
Imports System.Globalization

Class Sample
   Private Shared sb As New StringBuilder()

   Public Shared Sub Main()
      Dim var1 As Integer = 111
      Dim var2 As Single = 2.22F
      Dim var3 As String = "abcd"
      Dim var4 As Object() =  {3, 4.4, "X"c}
      
      Console.WriteLine()
      Console.WriteLine("StringBuilder.AppendFormat method:")
      sb.AppendFormat("1) {0}", var1)
      Show(sb)
      sb.AppendFormat("2) {0}, {1}", var1, var2)
      Show(sb)
      sb.AppendFormat("3) {0}, {1}, {2}", var1, var2, var3)
      Show(sb)
      sb.AppendFormat("4) {0}, {1}, {2}", var4)
      Show(sb)
      Dim ci As New CultureInfo("es-ES", True)
      sb.AppendFormat(ci, "5) {0}", var2)
      Show(sb)
   End Sub 'Main
   
   Public Shared Sub Show(sbs As StringBuilder)
      Console.WriteLine(sbs.ToString())
      sb.Length = 0
   End Sub 'Show
End Class 'Sample
'
'This example produces the following results:
'
'StringBuilder.AppendFormat method:
'1) 111
'2) 111, 2.22
'3) 111, 2.22, abcd
'4) 3, 4.4, X
'5) 2,22
'</snippet1>