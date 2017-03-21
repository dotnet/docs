    Public Sub Remove(ByVal url As UrlConfigElement)
        If BaseIndexOf(url) >= 0 Then
            BaseRemove(url.Name)
            ' Your custom code goes here.
            Console.WriteLine("UrlsCollection: {0}", "Removed collection element!")
        End If
    End Sub