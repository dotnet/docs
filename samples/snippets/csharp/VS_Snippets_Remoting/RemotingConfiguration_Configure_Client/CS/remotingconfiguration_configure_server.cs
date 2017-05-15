// System.Runtime.Remoting.RemotingConfiguration.Configure
// System.Runtime.Remoting.RemotingConfiguration.GetRegisteredWellKnownServiceTypes

/*
  The following example demonstrates the 'Configure' and 
  'GetRegisteredWellKnownServiceTypes' methods of 'RemotingConfiguration' class.
  It configures the remoting infrastructure using the 'Configure' method.Then gets
  the registered well-known objects at the service end and displays it's properties 
  on the console.
*/

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

  public class Sample 
  {
    public static void Main() 
    {
// <Snippet1>

    // Configure the remoting structure.
    RemotingConfiguration.Configure("server.config");

// </Snippet1>
// <Snippet2>

   // Retrive the array of objects registered as well known types at
   // the service end.
   WellKnownServiceTypeEntry[] myEntries =
             RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
   Console.WriteLine("The number of WellKnownServiceTypeEntries are:"
                                 +myEntries.Length);
   Console.WriteLine("The Object Type is:"+myEntries[0].ObjectType);
   Console.WriteLine("The Object Uri is:"+myEntries[0].ObjectUri);
   Console.WriteLine("The Mode is:"+myEntries[0].Mode);

// </Snippet2>

   Console.WriteLine("Press <enter> to exit...");
   Console.ReadLine();
   }
}