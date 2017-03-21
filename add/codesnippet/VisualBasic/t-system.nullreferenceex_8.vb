Module Example
   Public Sub Main()
      Dim pages As New Pages()
      Dim current As Page = pages.CurrentPage
      If current IsNot Nothing Then 
         Dim title As String = current.Title
         Console.WriteLine("Current title: '{0}'", title)
      Else
         Console.WriteLine("There is no page information in the cache.")
      End If   
   End Sub
End Module
' The example displays the following output:
'       There is no page information in the cache.