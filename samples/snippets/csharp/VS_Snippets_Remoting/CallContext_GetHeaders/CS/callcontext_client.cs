// System.Runtime.Remoting.CallContext.FreeNamedDataSlot(string)
// System.Runtime.Remoting.CallContext.GetHeaders()
// System.Runtime.Remoting.CallContext.SetHeaders(Header[])

/* The following example demonstrates 'FreeNamedDataSlot','GetHeaders',
   and 'SetHeaders' methods of 'CallContext' class.

   In the example 'SetData' method is used to set dataSlot. The 'DataSlot' is freed using
   'FreeNamedDataSlot' method by passing the Name parameter.
   For Setting header an array of type 'Messaging.Header' is passed with method call.
   Headers are set in 'HeaderMethod' of remote object using 'SetHeaders' method.
   Finally the 'GetHeaders' method is used to get all headers.
*/

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Security.Principal;


namespace RemotingSamples
{

   class HelloClient
   {
      static void Main()
      {

// <Snippet1>
         // Register the channel.
         TcpChannel myChannel = new TcpChannel ();
         ChannelServices.RegisterChannel(myChannel);
         RemotingConfiguration.RegisterActivatedClientType(typeof(HelloService),"Tcp://localhost:8082");


         GenericIdentity myIdentity = new GenericIdentity("Bob");
         GenericPrincipal myPrincipal = new GenericPrincipal(myIdentity,new string[] {"Level1"});
         MyLogicalCallContextData myData = new MyLogicalCallContextData(myPrincipal);

         // Set DataSlot with name parameter.
         CallContext.SetData("test data",myData);

         // Create a remote object.
         HelloService myService = new HelloService();
         if (myService == null)
         {
            Console.WriteLine("Cannot locate server.");
            return;
         }

         // Call the Remote methods.
         Console.WriteLine("Remote method output is " + myService.HelloMethod("Microsoft"));

         MyLogicalCallContextData myReturnData =
                                    (MyLogicalCallContextData) CallContext.GetData("test data");
         if (myReturnData == null )
            Console.WriteLine("Data is null.");
         else
            Console.WriteLine("Data is '{0}'", myReturnData.numOfAccesses);

         // DataSlot with same Name Parameter which was Set is Freed.
         CallContext.FreeNamedDataSlot("test data");
         MyLogicalCallContextData myReturnData1 =
                                 (MyLogicalCallContextData) CallContext.GetData("test data");
         if (myReturnData1 == null )
            Console.WriteLine("FreeNamedDataSlot Successful for test data");
         else
            Console.WriteLine("FreeNamedDataSlot Failed  for test data");
// </Snippet1>

// <Snippet2>
         // Array of Headers with name and values initialized.
         Header[] myArrSetHeader = {new Header("Header0","CallContextHeader0"),
                                      new Header("Header1","CallContextHeader1")};

         // Pass the Header Array with method call.
         // Header will be set in the method by'CallContext.SetHeaders' method in remote object.

         Console.WriteLine("Remote HeaderMethod output is " +
                                 myService.HeaderMethod("CallContextHeader",myArrSetHeader));

         Header[] myArrGetHeader;
         // Get Header Array.
         myArrGetHeader=CallContext.GetHeaders();
         if (null == myArrGetHeader)
            Console.WriteLine("CallContext.GetHeaders Failed");
         else
            Console.WriteLine("Headers:");
         foreach(Header myHeader in myArrGetHeader)
         {
            Console.WriteLine("Value in Header '{0}' is '{1}'.",myHeader.Name,myHeader.Value);
         }
// </Snippet2>
      }
   }
}
