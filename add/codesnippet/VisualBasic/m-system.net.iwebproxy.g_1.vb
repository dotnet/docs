   
    Public Shared Sub Main()
        Dim webProxy_Interface As New WebProxy_Interface(New Uri("http://proxy.example.com"))
        
        webProxy_Interface.Credentials = New NetworkCredential("myusername", "mypassword")
        
        Console.WriteLine("The web proxy is : {0}", webProxy_Interface.GetProxy(New Uri("http://www.contoso.com")))
        
        'Determine whether the Web proxy can be bypassed for the site "http://www.contoso.com".
	console.writeline("For the Uri http://www.contoso.com , the ")
        If webProxy_Interface.IsBypassed(New Uri("http://www.contoso.com")) Then
            Console.WriteLine("webproxy is by passed")
        Else
            Console.WriteLine("webproxy is not bypassed")
        End If 
    End Sub 'Main
