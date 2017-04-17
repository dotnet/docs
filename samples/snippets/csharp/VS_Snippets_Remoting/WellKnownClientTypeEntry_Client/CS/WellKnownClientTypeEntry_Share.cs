using System;

public class HelloServer : MarshalByRefObject 
{
   public HelloServer()
   {
      Console.WriteLine("The hashcode of servicing object:"+this.GetHashCode());
   }
   public String HelloMethod(String name)
   {
      Console.WriteLine("'HelloServer.HelloMethod' method is called by : {0}", name);
      return "Hi! " + name + " is calling 'HelloServer.HelloMethod' method. ";
   }
}
