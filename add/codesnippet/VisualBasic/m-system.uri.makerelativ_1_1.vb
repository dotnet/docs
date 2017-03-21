        ' Create a base Uri.
        Dim address1 As New Uri("http://www.contoso.com/")
        
        ' Create a new Uri from a string.
        Dim address2 As New Uri("http://www.contoso.com/index.htm?date=today")
        
        ' Determine the relative Uri.  
        Console.WriteLine("The difference is {0}", address1.MakeRelativeUri(address2))
    
    End Sub 'SampleMakeRelative