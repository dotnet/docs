'<snippet1>
' Sample for the Environment.NewLine property
Imports System

Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      Console.WriteLine("NewLine: {0}  first line{0}  second line{0}  third line", _
                             Environment.NewLine)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'NewLine:
'  first line
'  second line
'  third line
'
'</snippet1>