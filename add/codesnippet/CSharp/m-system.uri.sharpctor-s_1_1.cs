Uri baseUri = new Uri("http://www.contoso.com");
 Uri myUri = new Uri(baseUri, "catalog/shownew.htm");

Console.WriteLine(myUri.ToString());
   