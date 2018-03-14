/*
   This program demonstrates 'BeginResolve' and 'EndResolve' methods of Dns class.
   It obtains the 'IPHostEntry' object by calling 'BeginResolve' and 'EndResolve' method 
   of 'Dns' class by passing a URL, a callback function and an instance of 'RequestState'
   class.Then prints host name, IP address list and aliases.         
*/

using System;
using System.Net;
using System.Threading;

// <Snippet1>
// <Snippet2>
class DnsBeginGetHostByName
{   
   public static System.Threading.ManualResetEvent allDone = null;

   class RequestState
   {
      public IPHostEntry host;
      public RequestState()
      {
         host = null;
      }
   }

   public static void Main()
   {
     allDone = new ManualResetEvent(false);
     // Create an instance of the RequestState class.
     RequestState myRequestState = new RequestState();

     // Begin an asynchronous request for information like host name, IP addresses, or 
     // aliases for specified the specified URI.
     IAsyncResult asyncResult = Dns.BeginResolve("www.contoso.com", new AsyncCallback(RespCallback), myRequestState );

     // Wait until asynchronous call completes.
     allDone.WaitOne();
     Console.WriteLine("Host name : " + myRequestState.host.HostName);
     Console.WriteLine("\nIP address list : ");
     for(int index=0; index < myRequestState.host.AddressList.Length; index++)
     {
       Console.WriteLine(myRequestState.host.AddressList[index]);
     }      
     Console.WriteLine("\nAliases : ");
     for(int index=0; index < myRequestState.host.Aliases.Length; index++)
     {
       Console.WriteLine(myRequestState.host.Aliases[index]);
     }      
   }
   
   private static void RespCallback(IAsyncResult ar)
   {
     try 
     {
       // Convert the IAsyncResult object to a RequestState object.
       RequestState tempRequestState = (RequestState)ar.AsyncState;
       // End the asynchronous request.
       tempRequestState.host = Dns.EndResolve(ar);
       allDone.Set();
     }
	   catch(ArgumentNullException e) 
     {
       Console.WriteLine("ArgumentNullException caught!!!");
       Console.WriteLine("Source : " + e.Source);
       Console.WriteLine("Message : " + e.Message);
     }   
     catch(Exception e)
     {
       Console.WriteLine("Exception caught!!!");
       Console.WriteLine("Source : " + e.Source);
       Console.WriteLine("Message : " + e.Message);
     }
   }
}
// </Snippet2>
// </Snippet1>
