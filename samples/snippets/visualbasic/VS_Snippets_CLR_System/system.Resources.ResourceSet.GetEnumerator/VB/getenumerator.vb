'<Snippet1>
Imports System
Imports System.Resources
Imports System.Collections
Imports Microsoft.VisualBasic

Class EnumerateResources
   
   Public Shared Sub Main()
      ' Create a ResourceSet for the file items.resources.
      Dim rs As New ResourceSet("items.resources")      
      
      ' Create an IDictionaryEnumerator to read the data in the ResourceSet.
      Dim id As IDictionaryEnumerator = rs.GetEnumerator()
      
      ' Iterate through the ResourceSet and display the contents to the console. 
      While id.MoveNext()
         Console.WriteLine(ControlChars.NewLine + "[{0}] " + ControlChars.Tab + "{1}", id.Key, id.Value)
      End While 

      rs.Close()

   End Sub

End Class
'</Snippet1>