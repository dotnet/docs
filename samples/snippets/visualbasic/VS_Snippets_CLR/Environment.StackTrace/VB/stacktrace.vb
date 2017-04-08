'<snippet1>
' Sample for the Environment.StackTrace property
Imports System

Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'StackTrace: '   at System.Environment.GetStackTrace(Exception e)
'   at System.Environment.GetStackTrace(Exception e)
'   at System.Environment.get_StackTrace()
'   at Sample.Main()'
'
'</snippet1>