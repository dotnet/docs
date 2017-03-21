 Dim baseUri As New Uri("http://www.contoso.com:8080/")
 Dim myUri As New Uri(baseUri,"shownew.htm?date=today")
        
 Console.WriteLine(myUri.Host)
