/* This file is a support file for demonstrating IClientChannelSinkProvider 
and ServerProcessing. */

using System;

public class MyHelloService : MarshalByRefObject 
{
   static int myInstances;

   public MyHelloService() 
   {
      myInstances++;
      Console.WriteLine("");
      Console.WriteLine("MyHelloService activated - instance # {0}.", myInstances);
   }

   public String HelloMethod(String myString)
   {
      Console.WriteLine("HelloMethod called on MyHelloService instance {0}.", myInstances);
      return "Hi there " + myString + ".";
   }
}
