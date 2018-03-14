// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      AppDomain domain = AppDomain.CurrentDomain;
      // Set a timeout interval of 2 seconds.
      domain.SetData("REGEX_DEFAULT_MATCH_TIMEOUT", TimeSpan.FromSeconds(2));
      Object timeout = domain.GetData("REGEX_DEFAULT_MATCH_TIMEOUT");
      Console.WriteLine("Default regex match timeout: {0}",
                         timeout == null ? "<null>" : timeout);

      Regex rgx = new Regex("[aeiouy]");
      Console.WriteLine("Regular expression pattern: {0}", rgx.ToString());
      Console.WriteLine("Timeout interval for this regex: {0} seconds",
                        rgx.MatchTimeout.TotalSeconds);
   }
}
// The example displays the following output:
//       Default regex match timeout: 00:00:02
//       Regular expression pattern: [aeiouy]
//       Timeout interval for this regex: 2 seconds
// </Snippet1>
