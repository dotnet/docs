using System;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Security.Permissions;

public class HelloServiceClass : MarshalByRefObject {

   static int n_instances;
   int instanceNum;

   public HelloServiceClass() {
      n_instances++;
      instanceNum = n_instances;
      Console.WriteLine(this.GetType().Name + " has been created.  Instance # = {0}", instanceNum);
   }


   ~HelloServiceClass() {
      Console.WriteLine("Destroyed instance {0} of HelloServiceClass.", instanceNum);      
   }


   [PermissionSet(SecurityAction.LinkDemand)]
   public String HelloMethod(String name) {

      //Extract the call context data
      LogicalCallContextData data = (LogicalCallContextData)CallContext.GetData("test data");      
      IPrincipal myPrincipal = data.Principal;
      
      //Check the user identity
      if(myPrincipal.Identity.Name == "Bob") {
         Console.WriteLine("\nHello {0}, you are identified!", myPrincipal.Identity.Name);
         Console.WriteLine(data.numOfAccesses);
      }
      else {
         Console.WriteLine("Go away! You are not identified!");
         return String.Empty;
      }

        // calculate and return result to client	
      return "Hi there " + name + ".";
   }
}