        ' Create an absolute Uri from a string.
        Dim absoluteUri As New Uri("http://www.contoso.com/")
        
        ' Create a relative Uri from a string.  allowRelative = true to allow for 
        ' creating a relative Uri.
        Dim relativeUri As New Uri("/catalog/shownew.htm?date=today")
        
        ' Check whether the new Uri is absolute or relative.
        If Not relativeUri.IsAbsoluteUri Then
            Console.WriteLine("{0} is a relative Uri.", relativeUri)
        End If 
        ' Create a new Uri from an absolute Uri and a relative Uri.
        Dim combinedUri As New Uri(absoluteUri, relativeUri)
        Console.WriteLine(combinedUri.AbsoluteUri)
    
    End Sub 'SampleConstructor