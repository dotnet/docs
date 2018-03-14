'<snippet1>
' Sample for the Environment.MachineName property
Imports System

Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      '  <-- Keep this information secure! -->
      Console.WriteLine("MachineName: {0}", Environment.MachineName)
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'(Any result that is lengthy, specific to the machine on which this sample was tested, 
'or reveals information that should remain secure, has been omitted 
'and marked "!---OMITTED---!".)
'
'MachineName: !---OMITTED---!
'
'</snippet1>