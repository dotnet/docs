/*
   This program is used as a client of the client proxy class. 
*/

using System;

public class Client
{
   public static void Main()
   {
      MathService myService = new MathService();
      Console.WriteLine("\nThe sum of 10 and 10 is : {0}", myService.Add(10, 10));
   }
}