// System.Runtime.Remoting.CallContext.SetHeaders(Header[])

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Security.Principal;
using System.Security.Permissions;

namespace RemotingSamples
{
// <Snippet3>
   public class HelloService : MarshalByRefObject
   {
      public string HelloMethod(string name)
      {
         Console.WriteLine("Hello " + name);
         return "Hello " + name;
      }

      [PermissionSet(SecurityAction.LinkDemand)]
      public string HeaderMethod(string name,Header[] arrHeader)
      {
         Console.WriteLine("HeaderMethod " + name);
         //Header Set with the header array passed
         CallContext.SetHeaders(arrHeader);
         return "HeaderMethod " + name;
      }

   }
// </Snippet3>

   // 'CallContext' and 'ILogicalThreadAffinative' is needed to pass information between threads
   // on either end of a call across an application domain boundary or context boundary.
   [Serializable]
   public class MyLogicalCallContextData : ILogicalThreadAffinative

   {
      int noOfAccesses;
      IPrincipal myIprincipal;
      public string numOfAccesses
      {
        get
        {
          return String.Format("The identity of {0} has been accessed {1} times.",
                                             myIprincipal.Identity.Name,noOfAccesses);
        }
      }

      public IPrincipal Principal
      {
        get
        {
          noOfAccesses++;
          return myIprincipal;
        }
      }

      public MyLogicalCallContextData(IPrincipal p)
      {
        noOfAccesses = 0;
        myIprincipal = p;
      }
   }
}