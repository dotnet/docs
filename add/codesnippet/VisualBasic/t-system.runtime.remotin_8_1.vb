Public Class MyClientSponsor
   Inherits MarshalByRefObject
   Implements ISponsor 
   Private lastRenewal As DateTime
   
   Public Sub New()
      lastRenewal = DateTime.Now
   End Sub 'New
   
   <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
   Public Function Renewal(lease As ILease) As TimeSpan Implements ISponsor.Renewal
      Console.WriteLine("Request to renew the lease time.")
      Console.WriteLine("Time since last renewal: " + _ 
                      DateTime.op_Subtraction(DateTime.Now, lastRenewal).ToString())
      
      lastRenewal = DateTime.Now
      Return TimeSpan.FromSeconds(20)
   End Function 'Renewal
End Class 'MyClientSponsor