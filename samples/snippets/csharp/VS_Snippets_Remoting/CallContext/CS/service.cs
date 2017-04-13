// <Snippet3>
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
// </Snippet3>

// <Snippet2>
[Serializable]
public class LogicalCallContextData : ILogicalThreadAffinative
{
   int _nAccesses;
   IPrincipal _principal;

   public string numOfAccesses {
      get {
         return String.Format("The identity of {0} has been accessed {1} times.", 
                              _principal.Identity.Name, 
                              _nAccesses);
      }
   }

   public IPrincipal Principal {
      get { 
         _nAccesses ++;
         return _principal;
      }
   }
   
   public LogicalCallContextData(IPrincipal p) {
      _nAccesses = 0;
      _principal = p;
   }
}
// </Snippet2>
