'<snippet1>
' Sample for the Environment.ExpandEnvironmentVariables method
Imports System

Class Sample
   Public Shared Sub Main()
      Dim str As [String]
      Dim nl As [String] = Environment.NewLine
      
      Console.WriteLine()
      '  <-- Keep this information secure! -->
      Dim query As [String] = "My system drive is %SystemDrive% and" & _ 
                              "my system root is %SystemRoot%"
      str = Environment.ExpandEnvironmentVariables(query)
      Console.WriteLine("ExpandEnvironmentVariables: {0}  {1}", nl, str)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'ExpandEnvironmentVariables:
'  My system drive is C: and my system root is C:\WINNT
'
'</snippet1>