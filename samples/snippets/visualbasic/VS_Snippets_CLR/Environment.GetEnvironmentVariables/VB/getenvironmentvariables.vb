'<snippet1>
' Sample for the Environment.GetEnvironmentVariables method
Imports System
Imports System.Collections

Class Sample
   Public Shared Sub Main()
      Console.WriteLine("GetEnvironmentVariables: ")
      For Each de As DictionaryEntry In Environment.GetEnvironmentVariables()
         Console.WriteLine("  {0} = {1}", de.Key, de.Value)
      Next 
   End Sub 
End Class 
' Output from the example is not shown, since it is:
'    Lengthy.
'    Specific to the machine on which the example is run.
'    May reveal information that should remain secure.
'</snippet1>