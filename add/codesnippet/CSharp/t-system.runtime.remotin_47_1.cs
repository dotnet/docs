   using System;
   using System.Runtime.Remoting;
   using System.Runtime.Remoting.Channels;
   using System.Runtime.Remoting.Channels.Tcp;

   public class MyClient
   {
      public static void Main()
      {
         ChannelServices.RegisterChannel(new TcpChannel(8082));
         // Create an instance of 'ActivatedServiceTypeEntry' class
         // which holds the values for 'HelloServer' type.
         ActivatedServiceTypeEntry myActivatedServiceTypeEntry =
                      new ActivatedServiceTypeEntry(typeof(HelloServer));
         // Register an object Type on the service end so that 
         // it can be activated on request from a client.
         RemotingConfiguration.RegisterActivatedServiceType(
                                            myActivatedServiceTypeEntry);
         // Get the registered activated service types .
         ActivatedServiceTypeEntry[] myActivatedServiceEntries =
             RemotingConfiguration.GetRegisteredActivatedServiceTypes();
         Console.WriteLine("Information of first registered activated "
                                +" service type :");
         Console.WriteLine("Object type: "
                          +myActivatedServiceEntries[0].ObjectType);
         Console.WriteLine("Description: " 
                              +myActivatedServiceEntries[0].ToString());
         Console.WriteLine("Press enter to stop this process");
         Console.ReadLine();
      }
   }