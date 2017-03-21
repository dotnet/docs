 Dim baseUri As New Uri("http://www.contoso.com")
 Dim myUri As New Uri(baseUri, "catalog/shownew.htm")

 Console.WriteLine(myUri.ToString())
