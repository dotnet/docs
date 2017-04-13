using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Lifetime;

namespace RemotingSamples
{
   public class HelloService : MarshalByRefObject
   {
      public string HelloMethod(string name)
      {
         Console.WriteLine("Hello " + name);
         return "Hello " + name;
      }
   }
}
