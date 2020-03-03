/* This file is a support file for demonstrating IClientChannelSinkProvider 
and ServerProcessing. */

using System;

public class MyHelloService : MarshalByRefObject 
{
   static int myInstances;

   public MyHelloService() 
   {
      myInstances++;
      Console.WriteLine();
      Console.WriteLine($"MyHelloService activated - instance # {myInstances}.");
   }

   public String HelloMethod(String myString)
   {
      Console.WriteLine($"HelloMethod called on MyHelloService instance {myInstances}.");
      return $"Hi there {myString}.";
   }
}
