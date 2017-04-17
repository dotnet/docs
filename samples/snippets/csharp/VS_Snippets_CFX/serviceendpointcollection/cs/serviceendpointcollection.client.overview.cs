//<snippet2>

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{

    //The service contract is defined in another code file.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
          // Create a WCF client that connects to the base client endpoint using HTTP.
          AddClient client = new AddClient("baseEndpoint");
          try
          {
            // Call the Add service operation over HTTP.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine();
            Console.WriteLine("Invoking the Add operation over HTTP:");
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);
            Console.WriteLine();

            // Close the client.
            client.Close();
          }
          catch (TimeoutException timeout)
          {
            Console.WriteLine(timeout.Message);
            Console.Read();
            client.Abort();          
          }
          catch(CommunicationException commException)
          {
            Console.WriteLine(commException.Message);
            Console.Read();
            client.Abort();
          }

          // Create a WCF client that connects to another client endpoint using TCP.
          AddClient client2 = new AddClient("anotherEndpoint");
          try
            {
                // Call the Add service operation over TCP.
                double value1 = 10.00D;
                double value2 = 15.99D;
                double result = client2.Add(value1, value2);
                Console.WriteLine("Invoking the Add operation over TCP:");
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

                // Close the WCF client.
                client2.Close();
            }
            catch (TimeoutException timeout)
            {
              Console.WriteLine(timeout.Message);
              Console.Read();
              client2.Abort();
            }
            catch (CommunicationException commException)
            {
              Console.WriteLine(commException.Message);
              Console.Read();
              client2.Abort();
            }
          

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}


//</snippet2>