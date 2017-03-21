Uri baseUri = new Uri("http://www.contoso.com/");
 Uri myUri = new Uri(baseUri, "catalog/shownew.htm?date=today");
 
 Console.WriteLine(myUri.AbsolutePath);
   