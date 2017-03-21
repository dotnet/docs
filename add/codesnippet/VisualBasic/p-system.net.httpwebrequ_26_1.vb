   ' Create a secure group name.
   Dim Sha1 As New SHA1Managed()
   Dim updHash As [Byte]() = Sha1.ComputeHash(Encoding.UTF8.GetBytes(("username" + "password" + "domain")))
   Dim secureGroupName As [String] = Encoding.Default.GetString(updHash)
      
   ' Create a request for a specific URL.
   Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com")
      
   ' Set the authentication credentials for the request.      
   myWebRequest.Credentials = New NetworkCredential("username", "password", "domain")
   myWebRequest.ConnectionGroupName = secureGroupName
      
   ' Get the response.
   Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
      
   ' Insert the code that uses myWebResponse here.
   ' Close the response.
   myWebResponse.Close()
      