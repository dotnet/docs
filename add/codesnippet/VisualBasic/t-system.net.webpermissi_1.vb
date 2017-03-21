
    ' Deny access to a specific resource by setting the ConnectPattern property. 
    <WebPermission(SecurityAction.Deny, ConnectPattern := "http://www\.contoso\.com/.*")> Public Sub Connect()
    
    ' Create a Connection.	 
    Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
    Console.WriteLine("This line should never be printed")
       