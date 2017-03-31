using System;

public class Test
{
    public static void Main()
 {
// <Snippet1>
    Uri baseUri = new Uri("http://www.contoso.com");
    Uri myUri = new Uri(baseUri, "Hello%20World.htm",false);
   
// </Snippet1>
 }
}
