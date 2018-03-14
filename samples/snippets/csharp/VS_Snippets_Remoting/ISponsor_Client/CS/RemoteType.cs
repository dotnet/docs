// <Snippet4>
using System;
using System.Runtime.Remoting.Lifetime;
using System.Security.Principal;
using System.Security.Permissions;

[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class ClientActivatedType : MarshalByRefObject
{
   // Override the lease settings for this object.
   public override Object InitializeLifetimeService()
   {
      ILease lease = (ILease)base.InitializeLifetimeService();
      if(lease.CurrentState == LeaseState.Initial)
      {
         lease.InitialLeaseTime = TimeSpan.FromSeconds(3);
         lease.SponsorshipTimeout = TimeSpan.FromSeconds(10);
         lease.RenewOnCallTime = TimeSpan.FromSeconds(2);
      }
      return lease;
   }

   public string RemoteMethod()
   {
      Console.WriteLine("ClientActivatedType.RemoteMethod called.");
      // Report our client identity name.
      return "RemoteMethodCalled. User name : " + WindowsIdentity.GetCurrent().Name;
   }
}
// </Snippet4>
