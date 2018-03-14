using System;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;

// <Snippet1>
 public class MyClass : MarshalByRefObject
 {
   [SecurityPermissionAttribute(SecurityAction.Demand, 
                                Flags=SecurityPermissionFlag.Infrastructure)]
   public override Object InitializeLifetimeService()
   {
     ILease lease = (ILease)base.InitializeLifetimeService();
     if (lease.CurrentState == LeaseState.Initial)
     {
          lease.InitialLeaseTime = TimeSpan.FromMinutes(1);
          lease.SponsorshipTimeout = TimeSpan.FromMinutes(2);
           lease.RenewOnCallTime = TimeSpan.FromSeconds(2);
     }
       return lease;
   }
 }
// </Snippet1>

