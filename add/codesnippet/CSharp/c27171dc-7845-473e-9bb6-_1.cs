public class MyClientSponsor : MarshalByRefObject, ISponsor
{
   private DateTime lastRenewal;
   public MyClientSponsor()
   {
      lastRenewal = DateTime.Now;
   }

   [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.Infrastructure)]
   public TimeSpan Renewal(ILease lease)
   {
      Console.WriteLine("Request to renew the lease time.");
      Console.WriteLine("Time since last renewal: " + 
         (DateTime.Now - lastRenewal).ToString());

      lastRenewal = DateTime.Now;
      return TimeSpan.FromSeconds(20);
   }
}