public class HelloServer : MarshalByRefObject {

   public HelloServer() {
      Console.WriteLine("HelloServer activated.");
   }

   [OneWay()]
   public void SayHelloToServer(string name) {
      Console.WriteLine("Client invoked SayHelloToServer(\"{0}\").", name);
   }   

[SecurityPermission(SecurityAction.Demand)]
   // IsOneWay
   // Note the lack of the OneWayAttribute adornment on this method.
   public string SayHelloToServerAndWait(string name) {
      Console.WriteLine("Client invoked SayHelloToServerAndWait(\"{0}\").", name);

      Console.WriteLine(
         "Client waiting for return? {0}",
         RemotingServices.IsOneWay(MethodBase.GetCurrentMethod()) ? "No" : "Yes"
      );

      return "Hi there, " + name + ".";
   }
}