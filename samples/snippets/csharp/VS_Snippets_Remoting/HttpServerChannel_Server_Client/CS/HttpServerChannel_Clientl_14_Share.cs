/* This program will define the methods to execute from the client.
  */
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

public class MyHelloServer : MarshalByRefObject 
{
   public MyHelloServer() 
   {
      Console.WriteLine("HelloServer activated");
   }

   public String myHelloMethod(String name) 
   {
      Console.WriteLine("Hello.HelloMethod : {0}", name);
      return "Hi there " + name;
   }
}