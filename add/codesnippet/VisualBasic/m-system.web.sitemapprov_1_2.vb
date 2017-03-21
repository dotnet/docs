    Private Function GetNode(ByVal list As ArrayList, ByVal url As String) As SiteMapNode
      Dim i As Integer
      For i = 0 To list.Count - 1
        Dim item As DictionaryEntry = CType(list(i), DictionaryEntry)
        If CStr(item.Key) = url Then
          Return CType(item.Value, SiteMapNode)
        End If
      Next i
      Return Nothing
    End Function 'GetNode


    ' Get the URL of the currently displayed page.
    Private Function FindCurrentUrl() As String
      Try
        ' The current HttpContext.
        Dim currentContext As HttpContext = HttpContext.Current
        If Not (currentContext Is Nothing) Then
          Return currentContext.Request.RawUrl
        Else
          Throw New Exception("HttpContext.Current is Invalid")
        End If
      Catch e As Exception
        Throw New NotSupportedException("This provider requires a valid context.", e)
      End Try
    End Function 'FindCurrentUrl
