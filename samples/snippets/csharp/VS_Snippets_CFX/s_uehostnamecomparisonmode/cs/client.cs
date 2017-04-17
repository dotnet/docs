using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Text;

namespace UE.Samples
{
    class client
    {
        static void Main(string[] args)
        {
          SayHelloClient wcfClient = new SayHelloClient();
          try
          {
              Console.WriteLine(wcfClient.SayHello());
          }
          catch (TimeoutException timeProblem)
          {
            Console.WriteLine("The service operation timed out. " + timeProblem.Message);
            Console.ReadLine();
            wcfClient.Abort();
          }
          catch (CommunicationException commProblem)
          {
            Console.WriteLine("There was a communication problem. " 
              + commProblem.Message + commProblem.StackTrace);
            Console.ReadLine();
            wcfClient.Abort();
          } 
          Console.WriteLine();
          Console.WriteLine("Press <ENTER> to terminate client.");
          Console.ReadLine();
        }
    }
}
