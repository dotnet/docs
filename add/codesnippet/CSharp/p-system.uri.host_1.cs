Uri baseUri = new Uri("http://www.contoso.com:8080/");
Uri myUri = new Uri(baseUri, "shownew.htm?date=today");
 
 Console.WriteLine(myUri.Host);
   