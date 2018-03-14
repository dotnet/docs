/*
   This program implments the remote method which will be called by the
   client.   
*/
using System;
namespace RemotingSamples 
{
   public class HelloServer : MarshalByRefObject
   {
      public HelloServer()
      {
         Console.WriteLine("HelloServer activated");
      }
      public String HelloMethod(String name)
      {
         Console.WriteLine("Hello.HelloMethod : {0}", name);
         return "Hi there " + name;
      }
   }
}

  