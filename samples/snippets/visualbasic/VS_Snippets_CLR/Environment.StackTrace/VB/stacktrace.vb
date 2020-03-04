'<snippet1>
' Sample for the Environment.StackTrace property
Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace)
   End Sub
End Class
'
'This example produces the following results:
'
'StackTrace: '   at System.Environment.GetStackTrace(Exception e)
'   at System.Environment.GetStackTrace(Exception e)
'   at System.Environment.get_StackTrace()
'   at Sample.Main()'
'
'</snippet1>