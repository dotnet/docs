using System;

   public class MyServerImpl :MarshalByRefObject
   {
     public MyServerImpl() 
     {
         Console.WriteLine("Server Activated");
     }

     public String MyMethod(String name) 
     {
         return "The string from client is " + name;
     }
   }

