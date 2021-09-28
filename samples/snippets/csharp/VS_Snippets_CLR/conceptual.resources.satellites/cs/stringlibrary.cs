// <Snippet1>
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

// <Snippet2>
[assembly:NeutralResourcesLanguageAttribute("en")]
// </Snippet2>

public class StringLibrary
{
   public string GetGreeting()
   {
      ResourceManager rm = new ResourceManager("Strings",
                           Assembly.GetAssembly(typeof(StringLibrary)));
      string greeting = rm.GetString("Greeting");
      return greeting;
   }
}
// </Snippet1>