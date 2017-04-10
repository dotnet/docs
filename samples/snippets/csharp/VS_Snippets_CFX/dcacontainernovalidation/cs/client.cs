using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;

using microsoft.wcf.documentation;
 
public class Client
{
  public static void Main()
  {
    // Picks up configuration from the config file.
      using (SampleServiceClient wcfClient = new SampleServiceClient())
      {
          try
          {
            // Making calls.
            Console.Write("Enter the first name to send: ");
            string first = Console.ReadLine();
            Console.Write("Enter the last name to send: ");
            string last = Console.ReadLine();
            Console.Write("Enter a message: ");
            string msg = Console.ReadLine();

            OriginalPerson person = new OriginalPerson();
            person.lastName = last;
            person.firstName = first;
            person.Message = msg;
            person.additionalData = "extra data the service does not have.";

            person.Blob = new ArgumentException();

            OriginalPerson replyPerson = wcfClient.SampleMethod(person);

            Console.WriteLine("The service responded: " + replyPerson.Message);
            Console.WriteLine("From \"{0}, {1}\".", replyPerson.firstName, replyPerson.lastName);

            if (replyPerson.additionalData == null)
            {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("The return additional data is null");
              Console.ResetColor();
            }
            else
              Console.WriteLine("Any extra data: {0}.", replyPerson.additionalData.ToString());

            if (replyPerson.Blob != null)
              Console.WriteLine("And the added object is: " + replyPerson.Blob.ToString());
            else
              Console.WriteLine("There is no added data in the extra object property.");

            Console.WriteLine("Press ENTER to exit:");
            Console.ReadLine();

            // Done with service. 
            wcfClient.Close();
            Console.WriteLine("Done!");
          }
          catch (TimeoutException timeProblem)
          {
              Console.WriteLine("The service operation timed out. " + timeProblem.Message);
          }
          catch(CommunicationException commProblem)
          {
              Console.WriteLine("There was a communication problem. " + commProblem.Message);
              Console.Read();
          }
      }
  }
}
