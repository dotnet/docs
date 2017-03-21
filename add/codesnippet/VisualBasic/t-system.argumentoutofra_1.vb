Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim list As New List(Of String)
      Console.WriteLine("Number of items: {0}", list.Count)
      Try
         Console.WriteLine("The first item: '{0}'", list(0))
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine(e.Message)
      End Try
   End Sub
End Module
' The example displays the following output:
'   Number of items: 0
'   Index was out of range. Must be non-negative and less than the size of the collection.
'   Parameter name: index