// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      String envName = "AppDomain";
      String envValue = "True";
      
      // Determine whether the environment variable exists.
      if (Environment.GetEnvironmentVariable(envName) == null)
         // If it doesn't exist, create it.
         Environment.SetEnvironmentVariable(envName, envValue);
      
      bool createAppDomain;
      Message msg;
      if (Boolean.TryParse(Environment.GetEnvironmentVariable(envName),
                          out createAppDomain) && createAppDomain) {
         AppDomain domain = AppDomain.CreateDomain("Domain2");
         msg = (Message) domain.CreateInstanceAndUnwrap(typeof(Example).Assembly.FullName, 
                                                        "Message");
         msg.Display();                                             
      }                                  
      else {
         msg = new Message();
         msg.Display();   
      }     
   }
}

public class Message : MarshalByRefObject
{
   public void Display()
   {
      Console.WriteLine("Executing in domain {0}", 
                        AppDomain.CurrentDomain.FriendlyName);
   }
}
// </Snippet1>
