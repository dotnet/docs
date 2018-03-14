using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string url = "http://www.contoso.com:8080/letters/readme.html";

      Regex r = new Regex(@"^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
                          RegexOptions.None, TimeSpan.FromMilliseconds(150));
      Match m = r.Match(url);
      if (m.Success)
// <Snippet2>
         Console.WriteLine(m.Groups["proto"].Value + m.Groups["port"].Value); 
// </Snippet2>
   }
}
// The example displays the following output:
//       http:8080
