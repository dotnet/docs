/* This file is a support file for demonstrating the members of
   IChannelSender interface on the client side. The program will
   define the methods to execute from the client. */

using System;

public class MyHelloServer : MarshalByRefObject
{
   public MyHelloServer()
   {
      Console.WriteLine("HelloServer activated");
   }

   public String myHelloMethod(String myString)
   {
      Console.WriteLine("Hello.HelloMethod : {0}", myString);
      return "Hi there " + myString;
   }
}