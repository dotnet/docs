// <Snippet3>
using System;
using System.Runtime.Remoting.Lifetime;
using System.Security.Permissions;

public class ClientActivatedType : MarshalByRefObject{

   // override the lease settings for this object
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
   public override Object InitializeLifetimeService(){
      ILease lease = new MyLease((ILease)base.InitializeLifetimeService());
      return lease;
   }

   public string RemoteMethod(string name){
      // announce to the server that we've been called.
      Console.WriteLine("ClientActivatedType.RemoteMethod called by {0}", name);

      // report our client identity name
      return "Hello, " + name + "!";
   }
}

public class MyLease : MarshalByRefObject, ILease {

   ILease baseLease;

   public MyLease(ILease oldLease) {
      
      Console.WriteLine("Constructing MyLease."); 
      if(oldLease == null)
         Console.WriteLine("CRUD!");
      baseLease = oldLease;
   }

   public TimeSpan CurrentLeaseTime {
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
      get {
         TimeSpan time = baseLease.CurrentLeaseTime;
         Console.WriteLine("The CurrentLeaseTime property returned {0}.", time.Milliseconds);
         return time; 
      }
   }

   public LeaseState CurrentState {
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
      get { 
         LeaseState state = baseLease.CurrentState;
         Console.WriteLine("The CurrentState property returned {0}.", state); 
         return state;
      }
   }

   public TimeSpan InitialLeaseTime {
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
      get {
         TimeSpan time = baseLease.InitialLeaseTime;
         Console.WriteLine("The InitialLeaseTime property returned {0}.", time.Milliseconds); 
         return time; 
      }
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
      set {
         baseLease.InitialLeaseTime = value;
         Console.WriteLine("The InitialLeaseTime property was set to {0}.", value.Milliseconds);
      }
   }

   public TimeSpan RenewOnCallTime {
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
      get {
         TimeSpan time = baseLease.RenewOnCallTime;
         Console.WriteLine("The RenewOnCallTime property returned {0}.", time.Milliseconds); 
         return time; 
      }
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
      set { 
         Console.WriteLine("The RenewOnCallTime property was set to {0}.", value.Milliseconds); 
         baseLease.RenewOnCallTime = value; 
      }
   }

   public TimeSpan SponsorshipTimeout {
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
      get { 
         TimeSpan time = baseLease.SponsorshipTimeout;
         Console.WriteLine("The SponsorshipTimeout property returned {0}.", time.Milliseconds); 
         return time; 
      }
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
      set { 
         Console.WriteLine("The SponsorshipTimeout property was set to {0}.", value.Milliseconds); 
         baseLease.SponsorshipTimeout = value; 
      }
   }                                                

[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
   public void Register(ISponsor sponsor) {
      Console.WriteLine("The sponsor {0} has been registered with the current lease.", sponsor);
      baseLease.Register(sponsor);
   }

[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
   public void Register(ISponsor sponsor, TimeSpan renewalTime) {
      Console.WriteLine("The sponsor {0} has been registered with the current lease for {0} milliseconds...", sponsor, renewalTime.Milliseconds);
      baseLease.Register(sponsor, renewalTime);
   }

[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
   public TimeSpan Renew(TimeSpan renewalTime) {
      Console.WriteLine("The lease has been renewed for {0} milliseconds...", renewalTime.Milliseconds);
      return baseLease.Renew(renewalTime);
   }

[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
   public void Unregister(ISponsor sponsor) {
      Console.WriteLine("The sponsor {0} has been unregistered from the current lease.", sponsor);
      baseLease.Unregister(sponsor);
   }
}
// </Snippet3>
