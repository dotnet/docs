/*
   The class 'HelloServer' is derived from 'MarshalByRefObject' to 
   make it remotable.  
*/
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace RemotingSamples 
{
   public class HelloServer : MarshalByRefObject 
   {
      public HelloServer() 
      {
         Console.WriteLine("HelloServer activated");
      }

      public String HelloMethod(String myName) 
      {
         Console.WriteLine("Hello.HelloMethod : {0}", myName);
         return "Hi there " + myName;
      }
   }
}
