'<snippet1>
Imports System
Imports System.Resources
Imports System.Collections
Imports Microsoft.VisualBasic

Class EnumerateResources
   
   Public Shared Sub Main()
      ' Create a ResourceReader for the file items.resources.
      Dim rr As New ResourceReader("items.resources")      
      
      ' Create an IDictionaryEnumerator to iterate through the resources.
      Dim id As IDictionaryEnumerator = rr.GetEnumerator()
      
      ' Iterate through the resources and display the contents to the console. 
      While id.MoveNext()
         Console.WriteLine(ControlChars.NewLine + "[{0}] " + ControlChars.Tab + "{1}", id.Key, id.Value)
      End While 

      rr.Close()

   End Sub

End Class
'</snippet1>