using System;
public class HelloServer : MarshalByRefObject
{
   public HelloServer(String myString)
   {
      Console.WriteLine("HelloServer activated");
      Console.WriteLine("Paramater passed to the constructor is "+myString);
   }
   public String HelloMethod(String myName)
   {
      Console.WriteLine("HelloMethod : {0}",myName);
      return "Hi there " + myName;
   }
}