// <Snippet5>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;

namespace RemotingSamples
{
   public class HelloService : MarshalByRefObject
   {
      public string HelloMethod(string name)
      {
         Console.WriteLine("Hello " + name);
         return "Hello " + name;
      }

[SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.Infrastructure)]
      public override object InitializeLifetimeService()
      {
         ILease baseLease = (ILease)base.InitializeLifetimeService();
         if (baseLease.CurrentState == LeaseState.Initial)
         {
            // For demonstration the initial time is kept small.
            // in actual scenarios it will be large.
            baseLease.InitialLeaseTime = TimeSpan.FromSeconds(15);
            baseLease.RenewOnCallTime = TimeSpan.FromSeconds(15);
            baseLease.SponsorshipTimeout = TimeSpan.FromMinutes(2);
         }
         return baseLease;
      }
   }
}
// </Snippet5>
